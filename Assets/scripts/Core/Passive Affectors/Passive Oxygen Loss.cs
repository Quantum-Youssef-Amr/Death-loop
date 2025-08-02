using System;
using UnityEngine;

public class PassiveOxygenLoss : MonoBehaviour {
    private bool stat;
    private void OnEnable()
    {
        // Central_gate.OnPatientDeath += Stop;
        // Central_gate.OnPatientSaved += Stop;

        Central_gate.BVMStat += setEnable;

    }

    private void setEnable(bool enable)
    {
        stat = enable;
    }

    private void OnDisable() {
        if (PatientSystem.SceneInstance == null) return;

        // Central_gate.OnPatientDeath -= Stop;
        // Central_gate.OnPatientSaved -= Stop;
    }

    private void Stop() {
        enabled = false;
    }

    private void Update() {
        if (!enabled) return;

        var deltaStats = new PatientStats { OxygenLevel = (stat ? Time.deltaTime : -Time.deltaTime)* PatientSystem.Stats.OxygenLossRate };
        Central_gate.OnPatientStatsAdjusted?.Invoke(deltaStats);
    }
}