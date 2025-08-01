using System.Collections;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class BVM : MonoBehaviour
{
    private SpriteResolver _sr;
    private PlacedObjects _po;
    private PatientStats patientStats;
    private Coroutine co = null;
    void Start()
    {
        Central_gate.OnPatientStatsChanged += setpatientState;
        _sr = GetComponent<SpriteResolver>();
        _po = GetComponent<PlacedObjects>();
    }

    private void setpatientState(PatientStats stats)
    {
        patientStats = stats;
    }

    void Update()
    {
        if (_po.Moving)
        {
            _sr.SetCategoryAndLabel("sprites", "2");
            StopAllCoroutines();
            co = null;
        }
        else
        {
            if (!_po.placed)
                _sr.SetCategoryAndLabel("sprites", "1");
            else
            {
                if(co == null)
                    co = StartCoroutine(breath());
            }
        }
        Central_gate.BVMStat?.Invoke(_po.placed);
    }

    private IEnumerator breath()
    {
        _sr.SetCategoryAndLabel("sprites", "3");
        yield return new WaitForSeconds(patientStats.OxygenLevel / 100f);
        _sr.SetCategoryAndLabel("sprites", "2");
        yield return new WaitForSeconds(patientStats.OxygenLevel / 100f);
        co = StartCoroutine(breath());
    }
}
