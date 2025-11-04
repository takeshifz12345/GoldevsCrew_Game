using UnityEngine;

public class Level1Stage2_2 : StageController
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (TriggerStage(other))
        {

            string[] dialog = new string[]
            {
            "PARA SALTAR PULSE ESPACIO O LA TECLA W.",
            "PARA CURARSE PRESIONA LA TECLA Q..",
            "LA VIDA CURADA DEPENDE DE LA SEÑAL QUE SE TENGA.",
            "—Te estaré viendo."
            };

            float[] tiempos = new float[] { 5f, 2f, 2f, 3f };

            StartDialog(dialog, tiempos);
        }
    }
}