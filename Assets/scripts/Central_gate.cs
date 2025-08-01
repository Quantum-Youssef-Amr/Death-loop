using System;

public static class Central_gate
{
    public static int AdrenalineSyringeUsed, AmiodaroneSyringeUsed, VasopressorsSyringeUseed;
    public static Action<float> OnAdrenalineSyringeUse, OnAmiodaroneSyringeUse, OnVasopressorsSyringeUse;
    public static Action<PatientStats> OnPatientStatsAdjusted;
    public static Action<PatientStats> OnPatientStatsChanged;
    public static Action OnPatientSaved;
    public static Action OnPatientDeath;
    public static Action OnGameLoop;

    public static Action<bool> BVMStat;
}
