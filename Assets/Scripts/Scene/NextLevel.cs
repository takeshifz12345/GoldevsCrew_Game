using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
    public Button boton; // Aquí arrastrarás tu botón desde el Inspector

    void Start()
    {
        boton.onClick.AddListener(nextLevel);
    }

    public void nextLevel()
    {
        Time.timeScale = 1f; // Reanudar el tiempo en caso de estar pausado
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //carga la siguiente escena
    }
}
