using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] Transform mainMenu;
    [SerializeField] Transform levelMenu;

    private void Start()
    {
        mainMenu.gameObject.SetActive(true);
        levelMenu.gameObject.SetActive(false);
    }

    public void ChangeMenu()
    {
        mainMenu.gameObject.SetActive(!mainMenu.gameObject.activeInHierarchy);
        levelMenu.gameObject.SetActive(!mainMenu.gameObject.activeInHierarchy);
    }

    public void LoadLevel(int id)
    {
        if (id >= SceneManager.sceneCountInBuildSettings)
            return;

        SceneManager.LoadScene(id);
    }
}
