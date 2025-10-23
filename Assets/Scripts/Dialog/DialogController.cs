using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    [Header("Referencias del diálogo")]
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private Image dialogImage;

    private void Start()
    {
        // Si no están asignados en el inspector, intenta buscarlos automáticamente
        if (dialogText == null)
            dialogText = GameObject.Find("DialogText")?.GetComponent<TextMeshProUGUI>();

        if (dialogImage == null)
            dialogImage = GameObject.Find("DialogImage")?.GetComponent<Image>();

        // Desactiva ambos al inicio
        if (dialogText != null) dialogText.gameObject.SetActive(false);
        if (dialogImage != null) dialogImage.gameObject.SetActive(false);
    }

    public void Enable()
    {
        if (dialogText != null) dialogText.gameObject.SetActive(true);
        if (dialogImage != null) dialogImage.gameObject.SetActive(true);
    }

    public void Disable()
    {
        if (dialogText != null) dialogText.gameObject.SetActive(false);
        if (dialogImage != null) dialogImage.gameObject.SetActive(false);
    }

    public void ChangeText(string newText)
    {
        if (dialogText != null)
            dialogText.text = newText;
        else
            Debug.LogWarning("No hay TextMeshPro asignado al DialogController.");
    }
}