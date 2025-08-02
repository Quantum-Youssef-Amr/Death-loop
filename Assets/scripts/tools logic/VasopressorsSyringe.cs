using UnityEngine;
using System;
public class VasopressorsSyringe : Syringe
{
    public float BloodPressureChangeAmount;
    private PatientStats ps;
    void Start()
    {
        Central_gate.OnPatientStatsChanged += setps;
    }

    private void setps(PatientStats stats)
    {
        ps = stats;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Patient"))
        {
            Inject(heartRateChangeAmount);
            EffectTimer();
            GetComponent<DragableItem>()._canMove = false;
            GetComponent<Animation>().Play();
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public override void Inject(float value)
    {
        Central_gate.OnVasopressorsSyringeUse?.Invoke(value);
        Central_gate.OnPatientStatsAdjusted?.Invoke(new PatientStats
        {
            HeartRate = heartRateChangeAmount,
            BloodPressure = BloodPressureChangeAmount
        });
    }
    public override void EffectTimer()
    {
        if (ps.getCurrentBloodPressure() > ps.getHighBloodPressure())
        {
            Central_gate.OnPatientStatsAdjusted?.Invoke(new PatientStats
            { 
                TimeTillBrainDamage = TimerTake
            });
        }

        if (ps.getCurrentBloodPressure() < ps.getLowBloodPressure())
        {
            Central_gate.OnPatientStatsAdjusted?.Invoke(new PatientStats
            { 
                HeartRate = TimerAdd
            });
        }
    }

}
