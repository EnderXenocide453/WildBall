using UnityEngine;

public class RigidbodyKinematicMovement : RigidbodyAnimation
{
    /// <summary>
    /// Скорость перемещения
    /// </summary>
    [SerializeField] private float moveSpeed = 0.5f;

    /// <summary>
    /// Завершить анимацию после первого прохода?
    /// </summary>
    [SerializeField] private bool isPlayOnce;

    /// <summary>
    /// Путевые точки
    /// </summary>
    [SerializeField] private Transform[] wayPoints;

    private int _currentPoint = 0;

    /// <summary>
    /// Итоговая скорость
    /// </summary>
    public float Speed { get => moveSpeed * Time.fixedDeltaTime * animationSpeed; }

    protected override void Init()
    {
        if (wayPoints.Length == 0) {
            Debug.LogWarning("Путевые точки не назначены!");
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
    /// Начать следование к следующей точке
    /// </summary>
    private void FollowNextTarget()
    {
        _currentPoint = ++_currentPoint % wayPoints.Length;
    }
}