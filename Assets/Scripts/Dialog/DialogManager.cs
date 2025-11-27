using System;
using System.Collections;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;

    private Coroutine dialogCoroutine;
    private Action onComplete;

    private string[] currentLines;
    private float[] currentTimes;

    private int spriteToUse = 0;

    private bool skipLine = false;

    public DialogController dialogController;
    public InputReader inputReader;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        if (dialogController == null) dialogController = FindAnyObjectByType<DialogController>();
        if (inputReader == null) inputReader = FindAnyObjectByType<InputReader>();
    }

    public void StartDialog(string[] lines, float[] times, Action complete, int sprite = 0)
    {
        StopCurrentDialog();

        currentLines = lines;
        currentTimes = times;
        onComplete = complete;
        spriteToUse = sprite;

        dialogCoroutine = StartCoroutine(DialogRoutine());
    }

    /// <summary>
    /// Salta solo la línea actual.
    /// </summary>
    public void SkipLine()
    {
        skipLine = true;
    }

    private void StopCurrentDialog()
    {
        if (dialogCoroutine != null)
        {
            StopCoroutine(dialogCoroutine);
            dialogCoroutine = null;
        }
    }

    private IEnumerator DialogRoutine()
    {
        dialogController?.Enable(spriteToUse);
        inputReader?.DisableInput();

        for (int i = 0; i < currentLines.Length; i++)
        {
            dialogController?.ChangeText(currentLines[i]);

            float timer = 0f;
            skipLine = false;

            while (timer < currentTimes[i] && !skipLine)
            {
                timer += Time.deltaTime;
                yield return null;
            }
        }

        dialogController?.Disable();
        inputReader?.EnableInput();
        onComplete?.Invoke();

        dialogCoroutine = null;
    }
}
