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
    public int level;

    void Start()
    {
        cam1.enabled = true;
        button.onClick.AddListener(Reiniciar);
        Debug.Log("0");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Reiniciar();
        }
    }

    private void Reiniciar()
    {
        Debug.Log("1");
        switch (level)
        {
            case 1:
                Debug.Log("2");
                if (spawnPoint2.GetComponent<SimpleStage>().triggered)
                {
                    Debug.Log("3");
                    spawnTrigger2.GetComponent<Lvl1_Stage7>().triggered = false;
                    jugador.transform.position = spawnPoint2.transform.position;
                    cam6.GetComponent<CameraTrigger>().ActivateThisCamera();
                    spawnTrigger2.GetComponent<Lvl1_Stage7>().enemigo.GetComponent<EnemyStatus>().currentHealth = spawnTrigger2.GetComponent<Lvl1_Stage7>().enemigo.GetComponent<EnemyStatus>().maxHealth;
                    spawnTrigger2.GetComponent<Lvl1_Stage7>().desactivar();
                }
                else
                {
                    Debug.Log("4");
                    jugador.transform.position = spawnPoint1.transform.position;
                    spawnTrigger1.GetComponent<Lvl1_Stage4>().triggered = false;
                    cam3.GetComponent<CameraTrigger>().ActivateThisCamera();
                    spawnTrigger1.GetComponent<Lvl1_Stage4>().enemigo.GetComponent<EnemyStatus>().currentHealth = spawnTrigger1.GetComponent<Lvl1_Stage4>().enemigo.GetComponent<EnemyStatus>().maxHealth;
                    spawnTrigger1.GetComponent<Lvl1_Stage4>().TerminarStage();
                }
                break;
            case 2:
                Debug.Log("4");
                if (spawnPoint2.GetComponent<SimpleStage>().triggered)
                {
                    Debug.Log("5");
                    spawnTrigger2.GetComponent<Lvl2_Stage7>().triggered = false;
                    jugador.transform.position = spawnPoint2.transform.position;
                    cam6.GetComponent<CameraTrigger>().ActivateThisCamera();
                    spawnTrigger2.GetComponent<Lvl2_Stage7>().enemigo.GetComponent<EnemyStatus>().currentHealth = spawnTrigger2.GetComponent<Lvl2_Stage7>().enemigo.GetComponent<EnemyStatus>().maxHealth;
                    spawnTrigger2.GetComponent<Lvl2_Stage7>().desactivar();
                }
                else
                {
                    Debug.Log("6");
                    jugador.transform.position = spawnPoint1.transform.position;
                    spawnTrigger1.GetComponent<Lvl2_Stage4>().triggered = false;
                    cam3.GetComponent<CameraTrigger>().ActivateThisCamera();
                    spawnTrigger1.GetComponent<Lvl2_Stage4>().enemigo.GetComponent<EnemyStatus>().currentHealth = spawnTrigger1.GetComponent<Lvl2_Stage4>().enemigo.GetComponent<EnemyStatus>().maxHealth;
                    spawnTrigger1.GetComponent<Lvl2_Stage4>().TerminarStage();
                }
                break;
        }

        Debug.Log("7");
        jugador.GetComponent<PlayerHealth>().currentHealth = jugador.GetComponent<PlayerHealth>().maxHealth;
        jugador.GetComponent<PlayerHealth>().healCooldownTimer = 0;

        canvasGameOver.SetActive(false);

        Time.timeScale = 1f;
    }
}