using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : BaseObject
{
    [SerializeField, Range(1f, 50)] private float speed = 5;
    [SerializeField, Range(1f, 1000)] private float jumpForce = 20;
    [SerializeField, Range(0.1f, 1)] private float turnSpeed;

    [SerializeField] private LayerMask interactMask;
    [SerializeField] private Transform collisionBody;
    [SerializeField] private ParticleSystem deathParticles;

    private Vector3 _moveDir;

    private CameraController _camera;
    private InteractableObject _activeObj;

    private Dictionary<int, ContactPoint[]> _collisions;

    protected override void Init()
    {
        _collisions = new Dictionary<int, ContactPoint[]>();

        _camera = GameObject.Find("CameraOrigin").GetComponent<CameraController>();

        InputManager.onJumpButtonPress += Jump;
        InputManager.onInteractButtonPress += Interact;
    }

    private void OnDestroy()
    {
        InputManager.onJumpButtonPress -= Jump;
        InputManager.onInteractButtonPress -= Interact;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        Move();
    }

    private void OnCollisionStay(Collision collision)
    {
        foreach (var contact in collision.contacts)
            Debug.DrawRay(contact.point, contact.normal, Color.blue);

        if (!_collisions.TryAdd(collision.collider.GetInstanceID(), collision.contacts))
            _collisions[collision.collider.GetInstanceID()] = collision.contacts;
    }

    private void OnCollisionExit(Collision collision)
    {
        _collisions.Remove(collision.collider.GetInstanceID());
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<InteractableObject>(out var obj)) {
            _activeObj = obj;
            obj.SetCanvasActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<InteractableObject>(out var obj)) {
            _activeObj = null;
            obj.SetCanvasActive(false);
        }
    }

    private void Jump()
    {
        if (_collisions.Count == 0) return;

        body.AddForce(CalculateJumpDirection() * jumpForce);
    }

    private Vector3 CalculateJumpDirection()
    {
        Vector3 dir = Vector3.zero;

        foreach (var collision in _collisions)
            foreach (var contact in collision.Value) {
                Debug.DrawRay(contact.point, contact.normal);
                dir += contact.normal;

                Debug.Log(collision.Key + " " + contact.normal);
            }

        return dir.normalized;
    }

    private void Interact()
    {
        _activeObj?.Activate();
    }

    private void Move()
    {
        _moveDir = Quaternion.Euler(0, _camera.GetTargetRotation().y, 0) * InputManager.axis.normalized;

        body.AddForce(_moveDir * speed);
    }

    protected override void Respawn()
    {
        StartCoroutine(RespawnTo(spawnPoint, speed));
    }

    private IEnumerator RespawnTo(Vector3 pos, float speed)
    {
        deathParticles.Play();

        body.isKinematic = true;
        collisionBody.gameObject.SetActive(false);

        while (Vector3.Distance(body.position, pos) > 0.01f) {
            transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        body.isKinematic = false;
        collisionBody.gameObject.SetActive(true);
    }
}