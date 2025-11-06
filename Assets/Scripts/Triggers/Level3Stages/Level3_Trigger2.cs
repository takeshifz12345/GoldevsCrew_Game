using UnityEngine;

public class Level3_Trigger2 : MonoBehaviour
{
    public GameManager2 GameManager;
    public GameObject wall;

    public bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameManager.ChangeJugador(true);

                wall.SetActive(true);

                triggered = true;
            }
        }
    }
}