using UnityEngine;

[System.Serializable]
public struct PatientStats {
    [Header("Critical Stats")]
    public float TimeTillBrainDamage;
    public int HeartRate;
    public float BloodPressure;
    public float OxygenLevel;

    [Header("Modifiers")]
    public float OxygenLossRate;
    public float DefibrillatorSuccessChance;

    public PatientStats(int HeartRate, float BloodPressure, float OxygenLevel, float TimeTillBrainDamage = 120f, float OxygenLossRate = 2f, float DefibrillatorSuccessChance = 0.8f)
    {
        this.TimeTillBrainDamage = TimeTillBrainDamage;
        this.HeartRate = HeartRate;
        this.BloodPressure = BloodPressure;
        this.OxygenLevel = OxygenLevel;
        this.OxygenLossRate = OxygenLossRate;
        this.DefibrillatorSuccessChance = DefibrillatorSuccessChance;
    }



    public const float LETHAL_BLOOD_PRESSURE = 250f;
    public const float HIGH_BLOOD_PRESSURE_THRESHOLD = 190f;
    public const float LOW_BLOOD_PRESSURE = 90f;
    public const float LETHAL_OXYGEN_LEVEL = 200f;
    public const float LOW_OXYGEN_LEVEL = 0f;
    public const int LETHAL_HEART_RATE = 200;
    public const int HIGH_HEART_RATE = 150;
    public const int LOW_HEART_RATE = 70;

    public bool IsAlive() {
        return TimeTillBrainDamage > 0f && HeartRate > 0f && OxygenLevel > 0f && BloodPressure > 0f
            && HeartRate <= LETHAL_HEART_RATE && BloodPressure <= LETHAL_BLOOD_PRESSURE && OxygenLevel <= LETHAL_OXYGEN_LEVEL;
    }

    public bool IsHeartCritical()
    {
        return (float) HeartRate / LETHAL_HEART_RATE > 0.8f || (float) HeartRate / LETHAL_HEART_RATE < 0.2f;
    }
    public bool IsHeartUpperCritical()
    {
        return (float)HeartRate / LETHAL_HEART_RATE > 0.5f;
    }

    public bool DefibrillatorWorked()
    {
        return Random.value > 1 - DefibrillatorSuccessChance;
    }

    public bool IsBloodPressureHigh()
    {
        return BloodPressure > HIGH_BLOOD_PRESSURE_THRESHOLD;
    }

    public int getCurrentHeartRate()
    {
        return HeartRate;
    }

    public int getHighHeartRate()
    {
        return HIGH_HEART_RATE;
    }

    public int getLowHeartRate()
    {
        return LOW_HEART_RATE;
    }

    public int getLethelHeartRate()
    {
        return LETHAL_HEART_RATE;
    }

    public float getLethelBloodPrusser(){
        return LETHAL_BLOOD_PRESSURE;
    }

    public float getLethelOxygenlevel(){
        return LETHAL_OXYGEN_LEVEL;
    }

    public float getCurrentBloodPressure()
    {
        return BloodPressure;
    }

    public float getHighBloodPressure()
    {
        return HIGH_BLOOD_PRESSURE_THRESHOLD;
    }

    public float getLowBloodPressure()
    {
        return LOW_BLOOD_PRESSURE;
    }

    public float getlowOxgenLevel()
    {
        return LOW_OXYGEN_LEVEL;
    }
    public void SetHeartRate(int value)
    {
        HeartRate = value;
    }

    public static PatientStats operator +(PatientStats a, PatientStats b)
    {
        var res = new PatientStats
        {
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
        HeartRate = Mathf.Clamp(HeartRate, 0, LETHAL_HEART_RATE);
        BloodPressure = Mathf.Clamp(BloodPressure, 0f, LETHAL_BLOOD_PRESSURE);
        OxygenLevel = Mathf.Clamp(OxygenLevel, 0f, LETHAL_OXYGEN_LEVEL);
        OxygenLossRate = Mathf.Max(0f, OxygenLossRate);
        DefibrillatorSuccessChance = Mathf.Min(DefibrillatorSuccessChance, 1f);
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