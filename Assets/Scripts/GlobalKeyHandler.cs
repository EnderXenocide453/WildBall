using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalKeyHandler : MonoBehaviour
{
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode pauseKey = KeyCode.Escape;

    public delegate void KeyHandler();
    public event KeyHandler onJumpButtonPress;
    public event KeyHandler onPauseButtonPress;

    void Update()
    {
        HandleKeys();
    }

    private void HandleKeys()
    {
        if (Input.GetKeyDown(jumpKey))
            onJumpButtonPress?.Invoke();
        if (Input.GetKeyDown(pauseKey))
            onPauseButtonPress?.Invoke();
    }
}
