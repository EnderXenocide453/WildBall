using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BaseObject : MonoBehaviour
{
    [SerializeField] protected bool spawnAsStart = true;
    [SerializeField] protected Vector3 spawnPoint;
    [SerializeField] protected Quaternion spawnRotation;

    [SerializeField] protected bool respawnable = true;

    protected Rigidbody body;
    protected Rigidbody parentBody;

    protected Vector3 parentVelocity;

    private void Start()
    {
        body = GetComponent<Rigidbody>();

        if (spawnAsStart) {
            SetRespawn(transform.localPosition, transform.localRotation);
        }

        Init();
    }

    protected virtual void FixedUpdate()
    {
        ApplyParentVelocity();
    }

    public void SetRespawn(Vector3 point, Quaternion rotation)
    {
        spawnPoint = point;
        spawnRotation = rotation;
    }

    public void EnterDeathZone()
    {
        if (respawnable)
            Respawn();
        else
            Death();
    }

    protected virtual void Init()
    { }

    protected virtual void Respawn()
    {
        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;

        transform.localPosition = spawnPoint;
        transform.localRotation = spawnRotation;
    }

    protected void Death()
    {
        Destroy(gameObject);
    }

    private void ApplyParentVelocity()
    {
        Vector3 targetVelocity = parentBody ? parentBody.velocity : Vector3.zero;

        parentVelocity = Vector3.MoveTowards(parentVelocity, targetVelocity, body.drag);
    }
}