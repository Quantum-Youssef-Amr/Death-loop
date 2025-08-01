using UnityEngine;

public class PassiveBrainDamage : MonoBehaviour {
    private void OnEnable() {
        Central_gate.OnPatientDeath += Stop;
        Central_gate.OnPatientSaved += Stop;
    }

    private void OnDisable() {
        if (PatientSystem.SceneInstance == null) return;

        Central_gate.OnPatientDeath -= Stop;
        Central_gate.OnPatientSaved -= Stop;
    }

    private void Stop() {
        enabled = false;
    }

    private void Update() {
        if (!enabled) return;

        var deltaStats = new PatientStats { TimeTillBrainDamage = -Time.deltaTime };
        Central_gate.OnPatientStatsAdjusted?.Invoke(deltaStats);
    }
}