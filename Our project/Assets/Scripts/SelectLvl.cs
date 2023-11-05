using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLvl : MonoBehaviour
{
    public void lvl1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void lvl2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void lvl3()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void lvl4()
    {
        SceneManager.LoadScene("Level 4");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Start Scren");
    }
}
