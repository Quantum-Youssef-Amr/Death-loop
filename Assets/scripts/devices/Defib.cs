using TMPro;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class Defib : MonoBehaviour
{
    [SerializeField] private float power = 200f;
    [SerializeField] private PlacedObjects leftpaddle, rightpaddle;
    [SerializeField] private GameObject WarningScreen, InfoScreen;
    [SerializeField] private TextMeshProUGUI PowerText;

    private bool _canBeUsed;
    private bool _charged;
    
    void Update()
    {
        if (leftpaddle.placed && rightpaddle.placed)
        {
            _canBeUsed = true;
        }
    }

    public void IncreasePower()
    {
        power += 50f;
        power = Mathf.Clamp(power, 200, 400);
    }
    public void DecreasePower()
    {
        power -= 50f;
        power = Mathf.Clamp(power, 200, 400);
    }

    public void shock()
    {
        if (!PatientSystem.Stats.DefibrillatorWorked())
            return;
        
        if (PatientSystem.Stats.IsHeartCritical())
            {
                if (PatientSystem.Stats.IsHeartUpperCritical())
                {
                    Central_gate.OnPatientStatsAdjusted?.Invoke(new PatientStats() { HeartRate = -40 });
                }
                else
                {
                    Central_gate.OnPatientStatsAdjusted?.Invoke(new PatientStats() { HeartRate = 40 });
                }
            }
            else
            {
                if (Random.value > 0.5f)
                {
                    PatientSystem.Stats.SetHeartRate(0);
                }
                else
                {
                    Central_gate.OnPatientStatsAdjusted?.Invoke(new PatientStats() { HeartRate = -20 });
                }
            }
    }


}
