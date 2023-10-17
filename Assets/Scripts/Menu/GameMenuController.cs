using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuController : MonoBehaviour
{
    [SerializeField] Transform gameMenu;

    private bool _paused = false;

    private void Start()
    {
        gameMenu.gameObject.SetActive(false);
    }

    public void TogglePause()
    {
        Debug.Log("a");

        _paused = !_paused;
        gameMenu.gameObject.SetActive(_paused);

        Time.timeScale = _paused ? 0 : 1;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
