using UnityEngine;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{
    public Camera cam1;
    public Button button;
    public GameObject spawnPoint1;
    public GameObject spawnTrigger1;
    public GameObject spawnPoint2;
    public GameObject spawnTrigger2;
    public Camera cam3;
    public Camera cam6;
    public GameObject jugador;
    public GameObject canvasGameOver;

    void Start()
    {
        cam1.enabled = true;
        button.onClick.AddListener(Reiniciar);
    }

    private void Reiniciar()
    {
        if (spawnPoint2.GetComponent<SimpleStage>().triggered)
        {
            spawnTrigger2.GetComponent<Lvl1_Stage7>().triggered = false;
            jugador.transform.position = spawnPoint2.transform.position;
            cam6.GetComponent<CameraTrigger>().ActivateThisCamera();
            spawnTrigger2.GetComponent<Lvl1_Stage7>().enemigo.GetComponent<EnemyStatus>().currentHealth = spawnTrigger2.GetComponent<Lvl1_Stage7>().enemigo.GetComponent<EnemyStatus>().maxHealth;
            spawnTrigger2.GetComponent<Lvl1_Stage7>().desactivar();
        }
        else
        {
            jugador.transform.position = spawnPoint1.transform.position;
            spawnTrigger1.GetComponent<Lvl1_Stage4>().triggered = false;
            cam3.GetComponent<CameraTrigger>().ActivateThisCamera();
            spawnTrigger1.GetComponent<Lvl1_Stage4>().enemigo.GetComponent<EnemyStatus>().currentHealth = spawnTrigger1.GetComponent<Lvl1_Stage4>().enemigo.GetComponent<EnemyStatus>().maxHealth;
            spawnTrigger1.GetComponent<Lvl1_Stage4>().TerminarStage();
        }


        jugador.GetComponent<PlayerHealth>().currentHealth = jugador.GetComponent<PlayerHealth>().maxHealth;
        jugador.GetComponent<PlayerHealth>().healCooldownTimer = 0;

        canvasGameOver.SetActive(false);

        Time.timeScale = 1f;
    }
}