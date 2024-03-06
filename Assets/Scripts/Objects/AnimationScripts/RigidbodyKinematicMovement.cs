using UnityEngine;

public class RigidbodyKinematicMovement : RigidbodyAnimation
{
    /// <summary>
    /// �������� �����������
    /// </summary>
    [SerializeField] private float moveSpeed = 0.5f;

    /// <summary>
    /// ��������� �������� ����� ������� �������?
    /// </summary>
    [SerializeField] private bool isPlayOnce;

    /// <summary>
    /// ������� �����
    /// </summary>
    [SerializeField] private Transform[] wayPoints;

    private int _currentPoint = 0;

    /// <summary>
    /// �������� ��������
    /// </summary>
    public float Speed { get => moveSpeed * Time.fixedDeltaTime * animationSpeed; }

    protected override void Init()
    {
        if (wayPoints.Length == 0) {
            Debug.LogWarning("������� ����� �� ���������!");
            enabled = false;
        }
    }

    protected override void Animate()
    {
        body.MovePosition(Vector3.MoveTowards(body.position, wayPoints[_currentPoint].position, Speed));
        if (Vector3.Distance(body.position, wayPoints[_currentPoint].position) < 0.05f)
            FollowNextTarget();
    }

    /// <summary>
    /// ������ ���������� � ��������� �����
    /// </summary>
    private void FollowNextTarget()
    {
        _currentPoint = ++_currentPoint % wayPoints.Length;
    }
}