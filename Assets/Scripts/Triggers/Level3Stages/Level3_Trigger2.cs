using UnityEngine;
using System.Collections;

public class Level3_Trigger2 : MonoBehaviour
{
    public GameManager2 GameManager;
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
    public float spawnX_L3;

    public float spawnX_R1;
    public float spawnX_R2;
    public float spawnX_R3;

    public float intervaloAtaques;

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

                enemigo.GetComponent<EnemyStatus>().Active();
                enemigo.GetComponent<EnemyStatus>().TakeDamage(0);

                ataqueDownCoroutine = StartCoroutine(LanzarAtaquesAbajo());
                ataqueLeftCoroutine = StartCoroutine(LanzarAtaquesIzquierda());
            }
        }
    }

    private IEnumerator LanzarAtaquesAbajoIzquierda()
    {
        while (enemigo != null)
        {
            float spawnX = Random.Range(spawnX_L1, spawnX_L2);
            Vector2 posSpawn = new(spawnX, spawnY_A);

            GameObject ataqueGO = Instantiate(ataques1, posSpawn, Quaternion.identity);
            EnemyAttack ea = ataqueGO.GetComponent<EnemyAttack>();
            ea.direction = Vector2.down;
            ea.speed = 5f;
            ea.damage = 1;
            ea.lifeTime = 6f;

            yield return new WaitForSeconds(intervaloAtaques);
        }
    }

    private IEnumerator LanzarAtaquesAbajoDerecha()
    {
        while (enemigo != null)
        {
            float spawnX = Random.Range(spawnX_R1, spawnX_R2);
            Vector2 posSpawn = new(spawnX, spawnY_A);

            GameObject ataqueGO = Instantiate(ataques1, posSpawn, Quaternion.identity);
            EnemyAttack ea = ataqueGO.GetComponent<EnemyAttack>();
            ea.direction = Vector2.down;
            ea.speed = 5f;
            ea.damage = 1;
            ea.lifeTime = 6f;

            yield return new WaitForSeconds(intervaloAtaques);
        }
    }

    private IEnumerator LanzarAtaquesIzquierda()
    {
        while (enemigo != null)
        {
            float spawnY = Random.Range(spawnY_B, spawnY_C);
            Vector2 posSpawn = new(spawnX_L3, spawnY);

            GameObject ataqueGO = Instantiate(ataques2, posSpawn, Quaternion.identity);
            EnemyAttack ea = ataqueGO.GetComponent<EnemyAttack>();
            ea.direction = Vector2.left;
            ea.speed = 5f;
            ea.damage = 1;
            ea.lifeTime = 30f;

            yield return new WaitForSeconds(intervaloAtaques);
        }
    }

    private IEnumerator LanzarAtaquesDerecha()
    {
        while (enemigo != null)
        {
            float spawnY = Random.Range(spawnY_B, spawnY_C);
            Vector2 posSpawn = new(spawnX_R3, spawnY);

            GameObject ataqueGO = Instantiate(ataques2, posSpawn, Quaternion.identity);
            EnemyAttack ea = ataqueGO.GetComponent<EnemyAttack>();
            ea.direction = Vector2.right;
            ea.speed = 5f;
            ea.damage = 1;
            ea.lifeTime = 30f;

            yield return new WaitForSeconds(intervaloAtaques);
        }
    }
}