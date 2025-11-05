using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    public InputReader inputReader;

    public void Start()
    {
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            ChangeJugador(true);
            Debug.Log("Y");
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            ChangeJugador(false);
            Debug.Log("H");
        }
    }

    public void ReiniciarNivel()
    {

    }

    public void ChangeJugador(bool player)
    {
        Player2.SetActive(!player);
        Player1.SetActive(player);

        inputReader.playerController = (player) ? Player1.GetComponent<PlayerController>() : Player2.GetComponent<PlayerController>();
        inputReader.playerHealth = (player) ? Player1.GetComponent<PlayerHealth>() : Player2.GetComponent<PlayerHealth>();
        inputReader.playerShoot = (player) ? Player1.GetComponent<PlayerShoot>() : Player2.GetComponent<PlayerShoot>();
    }
}