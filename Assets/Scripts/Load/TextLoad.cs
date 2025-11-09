using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextLoad : MonoBehaviour
{
    private TextMeshProUGUI text;
    private float puntitos = -100f;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        puntitos++;

        if (puntitos > 300f)
        {
            text.text = "Cargando...";

            puntitos = -100f;
        }
        else if (puntitos > 200f)
        {
            text.text = "Cargando..";
        }
        else if (puntitos > 100f)
        {
            text.text = "Cargando.";
        }
        else if (puntitos > 0f)
        {
            text.text = "Cargando";
        }
    }
}