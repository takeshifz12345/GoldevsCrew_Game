using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    public Button exitButton; // Aquí asignas tu botón "Salir"

    void Start()
    {
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(QuitGame);
        }
        else
        {
            Debug.LogWarning("No se asignó el botón SALIR en el Inspector.");
        }
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");

        // Salida en compilado
        Application.Quit();

        // Salida en el editor (solo para pruebas)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

