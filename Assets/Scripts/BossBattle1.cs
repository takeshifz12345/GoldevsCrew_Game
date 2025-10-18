using System.Collections;
using UnityEngine;

public class BossBattle1 : MonoBehaviour
{
    public bool flag = false;
    public GameObject ataques1;
    public GameObject ataques2;
    public float spawnXADown; //valor mínimo de la posición x posible de los ataques abajo
    public float spawnXBDown; //valor máximo de la posición x posible de los ataques abajo
    public float spawnYDown; //posición y de ataques abajo
    public float spawnYALeft; //valor mínimo de la posición y posible de los ataques abajo
    public float spawnYBLeft; //valor máximo de la posición y posible de los ataques abajo
    public float spawnXLeft; //posición x de ataques abajo
    public float intervaloAtaques = 1f;

    public SignalZone zona1;
    public SignalZone zona2;
    public SignalZone zona3;

    public EyeManager ojo1;
    public EyeManager ojo2;
    public EyeManager ojo3;
    public GameObject enemigo;
    public GameObject canvas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !flag)
        {
            flag = true;
            Inicio();
            canvas.SetActive(true);

            enemigo.GetComponent<EnemyStatus>().active = true;
        }
    }

    private void Inicio()
    {
        StartCoroutine(LanzarAtaquesAbajo());
    }

    private IEnumerator LanzarAtaquesAbajo()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                float spawnX = Random.Range(spawnXADown, spawnXBDown);
                Vector2 posSpawn = new Vector2(spawnX, spawnYDown);

                GameObject ataqueGO = Instantiate(ataques2, posSpawn, Quaternion.identity);

                EnemyAttack enemyAttack = ataqueGO.GetComponent<EnemyAttack>();
                enemyAttack.direction = Vector2.down;
                enemyAttack.speed = 5f;
                enemyAttack.damage = 2;
                enemyAttack.lifeTime = 3f;
            }
            yield return new WaitForSeconds(intervaloAtaques);
        }

        StartCoroutine(LanzarAtaquesIzquierda());
    }

    private IEnumerator LanzarAtaquesIzquierda()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                float spawnY = Random.Range(spawnYALeft, spawnYBLeft);
                Vector2 posSpawn = new Vector2(spawnXLeft, spawnY);

                GameObject ataqueGO = Instantiate(ataques2, posSpawn, Quaternion.identity);

                EnemyAttack enemyAttack = ataqueGO.GetComponent<EnemyAttack>();
                enemyAttack.direction = Vector2.left;
                enemyAttack.speed = 5f;
                enemyAttack.damage = 2;
                enemyAttack.lifeTime = 3f;
            }
            yield return new WaitForSeconds(intervaloAtaques);
        }

        CambiarEstadosZonas();
    }

    private void CambiarEstadosZonas()
    {
        EyeManager[] ojos = { ojo1, ojo2, ojo3 };
        SignalZone[] zonas = { zona1, zona2, zona3 };

        for (int i = 0; i < ojos.Length; i++)
        {
            // 50% de probabilidad de cambiar estado
            if (Random.value > 0.5f)
            {
                ojos[i].ChangeState();
                zonas[i].ChangeState(); // Cambia el estado de la zona correspondiente
            }
        }

        Inicio();
    }

    void Update()
    {
        if (enemigo == null)
        {
            canvas.SetActive(false);
            ojo1.SetOpen(false);
            ojo2.SetOpen(false);
            ojo3.SetOpen(false);
            zona1.Enable();
            zona2.Enable();
            zona3.Enable();

            Destroy(this);
        }
    }
}
