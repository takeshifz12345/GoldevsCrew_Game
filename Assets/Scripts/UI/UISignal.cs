using UnityEngine;
using UnityEngine.UI;

public class UISignal : MonoBehaviour
{
    [Header("Imágenes del indicador")]
    public Image[] signalImages; // tamaño 3

    [Header("Sprites por nivel de señal (0–3)")]
    public Sprite[] signalSpritesLevel0; // tamaño 3
    public Sprite[] signalSpritesLevel1; // tamaño 3
    public Sprite[] signalSpritesLevel2; // tamaño 3
    public Sprite[] signalSpritesLevel3; // tamaño 3

    public void UpdateSignalUI(int signal)
    {
        Sprite[][] levels =
        {
            signalSpritesLevel0,
            signalSpritesLevel1,
            signalSpritesLevel2,
            signalSpritesLevel3
        };

        if (signal < 0 || signal >= levels.Length)
        {
            Debug.LogWarning($"Nivel de señal fuera de rango: {signal}");
            return;
        }

        for (int i = 0; i < signalImages.Length; i++)
        {
            signalImages[i].sprite = levels[signal][i];
        }
    }
}