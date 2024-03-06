using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// �������, ���������� �������
/// </summary>
public class EventTrigger : MonoBehaviour
{
    /// <summary>
    /// ������� ���������
    /// </summary>
    [SerializeField] private UnityEvent activateEvent;

    /// <summary>
    /// ���� ��������������
    /// </summary>
    [SerializeField] private LayerMask interactableMask;

    /// <summary>
    /// ������������ ��������?
    /// </summary>
    [SerializeField] private bool singleUse = false;

    /// <summary>
    /// ����� ������������
    /// </summary>
    [SerializeField] private float activateCoolDown = 5;

    private bool _isActive = true;

    /// <summary>
    /// Transform �������, ��������������� �������
    /// </summary>
    public Transform ActivatedObject { get; private set; }

    private void OnTriggerStay(Collider other)
    {
        if (_isActive && ((1 << other.gameObject.layer) & interactableMask.value) > 0)
            Activate(other.transform);
    }

    /// <summary>
    /// ��������� ��������
    /// </summary>
    /// <param name="activated">������, �������������� �������</param>
    private void Activate(Transform activated)
    {
        activateEvent?.Invoke();

        _isActive = false;
        ActivatedObject = activated;

        if (!singleUse)
            StartCoroutine(CoolDown());
    }

    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(activateCoolDown);

        _isActive = true;
    }
}