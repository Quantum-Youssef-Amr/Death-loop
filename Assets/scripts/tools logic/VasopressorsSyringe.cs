using UnityEngine;
using System;
public class VasopressorsSyringe : Syringe
{
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
        if (!_canBeUsed) return;
        if (collision.CompareTag("Patient"))
        {
            Central_gate.VasopressorsSyringeUseed++;
            Inject(heartRateChangeAmount);
            EffectTimer();
        }
    }

    public override void Inject(float value)
    {
        Central_gate.OnVasopressorsSyringeUse?.Invoke(value);
        Central_gate.OnPatientStatsAdjusted?.Invoke(new PatientStats
        { 
            HeartRate = heartRateChangeAmount
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
    public override void CanUse()
    {
        _canBeUsed = true;
    }

}
