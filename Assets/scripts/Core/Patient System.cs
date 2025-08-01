using UnityEngine;

public class PatientSystem : MonoBehaviour {
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

    public void InitializeStats(PatientStats initialStats)
    {
        m_currentStats = initialStats;
    }

    private void OnEnable() {
        Central_gate.OnPatientStatsAdjusted += ApplyPatientStatsDelta;
    }

    private void OnDisable() {
        Central_gate.OnPatientStatsAdjusted -= ApplyPatientStatsDelta;
    }

    private void ApplyPatientStatsDelta(PatientStats deltaStats) {
        m_currentStats += deltaStats;

        Central_gate.OnPatientStatsChanged?.Invoke(m_currentStats);

        if (!m_currentStats.IsAlive()) {
            Central_gate.OnPatientDeath?.Invoke();
        }
    }
}