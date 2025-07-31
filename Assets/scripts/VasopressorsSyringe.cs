using UnityEngine;
using System;
public class VasopressorsSyringe : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float heartRateLevel = 20;
    private bool bloodPressureState;
    float heartRateChangeAmount =20;
    private static event Action<float> HeartRateChange;
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Patient"))
        {
            //  heartRateChangeAmoun I will change the logic based on Mark's script data 
            heartRateChangeAmount -= heartRateLevel;
            HeartRateChange?.Invoke(heartRateChangeAmount);
        }
    }


    void AddSecondsToTimer(float value)
    {
        // here after the timer increase we add the new hear rate !
        if (bloodPressureState)
        {
            // add 2 sec to timer 

        }
        if (!bloodPressureState)
        {
            // takes 5 sec from timer
        }
    }

    void HeartRateChangeValue(float value)
    {

    }
    private void OnEnable()
    {
        HeartRateChange += HeartRateChangeValue;
    }

    private void OnDisable()
    {
        HeartRateChange -= HeartRateChangeValue;
    }
}
