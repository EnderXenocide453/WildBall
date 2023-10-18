using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform connectedCamera;
    [SerializeField] private Transform target;

    [SerializeField] private float sensitivity = 1;
    [SerializeField] private float minAngle = -45, maxAngle = 90;
    [SerializeField, Range(0.1f, 10)] private float rotationSpeed = 10f;
    [SerializeField] private float maxDistance = 5;
    [SerializeField] private float obstacleOffset = 0.4f;
    [SerializeField] private bool inverseX, inverseY;

    private Vector3 _targetRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        connectedCamera.localPosition = connectedCamera.localPosition.normalized * maxDistance;
    }

    void Update()
    {
        GetInput();
        UpdateCamera();
    }

    public Vector3 GetTargetRotation() => _targetRotation;

    private void GetInput()
    {
        float x = Input.GetAxis(GlobalValues.MOUSE_Y);
        float y = Input.GetAxis(GlobalValues.MOUSE_X);

        _targetRotation.x = Mathf.Clamp(_targetRotation.x - x, minAngle, maxAngle) * (inverseX ? -1 : 1);
        _targetRotation.y += y * (inverseY ? -1 : 1);
    }

    private void UpdateCamera()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(_targetRotation), rotationSpeed * Time.deltaTime);
        transform.position = target.position;
    }
}
