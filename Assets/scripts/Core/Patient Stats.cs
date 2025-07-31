using System;

using UnityEngine;

[Serializable]
public struct PatientStats {
    [Header("Critical Stats")]
    public float TimeTillBrainDamage;
    public float HeartRate;
    public float BloodPressure;
    public float OxygenLevel;

    [Header("Modifiers")]
    public float OxygenLossRate;
    public float DefibrillatorSuccessChance;


    private const float HIGH_BLOOD_PRESSURE_THRESHOLD = 190f;
    private const float LETHAL_BLOOD_PRESSURE = 250f;
    private const float LETHAL_HEART_RATE = 200f;
    private const float LETHAL_OXYGEN_LEVEL = 100f;

    public bool IsAlive() {
        return TimeTillBrainDamage > 0f && HeartRate > 0f && OxygenLevel > 0f && BloodPressure > 0f
            && HeartRate <= LETHAL_HEART_RATE && BloodPressure <= LETHAL_BLOOD_PRESSURE && OxygenLevel <= LETHAL_OXYGEN_LEVEL;
    }

    public bool IsBloodPressureHigh() {
        return BloodPressure > HIGH_BLOOD_PRESSURE_THRESHOLD;
    }

    public static PatientStats operator +(PatientStats a, PatientStats b) {
        var res = new PatientStats {
            TimeTillBrainDamage = a.TimeTillBrainDamage + b.TimeTillBrainDamage,
            HeartRate = a.HeartRate + b.HeartRate,
            BloodPressure = a.BloodPressure + b.BloodPressure,
            OxygenLevel = a.OxygenLevel + b.OxygenLevel,
            OxygenLossRate = a.OxygenLossRate + b.OxygenLossRate,
            DefibrillatorSuccessChance = a.DefibrillatorSuccessChance + b.DefibrillatorSuccessChance
        };
        res.Clamp();
        return res;
    }

    public static PatientStats operator -(PatientStats a, PatientStats b) {
        var res = new PatientStats {
            TimeTillBrainDamage = a.TimeTillBrainDamage - b.TimeTillBrainDamage,
            HeartRate = a.HeartRate - b.HeartRate,
            BloodPressure = a.BloodPressure - b.BloodPressure,
            OxygenLevel = a.OxygenLevel - b.OxygenLevel,
            OxygenLossRate = a.OxygenLossRate - b.OxygenLossRate,
            DefibrillatorSuccessChance = a.DefibrillatorSuccessChance - b.DefibrillatorSuccessChance
        };
        res.Clamp();
        return res;
    }

    public void Clamp() {
        TimeTillBrainDamage = Mathf.Max(0f, TimeTillBrainDamage);
        HeartRate = Mathf.Clamp(HeartRate, 0f, LETHAL_HEART_RATE);
        BloodPressure = Mathf.Clamp(BloodPressure, 0f, LETHAL_BLOOD_PRESSURE);
        OxygenLevel = Mathf.Clamp(OxygenLevel, 0f, LETHAL_OXYGEN_LEVEL);
        OxygenLossRate = Mathf.Max(0f, OxygenLossRate);
        DefibrillatorSuccessChance = Mathf.Min(DefibrillatorSuccessChance, 100f);
    }

    public override string ToString() {
        return $"TimeTillBrainDamage: {TimeTillBrainDamage}\n" +
            $"HeartRate: {HeartRate}\n" +
            $"BloodPressure: {BloodPressure}\n" +
            $"OxygenLevel: {OxygenLevel}\n" +
            $"OxygenLossRate: {OxygenLossRate}\n" +
            $"DefibrillatorSuccessChance: {DefibrillatorSuccessChance}";
    }
}