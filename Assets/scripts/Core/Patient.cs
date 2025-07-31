using UnityEngine;

public class Patient : MonoBehaviour {
    [SerializeField] private PatientStats m_initialStats;

    private void Start() {
        // TODO: Initialize with random stats in each loop
        PatientSystem.SceneInstance.InitializeStats(m_initialStats);
    }

    private void OnEnable() {
        PatientSystem.SceneInstance.OnPatientDeath += Die;
        PatientSystem.SceneInstance.OnPatientSaved += Revive;
    }

    private void OnDisable() {
        if (PatientSystem.SceneInstance == null) return;

        PatientSystem.SceneInstance.OnPatientDeath -= Die;
        PatientSystem.SceneInstance.OnPatientSaved -= Revive;
    }

    private void Die() {
        Debug.Log("TODO: Patient died");
    }

    private void Revive() {
        Debug.Log("TODO: Patient revived");
    }
}