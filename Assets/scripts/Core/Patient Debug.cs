using UnityEngine;

public class PatientDebug : MonoBehaviour {
    private PatientStats m_stats;

    private void OnEnable() {
        PatientSystem.SceneInstance.OnStatsChanged += SetStats;
    }

    private void OnDisable() {
        if (PatientSystem.SceneInstance == null) return;

        PatientSystem.SceneInstance.OnStatsChanged -= SetStats;
    }

    private void SetStats(PatientStats stats) {
        m_stats = stats;
    }

    private GUIStyle m_leftAlignedStyle;
    private void OnGUI() {
        if (m_leftAlignedStyle == null) {
            m_leftAlignedStyle = new GUIStyle(GUI.skin.box);
            m_leftAlignedStyle.alignment = TextAnchor.UpperLeft;
        }

        GUILayout.BeginArea(new Rect(10, 10, 300, 200));
        GUILayout.Box($"Current Patient Stats: {m_stats}", m_leftAlignedStyle, GUILayout.ExpandHeight(true));
        GUILayout.EndArea();
    }
}