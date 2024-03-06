using UnityEngine;

public abstract class SwitchableObject : MonoBehaviour
{
    public abstract bool isEnable { get; }
    public abstract bool canSwitch { get; }

    public abstract void TurnOn();

    public abstract void TurnOff();
}