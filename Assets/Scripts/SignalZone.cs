using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SignalZone : MonoBehaviour
{
    [Header("Valores de señal")]
    public int signalValue = 1;
    private int signalValueCurrent;

    private PlayerHealth playerInside; // Referencia al jugador dentro del trigger

    private void Awake()
    {
        signalValueCurrent = signalValue;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInside = other.GetComponent<PlayerHealth>();
        UpdatePlayerSignal();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInside = null; // El jugador salió
    }

    /// <summary>
    /// Alterna el estado de la señal entre 0 y el valor máximo
    /// </summary>
    public void ChangeState()
    {
        signalValueCurrent = (signalValueCurrent == 0) ? signalValue : 0;
        UpdatePlayerSignal();
    }

    /// <summary>
    /// Activa la señal con su valor máximo
    /// </summary>
    public void Enable()
    {
        signalValueCurrent = signalValue;
        UpdatePlayerSignal();
    }

    /// <summary>
    /// Actualiza la señal del jugador si hay uno dentro
    /// </summary>
    private void UpdatePlayerSignal()
    {
        playerInside?.UpdateSignal(signalValueCurrent);
    }
}