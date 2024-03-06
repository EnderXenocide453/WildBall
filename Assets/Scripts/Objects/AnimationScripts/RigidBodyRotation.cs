using UnityEngine;

public class RigidBodyRotation : RigidbodyAnimation
{
    [SerializeField] private Vector3 axis = Vector3.up;
    [SerializeField] private float rotationSpeed = 0.5f;

    public float DegreesSpeed { get => rotationSpeed * 360 * Time.fixedDeltaTime * animationSpeed; }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, axis);
    }

#endif

    protected override void Animate()
    {
        body.MoveRotation(body.rotation * Quaternion.AngleAxis(DegreesSpeed, axis));
    }

    protected override void Init()
    { }
}