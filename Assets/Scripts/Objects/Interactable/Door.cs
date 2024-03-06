using UnityEngine;

public class Door : SwitchableObject
{
    private Animator _anim;
    private bool _isOpen = false;

    public override bool isEnable
    {
        get => _isOpen;
    }

    public override bool canSwitch
    {
        get => _anim.speed == 0;
    }

    private void Start()
    {
        _anim = GetComponent<Animator>();
        StopAnim();
    }

    public override void TurnOff()
    {
        _anim.SetBool("open", false);
        _anim.speed = 1;

        _isOpen = false;
    }

    public override void TurnOn()
    {
        _anim.SetBool("open", true);
        _anim.speed = 1;

        _isOpen = true;
    }

    public void StopAnim()
    {
        _anim.speed = 0;
    }
}