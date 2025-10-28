using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    [Header("Referencias del diálogo")]
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private Image dialogImage;
    [SerializeField] private Image dialogProfile;

    private void Awake()
    {
        // Busca automáticamente solo si no se asignó en el inspector
        dialogText ??= GameObject.Find("DialogText")?.GetComponent<TextMeshProUGUI>();
        dialogImage ??= GameObject.Find("DialogImage")?.GetComponent<Image>();
        dialogProfile ??= GameObject.Find("DialogProfile")?.GetComponent<Image>();

        // Desactiva ambos al inicio
        SetActive(false);
    }

    /// <summary>
    /// Activa el diálogo
    /// </summary>
    public void Enable() => SetActive(true);

    /// <summary>
    /// Desactiva el diálogo
    /// </summary>
    public void Disable() => SetActive(false);

    /// <summary>
    /// Cambia el texto del diálogo
    /// </summary>
    public void ChangeText(string newText)
    {
        if (dialogText != null)
            dialogText.text = newText;
        else
            Debug.LogWarning("DialogController: No hay TextMeshPro asignado.");
    }

    /// <summary>
    /// Activa o desactiva ambos elementos
    /// </summary>
    private void SetActive(bool value)
    {
        if (dialogText != null) dialogText.gameObject.SetActive(value);
        if (dialogImage != null) dialogImage.gameObject.SetActive(value);
        if (dialogProfile != null) dialogProfile.gameObject.SetActive(value);
    }
}