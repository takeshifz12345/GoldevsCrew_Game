using System.Threading;
using UnityEditor;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource? backgroundMusic;
    public AudioSource? battleMusic;
    public string state;

    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.enabled = true;
        }
        if (battleMusic != null)
        {
            battleMusic.enabled = false;
        }

        state = "background";

    }

    public void PlayBattleMusic()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.enabled = false;
        }
        if (battleMusic != null)
        {
            battleMusic.enabled = true;
            battleMusic.Play();
        }

        state = "battle";
    }

    public void MuteMusic()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.enabled = false;
        }
        if (battleMusic != null)
        {
            battleMusic.enabled = false;
        }

        state = "mute";

    }

    public void Resume()
    {
        if (state == "background")
        {
            PlayBackgroundMusic();
        }
        else if (state == "battle")
        {
            PlayBattleMusic();
        }
    }

    public void Pause()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.enabled = false;
        }
        if (battleMusic != null)
        {
            battleMusic.enabled = false;
        }
    }
}