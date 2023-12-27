using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Триггер, вызывающий событие
/// </summary>
public class EventTrigger : MonoBehaviour
{
    /// <summary>
    /// Событие активации
    /// </summary>
    [SerializeField] private UnityEvent activateEvent;

    /// <summary>
    /// Слои взаимодействия
    /// </summary>
    [SerializeField] private LayerMask interactableMask;

    /// <summary>
    /// Активируется единожды?
    /// </summary>
    [SerializeField] private bool singleUse = false;

    /// <summary>
    /// Откат срабатывания
    /// </summary>
    [SerializeField] private float activateCoolDown = 5;

    private bool _isActive = true;

    /// <summary>
    /// Transform объекта, активировавшего триггер
    /// </summary>
    public Transform ActivatedObject { get; private set; }

    private void OnTriggerStay(Collider other)
    {
        if (_isActive && ((1 << other.gameObject.layer) & interactableMask.value) > 0)
            Activate(other.transform);
    }

    /// <summary>
    /// Активация триггера
    /// </summary>
    /// <param name="activated">Объект, активировавший триггер</param>
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