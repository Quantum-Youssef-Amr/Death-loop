using System;

using UnityEngine;

public class PatientSystem : MonoBehaviour {
    public Action<PatientStats> OnStatsAdjusted;
    public Action<PatientStats> OnStatsChanged;
    public Action OnPatientSaved;
    public Action OnPatientDeath;

    private static PatientSystem s_instance;
    public static PatientSystem SceneInstance {
        get {
            if (s_instance == null) {
                s_instance = FindFirstObjectByType<PatientSystem>();
            }
            return s_instance;
        }
    }

    private PatientStats m_currentStats;
    public static PatientStats Stats { get => SceneInstance.m_currentStats; }

    public void InitializeStats(PatientStats initialStats) {
        m_currentStats = initialStats;
    }

    private void OnEnable() {
        OnStatsAdjusted += ApplyPatientStatsDelta;
    }

    private void OnDisable() {
        OnStatsAdjusted -= ApplyPatientStatsDelta;
    }

    private void ApplyPatientStatsDelta(PatientStats deltaStats) {
        m_currentStats += deltaStats;

        OnStatsChanged?.Invoke(m_currentStats);

        if (!m_currentStats.IsAlive()) {
            OnPatientDeath?.Invoke();
        }
    }
}