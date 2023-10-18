using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : BaseObject
{
    [SerializeField, Range(1f, 50)] private float speed = 5;
    [SerializeField, Range(1f, 1000)] private float jumpForce = 20;
    [SerializeField, Range(0.1f, 1)] private float turnSpeed;
    [SerializeField] private CameraController cam;

    private Vector3 _moveDir;
    private bool _canJump = false;

    private GlobalKeyHandler _keyHandler;

    protected override void Init()
    {
        _keyHandler = GameObject.FindGameObjectWithTag("Canvas").GetComponent<GlobalKeyHandler>();

        _keyHandler.onJumpButtonPress += Jump;
    }

    private void Update()
    {
        UpdateAxis();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionStay(Collision collision)
    {
        _canJump = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _canJump = false;
    }

    private void Jump()
    {
        if (!_canJump) return;

        _body.AddForce(Vector3.up * jumpForce);
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