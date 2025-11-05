using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public Sprite[] sprite;

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
        SetActive(false, 0);
    }

    /// <summary>
    /// Activa el diálogo
    /// </summary>
    public void Enable(int sprite) => SetActive(true, sprite);

    /// <summary>
    /// Desactiva el diálogo
    /// </summary>
    public void Disable() => SetActive(false, 0);

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
    private void SetActive(bool value, int spriteValue)
    {
        if (dialogText != null) dialogText.gameObject.SetActive(value);
        if (dialogImage != null) dialogImage.gameObject.SetActive(value);
        if (dialogProfile != null) dialogProfile.gameObject.SetActive(value);

        dialogProfile.sprite = sprite[spriteValue];
    }

    public void ChangeProfile(int spriteValue)
    {
        if (dialogProfile != null)
            dialogProfile.sprite = sprite[spriteValue];
        else
            Debug.LogWarning("DialogController: No hay Image asignado para el perfil.");
    }
}