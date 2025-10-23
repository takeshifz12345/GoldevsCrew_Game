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
            dialogController.Enable();
            Dialogo1();

            Invoke(nameof(Dialogo2), 5f);
            Invoke(nameof(Dialogo3), 7f);
            Invoke(nameof(Dialogo4), 9f);
            Invoke(nameof(FinalizarDialogo), 12f);
        }
    }

    private void Dialogo1()
    {
        dialogController.ChangeText("Por si acaso, no pude quitar el desastre que tú y tu amiga hicieron en la pared.");
    }

    private void Dialogo2()
    {
        dialogController.ChangeText("Jester se quedó sin pintura amarilla.");
    }

    private void Dialogo3()
    {
        dialogController.ChangeText("No salgas de esta habitación.");
    }

    private void Dialogo4()
    {
        dialogController.ChangeText("Te estaré viendo.");
    }

    private void FinalizarDialogo()
    {
        dialogController.Disable();
        inputReader.EnableInput();

        // Si quieres, puedes desactivar este objeto después de reproducir el diálogo:
        // gameObject.SetActive(false);
    }
}