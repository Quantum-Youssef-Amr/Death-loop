using UnityEngine;
using System;

public abstract class Syringe : MonoBehaviour
{
    public int TimerAdd, TimerTake;
    public int heartRateChangeAmount;
    protected bool _canBeUsed;
    public abstract void Inject(float value);
    public abstract void EffectTimer();
    public abstract void CanUse();
}
