using UnityEngine;

public class DialogStage2 : MonoBehaviour
{
    public DialogController dialogController;
    public InputReader inputReader;

    private bool alreadyTriggered = false; // evita repetir el diálogo

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !alreadyTriggered)
        {
            alreadyTriggered = true; // marca como ejecutado

            // Desactivar los controles del jugador
            inputReader.DisableInput();

            // Iniciar el diálogo
            dialogController.Enable(0);
            Dialogo1();

            Invoke(nameof(Dialogo2), 5f);
            Invoke(nameof(Dialogo3), 7f);
            Invoke(nameof(Dialogo4), 9f);
            Invoke(nameof(FinalizarDialogo), 12f);
        }
    }

    private void Dialogo1()
    {
        dialogController.ChangeText("PARA SALTAR PULSE ESPACIO O LA TECLA W.");
    }

    private void Dialogo2()
    {
        dialogController.ChangeText("PARA CURARSE PRESIONA LA TECLA Q.");
    }

    private void Dialogo3()
    {
        dialogController.ChangeText("LA VIDA CURADA DEPENDE DE LA SEÑAL QUE SE TENGA.");
    }

    private void Dialogo4()
    {
        dialogController.ChangeText("—Te estaré viendo.");
    }

    private void FinalizarDialogo()
    {
        dialogController.Disable();
        inputReader.EnableInput();
    }
}