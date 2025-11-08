using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public Canvas canvas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Asegúrate de que tu jugador tenga el tag "Player"
        {
            Time.timeScale = 0f;
            canvas.enabled = true;
        }
    }
}
