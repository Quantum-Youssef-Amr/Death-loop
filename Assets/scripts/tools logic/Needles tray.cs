using UnityEngine;

public class Needlestray : MonoBehaviour
{
    [SerializeField] private Transform AdrenalineSyringe, AmiodaroneSyringe, VasopressorsSyringe;
    [SerializeField] private GameObject AdrenalineSyringePrefab, AmiodaroneSyringePrefab, VasopressorsSyringePrefab;
    [SerializeField] private int AdrenalineSyringeAmount, AmiodaroneSyringeAmount, VasopressorsSyringeAmount;

    private Vector2 _AdrenalineSyringeloc, _AmiodaroneSyringeloc, _VasopressorsSyringeloc;
    private int _AdrenalineSyringeUsed, _AmiodaroneSyringeUsed, _VasopressorsSyringeUsed;
    void Start()
    {
        _AdrenalineSyringeloc = AdrenalineSyringe.position;
        _AmiodaroneSyringeloc = AmiodaroneSyringe.position;
        _VasopressorsSyringeloc = VasopressorsSyringe.position;

        Destroy(AdrenalineSyringe.gameObject);
        Destroy(AmiodaroneSyringe.gameObject);
        Destroy(VasopressorsSyringe.gameObject);

        Instantiate(AdrenalineSyringePrefab, transform).transform.position = _AdrenalineSyringeloc;
        Instantiate(AmiodaroneSyringePrefab, transform).transform.position = _AmiodaroneSyringeloc;
        Instantiate(VasopressorsSyringePrefab, transform).transform.position = _VasopressorsSyringeloc;

        Central_gate.OnAdrenalineSyringeUse += AdrenalineSyringeUsed;
        Central_gate.OnAmiodaroneSyringeUse += AmiodaroneSyringeUsed;
        Central_gate.OnVasopressorsSyringeUse += VasopressorsSyringeUsed;
    }

    private void VasopressorsSyringeUsed(float obj)
    {
        if (_VasopressorsSyringeUsed < VasopressorsSyringeAmount -1)
        {
            GameObject syr = Instantiate(VasopressorsSyringePrefab, transform);
            syr.transform.position = _VasopressorsSyringeloc;
            _VasopressorsSyringeUsed++;
        }
    }

    private void AmiodaroneSyringeUsed(float obj)
    {
        if (_AmiodaroneSyringeUsed < AmiodaroneSyringeAmount -1)
        {
            GameObject syr = Instantiate(AmiodaroneSyringePrefab, transform);
            syr.transform.position = _AmiodaroneSyringeloc;
            _AmiodaroneSyringeUsed++;
        }
    }

    private void AdrenalineSyringeUsed(float obj)
    {
        if (_AdrenalineSyringeUsed < AdrenalineSyringeAmount -1)
        {
            GameObject syr = Instantiate(AdrenalineSyringePrefab, transform);
            syr.transform.position = _AdrenalineSyringeloc;
            _AdrenalineSyringeUsed++;
        }
    }
}
