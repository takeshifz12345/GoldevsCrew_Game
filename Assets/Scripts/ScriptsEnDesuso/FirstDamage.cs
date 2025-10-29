using System.Collections;
using UnityEngine;

public class FirstDamage : MonoBehaviour
{
    public float posX;
    public float posY;
    public GameObject ataque;
    public bool flag = false;
    public InputReader inputReader;
    public DialogController dialogController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!flag)
            {
                // Desactivar los controles del jugador
                inputReader.DisableInput();

                // Iniciar el diálogo
                dialogController.Enable(0);
                
                Vector2 posSpawn = new Vector2(posX, posY);
                Instantiate(ataque, posSpawn, Quaternion.identity);
                flag = true;

                Dialogo1();

                Invoke(nameof(Dialogo2), 5f);
                Invoke(nameof(Dialogo3), 7f);
                Invoke(nameof(Dialogo4), 9f);
                Invoke(nameof(FinalizarDialogo), 12f);
            }
        }
    }

    private void Dialogo1()
    {
        dialogController.ChangeText("—Por si acaso, no pude quitar el desastre que tú y tu amiga hicieron en la pared.");
    }

    private void Dialogo2()
    {
        dialogController.ChangeText("—Jester se quedó sin pintura amarilla.");
    }

    private void Dialogo3()
    {
        dialogController.ChangeText("—No salgas de esta habitación.");
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