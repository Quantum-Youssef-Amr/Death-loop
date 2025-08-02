using UnityEngine;
using System.Collections;
public class Patient : MonoBehaviour
{
    [SerializeField] private float timeToChangeStat = 30f;
    [SerializeField] private PatientStats m_initialStats;
    private void Start()
    {
        Central_gate.OnGameLoop += setup;
        Central_gate.OnGameLoop?.Invoke();
        StartCoroutine(ChangePatientState());
    }

    private void setup()
    {
        SetPatientRandomState();
        PatientSystem.SceneInstance.InitializeStats(m_initialStats);
    }


    private void SetPatientRandomState()
    {
        m_initialStats = new PatientStats(
            Random.Range(PatientSystem.Stats.getLowHeartRate(), PatientSystem.Stats.getLethelHeartRate()),
            Random.Range(PatientSystem.Stats.getLowBloodPressure(), PatientSystem.Stats.getLethelBloodPrusser()),
            Random.Range(PatientSystem.Stats.getlowOxgenLevel(), PatientSystem.Stats.getLethelOxygenlevel()),
            120f,
            2,
            0.6f);
    }

    private IEnumerator ChangePatientState()
    {
        yield return new WaitForSeconds(timeToChangeStat);
        changePatientState();
        StartCoroutine(ChangePatientState());
    }

    private void changePatientState()
    {
        Central_gate.OnPatientStatsAdjusted?.Invoke(new PatientStats()
        {
            HeartRate = Random.Range(-50, 50),
            BloodPressure = Random.Range(-40, 40),
            OxygenLevel = Random.Range(-50, 50),
            OxygenLossRate = Random.Range(2, 5)
        });
    }

    private void OnEnable()
    {
        Central_gate.OnPatientDeath += Die;
        Central_gate.OnPatientSaved += Revive;
    }

    private void OnDisable()
    {
        if (PatientSystem.SceneInstance == null) return;

        Central_gate.OnPatientDeath -= Die;
        Central_gate.OnPatientSaved -= Revive;
    }

    private void Die()
    {
        Debug.Log("TODO: Patient died");
    }

    private void Revive()
    {
        Debug.Log("TODO: Patient revived");
    }
}