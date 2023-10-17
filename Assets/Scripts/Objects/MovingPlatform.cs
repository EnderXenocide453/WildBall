using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingPlatform : MonoBehaviour
{
    private Rigidbody _body;

    void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _body.MovePosition(_body.position + Vector3.right * 0.2f);
    }
}
