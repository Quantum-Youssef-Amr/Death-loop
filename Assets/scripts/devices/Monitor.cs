using System;
using UnityEngine;
using UnityEngine.UI;

public class Monitor : MonoBehaviour
{
    [SerializeField] private Image HeartRate, BloodPrusser, OxygenLevel;
    [SerializeField] private Animation HRAnimation, BPAnimation, OLAnimation;

    void Start()
    {
        Central_gate.OnPatientStatsChanged += updateUI;
    }

    private void updateUI(PatientStats stats)
    {
        HeartRate.fillAmount = Mathf.Lerp(HeartRate.fillAmount, (float)stats.HeartRate / stats.getLethelHeartRate(), Time.deltaTime * 2f);
        BloodPrusser.fillAmount = Mathf.Lerp(BloodPrusser.fillAmount, stats.BloodPressure / stats.getLethelBloodPrusser(), Time.deltaTime * 2f);
        OxygenLevel.fillAmount = Mathf.Lerp(OxygenLevel.fillAmount, stats.OxygenLevel / stats.getLethelOxygenlevel(), Time.deltaTime * 2f);

        if (HeartRate.fillAmount > 0.8 || HeartRate.fillAmount < 0.2)
        {
            HRAnimation.Play();
        }
        else
        {
            HRAnimation.Stop();
        }

        if (BloodPrusser.fillAmount > 0.8 || BloodPrusser.fillAmount < 0.2)
        {
            BPAnimation.Play();
        }
        else
        {
            BPAnimation.Stop();
        }

        if (OxygenLevel.fillAmount > 0.8 || OxygenLevel.fillAmount < 0.2)
        {
            OLAnimation.Play();
        }
        else
        {
            OLAnimation.Stop();
        }

    }
}
