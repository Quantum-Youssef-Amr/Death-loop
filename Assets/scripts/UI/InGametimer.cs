using TMPro;
using UnityEngine;
public class InGametimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerSec;
    [SerializeField] private TextMeshProUGUI timerMin;
    void Update()
    {
        timerMin.text = $"0{Mathf.FloorToInt(PatientSystem.Stats.TimeTillBrainDamage / 60f)}";
        timerSec.text = (Mathf.FloorToInt(PatientSystem.Stats.TimeTillBrainDamage % 60f) < 10 ? "0":"") + $"{Mathf.RoundToInt(PatientSystem.Stats.TimeTillBrainDamage % 60f)}";
    }


}
