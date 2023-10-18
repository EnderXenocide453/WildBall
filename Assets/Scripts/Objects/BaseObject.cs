using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BaseObject : MonoBehaviour
{
    [SerializeField] protected bool spawnAsStart = true;
    [SerializeField] protected Vector3 spawnPoint;
    [SerializeField] protected Quaternion spawnRotation;

    [SerializeField] protected bool respawnable = true;

    protected Rigidbody _body;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();

        if (spawnAsStart) {
            SetRespawn(transform.localPosition, transform.localRotation);
        }

        Init();
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

    protected virtual void Init() { }

    protected void Respawn()
    {
        _body.velocity = Vector3.zero;
        _body.angularVelocity = Vector3.zero;

        transform.localPosition = spawnPoint;
        transform.localRotation = spawnRotation;
    }

    protected void Death()
    {
        Destroy(gameObject);
    }
}
