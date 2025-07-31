using UnityEngine;
using System;
public class AmiodaroneSyringe : MonoBehaviour
{
    [SerializeField] int numberOfInjections = 0;
    [SerializeField] float addingSecondsToTimer = 5;
    [SerializeField] float heartRateLevel = 50;
    private static event Action<float> AmiodaroneSyringeInjection;
    private static event Action<float> HeartRateChange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Patient"))
        {
            if (numberOfInjections < 2)
                numberOfInjections += 1;
            if (numberOfInjections >= 2)
                AmiodaroneSyringeInjection?.Invoke(addingSecondsToTimer);

        }
    }

    // Update is called once per frame
    void AddSecondsToTimer(float value)
    {
        // here after the timer increase we add the new hear rate !
        HeartRateChange?.Invoke(heartRateLevel);
    }
    void HeartRateChangeValue(float value)
    {
        Debug.Log(" Patient Heart Rate is Up " + value + " % ");
    }


    private void OnEnable()
    {
        AmiodaroneSyringeInjection += AddSecondsToTimer;
        HeartRateChange += HeartRateChangeValue;
    }

    private void OnDisable()
    {
        AmiodaroneSyringeInjection -= AddSecondsToTimer;
        HeartRateChange -= HeartRateChangeValue;
    }
}
