using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0f;
        Debug.Log("Juego pausado");
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        Debug.Log("Juego reanudado");
    }
}