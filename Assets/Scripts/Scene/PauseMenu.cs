using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Canvas pauseMenu;
    public Button boton;
    public MusicController music;

    private void Start()
    {
        boton.onClick.AddListener(Resume);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.enabled = true;

        music.Pause();
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.enabled = false;

        music.Resume();

    }
}