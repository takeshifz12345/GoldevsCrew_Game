using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenMenu : MonoBehaviour
{
    public Button boton; // Aquí arrastrarás tu botón desde el Inspector

    void Start()
    {
        boton.onClick.AddListener(GoToMenu);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0); // Cargar la escena del menú (índice 0)
    }
}
