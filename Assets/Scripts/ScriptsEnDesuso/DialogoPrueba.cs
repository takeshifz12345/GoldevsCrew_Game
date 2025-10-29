using UnityEngine;

public class DialogoPrueba : MonoBehaviour
{
    public DialogController dialogController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogController.Enable(0);
            dialogController.ChangeText("Hola, tonoto");
            Invoke(nameof(DisableDialog), 2f);
        }
    }

    private void DisableDialog()
    {
        dialogController.Disable();
    }
}