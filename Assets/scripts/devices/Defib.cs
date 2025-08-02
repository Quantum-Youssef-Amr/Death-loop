using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Defib : MonoBehaviour
{
    [SerializeField] private float power = 200f, timeToCharge = 1f;
    [SerializeField] private float MaxPower = 400f, MinPower = 200f;
    [SerializeField] private int PositiveEffect = 40, nigativeEffect = 20;
    [SerializeField] private PlacedObjects leftpaddle, rightpaddle;
    [SerializeField] private GameObject WarningScreen, InfoScreen;
    [SerializeField] private TextMeshProUGUI PowerText;
    [SerializeField] private Image ChargeMeter;
    [SerializeField] private Animation ChargeComplete;

    private bool PaddesPlaced;
    private bool _charged;
    private Coroutine chargeCo;

    void Update()
    {
        PaddesPlaced = leftpaddle.placed && rightpaddle.placed;
        InfoScreen.SetActive(PaddesPlaced);
        WarningScreen.SetActive(!PaddesPlaced);
    }

    public void IncreasePower()
    {
        if (_charged) return;
        power += 50f;
        power = Mathf.Clamp(power, MinPower, MaxPower);
        PowerText.text = power + " J";
    }
    public void DecreasePower()
    {
        if (_charged) return;
        power -= 50f;
        power = Mathf.Clamp(power, MinPower, MaxPower);
        PowerText.text = power + " J";
    }

    public void ChargeAndShock()
    {
        if (!_charged)
        {
            if (PaddesPlaced && chargeCo == null) chargeCo = StartCoroutine(charge());
        }
        else
        {
            shock();
        }
    }

    private IEnumerator charge()
    {
        float chargeDelta = 1f / timeToCharge;
        yield return new WaitUntil(
            () =>
            {
                ChargeMeter.fillAmount += chargeDelta * Time.deltaTime * (MinPower / power);
                return ChargeMeter.fillAmount == 1;
            }
        );
        _charged = true;
        ChargeComplete.enabled = true;  
        ChargeComplete.Play();
        chargeCo = null;
    }

    private void shock()
    {
        if (!PaddesPlaced)
            return;

        if (!_charged)
            return;

        if (!PatientSystem.Stats.DefibrillatorWorked())
        {
            resetDefib();
            return;
        }

        if (PatientSystem.Stats.IsHeartCritical())
        {
            if (PatientSystem.Stats.IsHeartUpperCritical())
                Central_gate.OnPatientStatsAdjusted?.Invoke(new PatientStats() { HeartRate = Mathf.CeilToInt(-PositiveEffect * (power / MinPower)), DefibrillatorSuccessChance = -0.2f });
            else
                Central_gate.OnPatientStatsAdjusted?.Invoke(new PatientStats() { HeartRate = Mathf.CeilToInt(PositiveEffect * (power / MinPower)), DefibrillatorSuccessChance = -0.2f });
        }
        else
        {
            if (Random.value > 0.5f * (MinPower / power))
                Central_gate.OnPatientStatsAdjusted?.Invoke(new PatientStats() { HeartRate = -PatientSystem.Stats.HeartRate });
            else
                Central_gate.OnPatientStatsAdjusted?.Invoke(new PatientStats() { HeartRate = Mathf.CeilToInt(-nigativeEffect * (power / MinPower)), DefibrillatorSuccessChance = -0.2f });
        }
        resetDefib();
    }

    private void resetDefib()
    {
        ChargeComplete.Stop();
        ChargeComplete.Sample();

        ChargeComplete.enabled = false;  
        ChargeMeter.fillAmount = 0;
        _charged = false;
    }

}
