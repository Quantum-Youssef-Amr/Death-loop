using UnityEngine;

public class PassiveOxygenLoss : MonoBehaviour {
    private void OnEnable() {
        PatientSystem.SceneInstance.OnPatientDeath += Stop;
        PatientSystem.SceneInstance.OnPatientSaved += Stop;
    }

    private void OnDisable() {
        if (PatientSystem.SceneInstance == null) return;

        PatientSystem.SceneInstance.OnPatientDeath -= Stop;
        PatientSystem.SceneInstance.OnPatientSaved -= Stop;
    }

    private void Stop() {
        enabled = false;
    }

    private void Update() {
        if (!enabled) return;

        var deltaStats = new PatientStats { OxygenLevel = -Time.deltaTime * PatientSystem.Stats.OxygenLossRate };
        PatientSystem.SceneInstance.OnStatsAdjusted?.Invoke(deltaStats);
    }
}