using UnityEngine;

public class Switcher : MonoBehaviour
{
    [SerializeField] private SwitchableObject switchableObject;

    public void Switch()
    {
        if (!switchableObject.canSwitch) return;

        if (switchableObject.isEnable)
            switchableObject.TurnOff();
        else
            switchableObject.TurnOn();
    }
}