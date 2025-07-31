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
    public float DefibrilattorSuccessChance;

    public static PatientStats operator +(PatientStats a, PatientStats b) {
        var res = new PatientStats {
            TimeTillBrainDamage = a.TimeTillBrainDamage + b.TimeTillBrainDamage,
            HeartRate = a.HeartRate + b.HeartRate,
            BloodPressure = a.BloodPressure + b.BloodPressure,
            OxygenLevel = a.OxygenLevel + b.OxygenLevel,
            OxygenLossRate = a.OxygenLossRate + b.OxygenLossRate,
            DefibrilattorSuccessChance = a.DefibrilattorSuccessChance + b.DefibrilattorSuccessChance
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
            DefibrilattorSuccessChance = a.DefibrilattorSuccessChance - b.DefibrilattorSuccessChance
        };
        res.Clamp();
        return res;
    }

    public void Clamp() {
        TimeTillBrainDamage = Mathf.Max(0f, TimeTillBrainDamage);
        HeartRate = Mathf.Clamp(HeartRate, 0f, 200f);
        BloodPressure = Mathf.Clamp(BloodPressure, 0f, 200f);
        OxygenLevel = Mathf.Clamp(OxygenLevel, 0f, 100f);
        OxygenLossRate = Mathf.Clamp(OxygenLossRate, 0f, 100f);
        DefibrilattorSuccessChance = Mathf.Clamp(DefibrilattorSuccessChance, 0f, 100f);
    }

    public override string ToString() {
        return $"TimeTillBrainDamage: {TimeTillBrainDamage}\n" +
            $"HeartRate: {HeartRate}\n" +
            $"BloodPressure: {BloodPressure}\n" +
            $"OxygenLevel: {OxygenLevel}\n" +
            $"OxygenLossRate: {OxygenLossRate}\n" +
            $"DefibrilattorSuccessChance: {DefibrilattorSuccessChance}";
    }
}