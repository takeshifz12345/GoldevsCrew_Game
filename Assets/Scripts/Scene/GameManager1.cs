using Unity.VisualScripting;
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
        switch (level)
        {
            case 1:
                if (spawnPoint2.GetComponent<StageController>().triggered)
                {
                    spawnTrigger2.GetComponent<Lvl1_Stage7>().triggered = false;
                    jugador.transform.position = spawnPoint2.transform.position;
                    cam6.GetComponent<CameraTrigger>().ActivateThisCamera();
                    spawnTrigger2.GetComponent<Lvl1_Stage7>().enemigo.GetComponent<EnemyStatus>().ResetHealth();
                    spawnTrigger2.GetComponent<Lvl1_Stage7>().desactivar();
                }
                else if (spawnPoint1.GetComponent<StageController>().triggered)
                {
                    jugador.transform.position = spawnPoint1.transform.position;
                    spawnTrigger1.GetComponent<StageController>().triggered = false;
                    cam3.GetComponent<CameraTrigger>().ActivateThisCamera();
                    spawnTrigger1.GetComponent<Lvl1_Stage4>().enemigo.GetComponent<EnemyStatus>().ResetHealth();
                    spawnTrigger1.GetComponent<Lvl1_Stage4>().TerminarStage();
                }
                else
                {
                    jugador.transform.position = new Vector3(0f, 0f, 0f);
                    cam1.GetComponent<CameraTrigger>().ActivateThisCamera();
                }
                break;
            case 2:
                if (spawnPoint2.GetComponent<StageController>().triggered)
                {
                    spawnTrigger2.GetComponent<Lvl2_Stage7>().triggered = false;
                    jugador.transform.position = spawnPoint2.transform.position;
                    cam6.GetComponent<CameraTrigger>().ActivateThisCamera();
                    spawnTrigger2.GetComponent<Lvl2_Stage7>().enemigo.GetComponent<EnemyStatus>().ResetHealth();
                    spawnTrigger2.GetComponent<Lvl2_Stage7>().desactivar();
                }
                else
                {
                    jugador.transform.position = spawnPoint1.transform.position;
                    spawnTrigger1.GetComponent<Lvl2_Stage4>().triggered = false;
                    cam3.GetComponent<CameraTrigger>().ActivateThisCamera();
                    spawnTrigger1.GetComponent<Lvl2_Stage4>().enemigo.GetComponent<EnemyStatus>().ResetHealth();
                    spawnTrigger1.GetComponent<Lvl2_Stage4>().TerminarStage();
                }
                break;
        }

        jugador.GetComponent<PlayerHealth>().currentHealth = jugador.GetComponent<PlayerHealth>().maxHealth;
        jugador.GetComponent<PlayerHealth>().healCooldownTimer = 0;

        DestroyBullets();

        canvasGameOver.SetActive(false);

        Time.timeScale = 1f;
    }

    public void DestroyBullets()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");

        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }

        GameObject[] enemyAttacks = GameObject.FindGameObjectsWithTag("EnemyAttack");

        foreach (GameObject enemyAttack in enemyAttacks)
        {
            Destroy(enemyAttack);
        }
    }
}