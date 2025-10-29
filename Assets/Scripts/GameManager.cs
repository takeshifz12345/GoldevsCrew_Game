using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Este método se llamará cuando el jugador haga clic en el botón Reiniciar
    public void ReiniciarNivel()
    {
        // Reanuda el tiempo por si está pausado
        Time.timeScale = 1f;

        // Carga nuevamente la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // (Opcional) Método para ir al menú principal si usas el botón "Menú"
    public void IrAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1"); // escribe aquí el nombre exacto de tu escena del menú
    }
}