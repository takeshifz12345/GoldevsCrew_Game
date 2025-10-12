using UnityEngine;

public class SignalZone : MonoBehaviour
{
    public int signalValue;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.UpdateSignal(signalValue);
            }
        }
    }
}