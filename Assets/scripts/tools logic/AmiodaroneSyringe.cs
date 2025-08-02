using UnityEngine;
using System;
public class AmiodaroneSyringe : Syringe
{
    public float DefibChangeAmount;
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
        if (collision.gameObject.CompareTag("Patient"))
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
        Central_gate.OnAmiodaroneSyringeUse?.Invoke(value);
        Central_gate.OnPatientStatsAdjusted?.Invoke(new PatientStats
        {
            HeartRate = PatientSystem.Stats.getCurrentHeartRate() > 0 ? heartRateChangeAmount : 0,
            DefibrillatorSuccessChance = DefibChangeAmount
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
}
