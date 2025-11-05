using UnityEngine;

public class Level3_Trigger1 : MonoBehaviour
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
                GameManager.ChangeJugador(false);

                wall.SetActive(true);

                triggered = true;
            }
        }
    }
}
