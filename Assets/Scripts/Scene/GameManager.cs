using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Camera cam1;
    public Button button;
    public GameObject punto3;
    public GameObject punto4;
    public GameObject punto7;
    public Camera cam3;
    public Camera cam4;
    public GameObject jugador;
    public GameObject canvasGameOver;

    void Start()
    {
        cam1.enabled = true;
        button.onClick.AddListener(Reiniciar);
    }

    private void Reiniciar()
    {
        if (punto4.GetComponent<Level1Stage4>().flag)
        {
            jugador.transform.position = punto3.transform.position;
            punto4.GetComponent<Level1Stage4>().flag = false;
            cam3.GetComponent<CameraTrigger>().ActivateThisCamera();
            punto4.GetComponent<Level1Stage4>().enemigo.GetComponent<EnemyStatus>().currentHealth = punto4.GetComponent<Level1Stage4>().enemigo.GetComponent<EnemyStatus>().maxHealth;
        }
        else
        {
            if (punto7.GetComponent<BossBattle1>().flag)
            {
                punto7.GetComponent<BossBattle1>().flag = false;
                jugador.transform.position = punto4.transform.position;
                cam4.GetComponent<CameraTrigger>().ActivateThisCamera();
                punto7.GetComponent<BossBattle1>().enemigo.GetComponent<EnemyStatus>().currentHealth = punto7.GetComponent<BossBattle1>().enemigo.GetComponent<EnemyStatus>().maxHealth;
            }
        }

        jugador.GetComponent<PlayerHealth>().currentHealth = jugador.GetComponent<PlayerHealth>().maxHealth;
        jugador.GetComponent<PlayerHealth>().healCooldownTimer = 0;

        canvasGameOver.SetActive(false);

        Time.timeScale = 1f;
    }
}