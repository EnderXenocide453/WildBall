using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuController : MonoBehaviour
{
    [SerializeField] private Transform gameMenu;

    private bool _paused = false;

    private void Start()
    {
        gameMenu.gameObject.SetActive(false);
        Time.timeScale = 1;

        GetComponent<InputManager>().onPauseButtonPress += TogglePause;
    }

    public void TogglePause()
    {
        Debug.Log("a");

        _paused = !_paused;
        gameMenu.gameObject.SetActive(_paused);

        Cursor.visible = _paused;
        Cursor.lockState = _paused ? CursorLockMode.None : CursorLockMode.Locked;

        Time.timeScale = _paused ? 0 : 1;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLevel(int id)
    {
        if (id >= SceneManager.sceneCountInBuildSettings)
            return;

        SceneManager.LoadScene(id);
    }
}