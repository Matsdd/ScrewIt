// SceneManagement.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("StartGame"); // Replace "MainMenu" with the name of your main menu scene
    }
}
