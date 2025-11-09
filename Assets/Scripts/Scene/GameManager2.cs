using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager2 : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    public Button button;

    public Camera introCam;

    public InputReader inputReader;

    public DialogController dialogController;

    public Canvas final;

    public Level3_Trigger2 trigger;

    public float SpawnY;
    public float SpawnX1;
    public float SpawnX2;

    public GameObject canvasGameOver;

    public MusicController music;

    public GameObject[] walls;

    public void Start()
    {
        introCam.enabled = true;
        button.onClick.AddListener(Reiniciar);
        IntroLevel3();
    }
    public void Update()
    {

    }

    public void Reiniciar()
    {
        trigger.triggered = false;

        Player1.transform.position = new Vector3(SpawnX1, SpawnY, 0);
        Player2.transform.position = new Vector3(SpawnX2, SpawnY, 0);

        ChangeJugador(true);

        trigger.enemigo.GetComponent<KingStatus>().ResetHealth();
        trigger.Desactivar();

        Player1.GetComponent<PlayerHealth>().currentHealth = Player1.GetComponent<PlayerHealth>().maxHealth;
        Player1.GetComponent<PlayerHealth>().healCooldownTimer = 0;

        Player2.GetComponent<PlayerHealth>().currentHealth = Player2.GetComponent<PlayerHealth>().maxHealth;
        Player2.GetComponent<PlayerHealth>().healCooldownTimer = 0;

        DestroyBullets();

        canvasGameOver.SetActive(false);

        Time.timeScale = 1f;

        music.MuteMusic();

        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].SetActive(false);
        }
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

    public void ChangeJugador(bool player)
    {
        Player2.SetActive(!player);
        Player1.SetActive(player);

        inputReader.playerController = (player) ? Player1.GetComponent<PlayerController>() : Player2.GetComponent<PlayerController>();
        inputReader.playerHealth = (player) ? Player1.GetComponent<PlayerHealth>() : Player2.GetComponent<PlayerHealth>();
        inputReader.playerShoot = (player) ? Player1.GetComponent<PlayerShoot>() : Player2.GetComponent<PlayerShoot>();
    }

    public void IntroLevel3()
    {
        string[] dialog = new string[]
        {
                "",
                "—Había una vez dos niñas que eran inseparables.",
                "—Les encantaba dibujar en las paredes, hablar por teléfonos de latas y mirar las estrellas desde la muralla.",
                "—Pero una noche… algo ocurrió.",
                "—Escuché los gritos de mis subordinados; cada uno traía en brazos a una de las niñas, inconsciente.",
                "—Habían caído de la muralla, y sus rostros…",
                "—…",
                "—Oh…",
                "—Están aquí.",
                ""
        };

        float[] tiempos = new float[] { 0.5f, 5f, 7.5f, 1.5f, 7.5f, 3.5f, 0.5f, 1f, 1.25f, 0.25f };

        StartDialog(dialog, tiempos, () => Empezar());
    }

    public void StartDialog(string[] lines, float[] times, System.Action onComplete = null)
    {
        StartCoroutine(DialogRoutine(lines, times, onComplete));
    }

    public IEnumerator DialogRoutine(string[] lines, float[] times, System.Action onComplete)
    {
        dialogController?.Enable(0);
        inputReader?.DisableInput();

        for (int i = 0; i < lines.Length; i++)
        {
            dialogController?.ChangeText(lines[i]);
            yield return new WaitForSeconds(times[i]);
        }

        dialogController?.Disable();
        inputReader?.EnableInput();
        onComplete?.Invoke();
    }

    public void Empezar()
    {
        ChangeJugador(true);
    }

    public void Final()
    {
        Player2.SetActive(false);
        Player1.SetActive(false);

        final.enabled = true;

        string[] dialog = new string[]
        {
                "",
                "—...",
                "—Saben...",
                "—Las estrellas se ven bonitas...",
                "—Lo... lo siento",
                "—Lo siento por desconectarlas",
                ""
        };

        float[] tiempos = new float[] { 0.5f, 1.5f, 3f, 5f, 3f, 5f, 0.5f };

        StartDialog(dialog, tiempos, () => Creditos());
    }

    public void Creditos()
    {

    }
}