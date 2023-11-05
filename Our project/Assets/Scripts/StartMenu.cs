using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Levels()
    {
        SceneManager.LoadScene("Select level");
    }
    public void qiutt()
    {
        Application.Quit();
    }
}
