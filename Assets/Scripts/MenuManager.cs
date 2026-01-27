using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject MainMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene("Play");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void TrainingMode()
    {
        SceneManager.LoadScene("Training");
    }
}

