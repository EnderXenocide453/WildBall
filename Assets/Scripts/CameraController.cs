using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform connectedCamera;
    [SerializeField] private Rigidbody targetBody;

    [SerializeField] private float sensitivity = 1;
    [SerializeField] private float minAngle = -45, maxAngle = 90;
    [SerializeField, Range(0.1f, 10)] private float rotationSpeed = 10f;
    [SerializeField] private float maxDistance = 5;
    [SerializeField] private float distanceToObstacle = 0.05f;
    [SerializeField] private bool inverseX, inverseY;

    [SerializeField] LayerMask cameraObstaclesMask;

    private Vector3 _targetRotation;
    private Vector3 _normalizedCameraPos;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        _normalizedCameraPos = connectedCamera.localPosition.normalized;
    }

    private void Update()
    {
        GetInput();
        UpdateCamera();
    }

    public Vector3 GetTargetRotation() => _targetRotation;

    private void GetInput()
    {
        float x = Input.GetAxis(GlobalValues.MouseY) * sensitivity;
        float y = Input.GetAxis(GlobalValues.MouseX) * sensitivity;

        _targetRotation.x = Mathf.Clamp(_targetRotation.x - x, minAngle, maxAngle) * (inverseX ? -1 : 1);
        _targetRotation.y += y * (inverseY ? -1 : 1);
    }

    private void UpdateCamera()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(_targetRotation), rotationSpeed * Time.deltaTime);
        transform.position = targetBody.position;

        Ray ray = new Ray(transform.position, connectedCamera.position - transform.position);
        if (Physics.Raycast(ray, out var hit, maxDistance, cameraObstaclesMask)) {
            connectedCamera.localPosition = _normalizedCameraPos * (hit.distance - distanceToObstacle);
        } else {
            connectedCamera.localPosition = _normalizedCameraPos * maxDistance;
        }

    }
}