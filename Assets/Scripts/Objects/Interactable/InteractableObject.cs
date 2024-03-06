using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private UnityEvent interactEvent;
    [SerializeField] private Transform canvas;

    [SerializeField] private bool singleUse = false;

    private void Awake()
    {
        SetCanvasActive(false);
    }

    public void SetCanvasActive(bool active)
    {
        canvas.gameObject.SetActive(active);
    }

    public void Activate()
    {
        interactEvent?.Invoke();

        if (singleUse) {
            enabled = false;
            SetCanvasActive(false);
        }
    }
}