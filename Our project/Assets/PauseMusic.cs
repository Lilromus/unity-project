using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isPaused = false;
    private AudioSource backgroundMusic;

    // Make the method public
    public void ResumeMusic()
    {
        if (!backgroundMusic.isPlaying)
        {
            backgroundMusic.UnPause();
            isPaused = false;
        }
    }

    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check for input or any other conditions to toggle pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        if (isPaused)
        {
            ResumeMusic();
        }
        else
        {
            PauseMusic();
        }
    }

    void PauseMusic()
    {
        if (backgroundMusic.isPlaying)
        {
            backgroundMusic.Pause();
            isPaused = true;
        }
    }
}
