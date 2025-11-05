using UnityEngine;

public class SimpleStage : StageController
{
    [Header("Configuración de diálogo")]
    [TextArea(2, 5)] public string[] lines;
    [Tooltip("Tiempo entre líneas (en segundos)")]
    public float[] delayBetweenLines;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!TriggerStage(other)) return;

        float[] times = new float[lines.Length];
        for (int i = 0; i < times.Length; i++)
            times[i] = delayBetweenLines[i];

        StartDialog(lines, times);
    }
}