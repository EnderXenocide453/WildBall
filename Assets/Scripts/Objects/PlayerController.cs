using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : BaseObject
{
    [SerializeField, Range(1f, 50)] private float speed = 5;
    [SerializeField] private CameraController cam;
    [SerializeField, Range(0.1f, 1)] private float turnSpeed;

    private Vector3 _moveDir;

    private void Update()
    {
        UpdateAxis();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void UpdateAxis()
    {
        float x = Input.GetAxis(GlobalValues.HOR_AXIS);
        float z = Input.GetAxis(GlobalValues.VERT_AXIS);

        _moveDir = Quaternion.Euler(0, cam.GetTargetRotation().y, 0) * new Vector3(x, 0, z).normalized;
    }

    private void Move()
    {
        _body.AddForce(_moveDir * speed);
    }
}