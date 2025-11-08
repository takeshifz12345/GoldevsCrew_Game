using UnityEngine;
using UnityEngine.UI;

public class Creditos : MonoBehaviour
{
    public Button entrarCreditos;
    public Button salirCreditos;
    public Canvas creditos;

    void Start()
    {
        entrarCreditos.onClick.AddListener(EntrarCreditos);

        salirCreditos.onClick.AddListener(SalirCreditos);
    }



    public void EntrarCreditos()
    {
        creditos.enabled = true;

    }
    public void SalirCreditos() {
        creditos.enabled = false;
    }



}