using TMPro;
using UnityEngine;
public class InGametimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerSec;
    [SerializeField] private TextMeshProUGUI timerMin;
    void Update()
    {
        timerMin.text = $"{Mathf.RoundToInt(PatientSystem.Stats.TimeTillBrainDamage / 60f)}";
        timerSec.text = $"{Mathf.RoundToInt(PatientSystem.Stats.TimeTillBrainDamage % 60f)}";
    }


}
