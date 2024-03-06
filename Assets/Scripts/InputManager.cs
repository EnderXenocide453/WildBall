using UnityEngine;

public class InputManager : MonoBehaviour
{
    public const string HorizontalAxis = "Horizontal";
    public const string ForwardAxis = "Vertical";

    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode pauseKey = KeyCode.Escape;
    [SerializeField] private KeyCode interactKey = KeyCode.E;

    public static InputManager instance = null;

    public static Vector3 axis { get; private set; }

    public delegate void KeyHandler();

    public static event KeyHandler onJumpButtonPress;

    public static event KeyHandler onPauseButtonPress;

    public static event KeyHandler onInteractButtonPress;

    private void Awake()
    {
        //Если ссылка ещё не назначена, назначаем
        if (instance == null) {
            instance = this;
        }
    }

    private void Update()
    {
        HandleKeys();
        UpdateAxis();
    }

    private void HandleKeys()
    {
        if (Input.GetKeyDown(jumpKey))
            onJumpButtonPress?.Invoke();
        if (Input.GetKeyDown(pauseKey))
            onPauseButtonPress?.Invoke();
        if (Input.GetKeyDown(interactKey))
            onInteractButtonPress?.Invoke();
    }

    private void UpdateAxis()
    {
        axis = new Vector3(Input.GetAxis(HorizontalAxis), 0, Input.GetAxis(ForwardAxis));
    }
}