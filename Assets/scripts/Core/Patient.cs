using UnityEngine;

public class Patient : MonoBehaviour {
    [SerializeField] private PatientStats m_initialStats;

    private void Start()
    {
        // TODO: Initialize with random stats in each loop
        m_initialStats = new PatientStats(120, 80, 100);
        Central_gate.OnGameLoop += setup;

        Central_gate.OnGameLoop?.Invoke();
    }

    private void setup()
    {
        PatientSystem.SceneInstance.InitializeStats(m_initialStats);
    }

    private void OnEnable()
    {
        Central_gate.OnPatientDeath += Die;
        Central_gate.OnPatientSaved += Revive;
    }

    private void OnDisable() {
        if (PatientSystem.SceneInstance == null) return;

        Central_gate.OnPatientDeath -= Die;
        Central_gate.OnPatientSaved -= Revive;
    }

    private void Die() {
        Debug.Log("TODO: Patient died");
    }

    private void Revive() {
        Debug.Log("TODO: Patient revived");
    }
}