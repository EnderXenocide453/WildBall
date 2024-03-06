using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuController : MonoBehaviour
{
    [SerializeField] private Transform gameMenu;
    [SerializeField] private Transform winPanel;

    private bool _canPause = true;
    private bool _paused = false;

    private void Start()
    {
        gameMenu.gameObject.SetActive(false);
        Time.timeScale = 1;

        InputManager.onPauseButtonPress += TogglePause;
    }

    private void OnDestroy()
    {
        InputManager.onPauseButtonPress -= TogglePause;
    }

    public void TogglePause()
    {
        if (!_canPause)
            return;

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

    public void EndGame()
    {
        _canPause = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;

        winPanel.gameObject.SetActive(true);
    }
}