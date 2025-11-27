using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogController : MonoBehaviour
{
    public Sprite[] sprite;

    [Header("Referencias del diálogo")]
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private Image dialogImage;
    [SerializeField] private Image dialogProfile;

    public GameObject mobile;

    // Internos del texto y tipeo
    private bool isTyping;
    private string fullText;
    private Coroutine typingCoroutine;

    // Internos del flujo de diálogo
    private string[] lines;
    private int currentLine = 0;
    private Coroutine lineFlowCoroutine;
    private bool waitingNextLine;

    private void Awake()
    {
        dialogText ??= GameObject.Find("DialogText")?.GetComponent<TextMeshProUGUI>();
        dialogImage ??= GameObject.Find("DialogImage")?.GetComponent<Image>();
        dialogProfile ??= GameObject.Find("DialogProfile")?.GetComponent<Image>();

        if (dialogText == null || dialogImage == null || dialogProfile == null)
            Debug.LogError("DialogController: Falta asignar referencias de UI.");

        ToggleUI(false);
    }

    // ===================== MÉTODOS PÚBLICOS (NO TOCAR) =====================

    public void Enable(int spriteIndex)
    {
        ToggleUI(true);
        ChangeProfile(spriteIndex);
    }

    public void Disable()
    {
        if (lineFlowCoroutine != null)
            StopCoroutine(lineFlowCoroutine);

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        ToggleUI(false);
    }

    public void ChangeText(string newText)
    {
        if (dialogText == null)
        {
            Debug.LogWarning("DialogController: No hay TextMeshPro asignado.");
            return;
        }

        fullText = newText;

        // Lanzamos typeo instantáneo (speed = 0)
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeText(newText, 0f));
    }

    public void ChangeProfile(int spriteIndex)
    {
        if (dialogProfile != null)
        {
            if (spriteIndex >= 0 && spriteIndex < sprite.Length)
                dialogProfile.sprite = sprite[spriteIndex];
            else
                Debug.LogWarning("DialogController: índice de sprite fuera de rango.");
        }
        else
        {
            Debug.LogWarning("DialogController: No hay Image asignado para el perfil.");
        }
    }

    // ===================== NUEVO: INICIAR DIÁLOGO DE VARIAS LÍNEAS =====================

    public void StartDialog(string[] dialogLines)
    {
        lines = dialogLines;
        currentLine = 0;

        if (lineFlowCoroutine != null)
            StopCoroutine(lineFlowCoroutine);

        lineFlowCoroutine = StartCoroutine(LineFlow());
    }

    // ===================== CORRUTINA DEL FLUJO =====================

    private IEnumerator LineFlow()
    {
        while (currentLine < lines.Length)
        {
            // Mostrar esta línea
            ChangeText(lines[currentLine]);

            // Espera entre líneas antes de avanzar
            waitingNextLine = true;
            float delay = 5f;

            float t = 0f;
            while (t < delay && waitingNextLine)
            {
                t += Time.deltaTime;
                yield return null;
            }

            waitingNextLine = false;
            currentLine++;
        }

        // Se acabaron las líneas ? cerrar
        Disable();
    }

    // ===================== TYPEO =====================

    private IEnumerator TypeText(string txt, float speed)
    {
        isTyping = true;
        dialogText.text = "";

        foreach (char c in txt)
        {
            dialogText.text += c;

            if (speed > 0f)
                yield return new WaitForSeconds(speed);
            else
                yield return null;
        }

        isTyping = false;
    }

    // ===================== BOTÓN SKIP =====================

    public void Skip()
    {
        // 1. Si está tipeando ? completar texto
        if (isTyping)
        {
            if (typingCoroutine != null)
                StopCoroutine(typingCoroutine);

            dialogText.text = fullText;
            isTyping = false;
            return;
        }

        // 2. Si está en la espera ? avanzar YA
        if (waitingNextLine)
        {
            waitingNextLine = false;
            return;
        }

        // 3. Si ya no hay más líneas ? cerrar
        if (currentLine >= lines.Length)
        {
            Disable();
            return;
        }
    }

    // ===================== UTILIDAD =====================

    private void ToggleUI(bool value)
    {
        if (dialogText != null) dialogText.gameObject.SetActive(value);
        if (dialogImage != null) dialogImage.gameObject.SetActive(value);
        if (dialogProfile != null) dialogProfile.gameObject.SetActive(value);

        if (mobile != null)
            mobile.GetComponent<CanvasVisibility>().SetEnable(!value);
    }
}
