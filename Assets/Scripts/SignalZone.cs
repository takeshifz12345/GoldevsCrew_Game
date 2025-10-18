using UnityEngine;

public class SignalZone : MonoBehaviour
{
    public int signalValue;
    public int signalValueCurrent;

    private PlayerHealth playerInside; // Referencia al jugador dentro del trigger

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = other.GetComponent<PlayerHealth>();
            if (playerInside != null)
            {
                playerInside.UpdateSignal(signalValueCurrent);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = null; // El jugador salió
        }
    }

    public void ChangeState()
    {
        if (signalValueCurrent == 0)
        {
            signalValueCurrent = signalValue;
        }
        else
        {
            signalValueCurrent = 0;
        }

        // Si hay un jugador dentro, actualizar su señal
        if (playerInside != null)
        {
            playerInside.UpdateSignal(signalValueCurrent);
        }
    }

    public void Enable()
    {
        signalValueCurrent = signalValue;

        // Si hay un jugador dentro, actualizar su señal
        if (playerInside != null)
        {
            playerInside.UpdateSignal(signalValueCurrent);
        }
    }

    void Start()
    {
        signalValueCurrent = signalValue;
    }
}
