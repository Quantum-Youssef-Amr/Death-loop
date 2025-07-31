using UnityEngine;
using System;
public class AdrenalineSyringe : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] int numberOfInjections = 0;
    [SerializeField] float heartRateLevel = 20;
    [SerializeField] float adrenalineLevel =0;
    private static event Action<float> AdrenalineSyringeInjection;
    private static event Action<float> HeartRateChange;
    public int NumberOfInjections { get => numberOfInjections; set => numberOfInjections = value; }
    public float HeartRateLevel { get => heartRateLevel; set => heartRateLevel = value; }



    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Patient"))
        {
        
            AdrenalineSyringeInjection?.Invoke(adrenalineLevel);

            if (numberOfInjections >= 3)
                HeartRateChange?.Invoke(heartRateLevel);

        }
    }
    
    void InjectTheArenalineSyringe(float value)
    {
        if (adrenalineLevel<3)
               adrenalineLevel += 1;
       if(numberOfInjections<3)
           numberOfInjections += 1;
    }
    void HeartRateChangeValue(float value)
    {
        Debug.Log(" Patient Heart Rate is Up 20 %"+value);
    }
    private void OnEnable()
    {
        AdrenalineSyringeInjection += InjectTheArenalineSyringe;
        HeartRateChange += HeartRateChangeValue;
    }
    private void OnDisable()
    {
        AdrenalineSyringeInjection -= InjectTheArenalineSyringe;
        HeartRateChange -= HeartRateChangeValue;
    }
}
