using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Transform mainMenu;
    [SerializeField] private Transform levelMenu;

    private void Start()
    {
        mainMenu.gameObject.SetActive(true);
        levelMenu.gameObject.SetActive(false);

        Time.timeScale = 1;
        Cursor.visible = true;
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