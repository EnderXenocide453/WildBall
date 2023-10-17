using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void ChangeAnimation()
    {
        _anim.SetInteger("state", Random.Range(0, 3));
        _anim.SetTrigger("change");
    }
}
