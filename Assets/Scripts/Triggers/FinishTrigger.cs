using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private int nextLevel;
    [SerializeField] private LayerMask mask;

    private GameMenuController _controller;

    private void Start()
    {
        _controller = GameObject.FindGameObjectWithTag("Canvas").GetComponent<GameMenuController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & mask.value) > 0)
            _controller.LoadLevel(nextLevel);
    }
}