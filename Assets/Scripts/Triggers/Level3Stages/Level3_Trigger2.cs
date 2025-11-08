using UnityEngine;
using System.Collections;

public class Level3_Trigger2 : MonoBehaviour
{
    public GameManager2 gameManager;
    public GameObject wall;
    public GameObject enemigo;
    public GameObject ataques1;
    public GameObject ataques2;

    [Header("Puntos de spawn de ataques")]
    public float spawnY_A;
    public float spawnY_B;
    public float spawnY_C;

    public float spawnX_L1;
    public float spawnX_L2;

    public float spawnX_R1;
    public float spawnX_R2;

    public float intervaloAtaques;

    public bool triggered = false;

    public bool attackDir = false;

    public int cantidadAtaquesPorLado = 5;

    private Coroutine cicloAtaquesCoroutine;
    public MusicController music;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            gameManager.ChangeJugador(true);
            wall.SetActive(true);

            triggered = true;

            enemigo.GetComponent<EnemyStatus>().Active();
            enemigo.GetComponent<EnemyStatus>().TakeDamage(0);


            //music battle
            music.PlayBattleMusic();

            cicloAtaquesCoroutine = StartCoroutine(CicloAtaques());
        }
    }

    private IEnumerator CicloAtaques()
    {
        while (enemigo != null)
        {
            // Ataques hacia la izquierda
            attackDir = false;
            gameManager.ChangeJugador(!attackDir);
            for (int i = 0; i < cantidadAtaquesPorLado; i++)
            {
                LanzarAtaqueIzquierdaArriba();
                LanzarAtaqueIzquierdaNormal();
                yield return new WaitForSeconds(intervaloAtaques);
            }

            // Ataques hacia la derecha
            attackDir = true;
            gameManager.ChangeJugador(!attackDir);
            for (int i = 0; i < cantidadAtaquesPorLado; i++)
            {
                LanzarAtaqueDerechaArriba();
                LanzarAtaqueDerechaNormal();
                yield return new WaitForSeconds(intervaloAtaques);
            }
        }
    }

    private void LanzarAtaqueIzquierdaArriba()
    {
        float spawnX = Random.Range(spawnX_L1, spawnX_L2);
        Vector2 posSpawn = new(spawnX, spawnY_A);

        GameObject ataqueGO = Instantiate(ataques1, posSpawn, Quaternion.identity);
        EnemyAttack ea = ataqueGO.GetComponent<EnemyAttack>();
        ea.direction = Vector2.down;
        ea.speed = 5f;
        ea.damage = 1;
        ea.lifeTime = 6f;
    }

    private void LanzarAtaqueIzquierdaNormal()
    {
        float spawnY = Random.Range(spawnY_B, spawnY_C);
        Vector2 posSpawn = new(spawnX_L2, spawnY);

        GameObject ataqueGO = Instantiate(ataques1, posSpawn, Quaternion.identity);
        EnemyAttack ea = ataqueGO.GetComponent<EnemyAttack>();
        ea.direction = Vector2.left;
        ea.speed = 5f;
        ea.damage = 1;
        ea.lifeTime = 30f;
    }

    private void LanzarAtaqueDerechaArriba()
    {
        float spawnX = Random.Range(spawnX_R1, spawnX_R2);
        Vector2 posSpawn = new(spawnX, spawnY_A);

        GameObject ataqueGO = Instantiate(ataques2, posSpawn, Quaternion.identity);
        EnemyAttack ea = ataqueGO.GetComponent<EnemyAttack>();
        ea.direction = Vector2.down;
        ea.speed = 5f;
        ea.damage = 1;
        ea.lifeTime = 6f;
    }

    private void LanzarAtaqueDerechaNormal()
    {
        float spawnY = Random.Range(spawnY_B, spawnY_C);
        Vector2 posSpawn = new(spawnX_R2, spawnY);

        GameObject ataqueGO = Instantiate(ataques2, posSpawn, Quaternion.identity);
        EnemyAttack ea = ataqueGO.GetComponent<EnemyAttack>();
        ea.direction = Vector2.right;
        ea.speed = 5f;
        ea.damage = 1;
        ea.lifeTime = 30f;
    }

    private void Update()
    {
        if (enemigo == null && triggered)
        {
            Desactivar();
            Destroy(this);
        }
    }

    private void Desactivar()
    {
        if (cicloAtaquesCoroutine != null)
        {
            StopCoroutine(cicloAtaquesCoroutine);
            cicloAtaquesCoroutine = null;
        }
    }
}