using UnityEngine;

public class DialogoPrueba : MonoBehaviour
{
    public DialogController dialogController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisiona");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Colisiona Jugador");
            dialogController.Enable();
            dialogController.ChangeText("Hola, tonoto");
            Invoke("dialogController.Disable", 2f);
        }
    }
}