using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class RigidbodyAnimation : MonoBehaviour
{
    public float animationSpeed = 1;
    public bool playOnStart = true;

    protected Rigidbody body;

    private bool _isAnimate = true;

    private void Start()
    {
        body = GetComponent<Rigidbody>();

        Init();

        if (playOnStart)
            Play();
    }

    private void FixedUpdate()
    {
        if (_isAnimate)
            Animate();
    }

    /// <summary>
    /// ������ ��������
    /// </summary>
    public virtual void Play()
    {
        _isAnimate = true;
    }

    /// <summary>
    /// ������������ ��������
    /// </summary>
    public virtual void Stop()
    {
        _isAnimate = false;
    }

    /// <summary>
    /// �������������. ���������� � Start
    /// </summary>
    protected abstract void Init();

    /// <summary>
    /// ����� ��������. ���������� � FixedUpdate
    /// </summary>
    protected abstract void Animate();
}