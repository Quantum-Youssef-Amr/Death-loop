using UnityEngine;
using System;
public class AmiodaroneSyringe : Syringe
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
            Central_gate.AmiodaroneSyringeUsed++;
            Inject(heartRateChangeAmount);
            EffectTimer();
        }
    }

    public override void Inject(float value)
    {
        Central_gate.OnAmiodaroneSyringeUse?.Invoke(value);
        Central_gate.OnPatientStatsAdjusted?.Invoke(new PatientStats
        { 
            HeartRate = heartRateChangeAmount
        });
    }

    public override void EffectTimer()
    {
        if (ps.getCurrentHeartRate() > ps.getHighHeartRate())
        {
            Central_gate.OnPatientStatsAdjusted?.Invoke(new PatientStats
            {
                TimeTillBrainDamage = TimerTake
            });
        }
        
        if (ps.getCurrentHeartRate() < ps.getLowHeartRate())
        {
            Central_gate.OnPatientStatsAdjusted?.Invoke(new PatientStats
            { 
                TimeTillBrainDamage = TimerAdd
            });
        }
    }

    public override void CanUse()
    {
        _canBeUsed = true;
    }
}
