using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : BaseObject
{
    [SerializeField, Range(1f, 50)] private float speed = 5;

    private Vector3 _moveDir;

    private void Update()
    {
        HandleAxis();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void HandleAxis()
    {
        float x = Input.GetAxis(GlobalValues.HOR_AXIS);
        float z = Input.GetAxis(GlobalValues.VERT_AXIS);

        _moveDir = new Vector3(x, 0, z).normalized;
    }

    private void Move()
    {
        _body.AddForce(_moveDir * speed);
    }
}