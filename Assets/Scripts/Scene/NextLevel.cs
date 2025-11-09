using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //carga la siguiente escena

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(nextSceneIndex);
            string sceneName = Path.GetFileNameWithoutExtension(scenePath);

            LevelLoader.LoadLevel(sceneName);
        }
    }
}
