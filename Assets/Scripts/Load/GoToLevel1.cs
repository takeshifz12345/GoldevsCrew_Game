using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToLevel1 : MonoBehaviour
{
    [Header("Nombre de la escena a cargar")]
    public string nombreEscena = "Level1";

    void Start()
    {
        // Obtenemos el componente Button del mismo objeto
        Button boton = GetComponent<Button>();

        // Verificamos que exista un componente Button
        if (boton != null)
        {
            // Le decimos qué función ejecutar cuando se haga clic
            boton.onClick.AddListener(Cambiar);
        }
        else
        {
            Debug.LogWarning("El objeto no tiene un componente Button.");
        }
    }

    void Cambiar()
    {
        LevelLoader.LoadLevel(nombreEscena);
    }
}