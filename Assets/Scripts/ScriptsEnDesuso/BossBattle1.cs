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

    public GameObject wall;

    public InputReader inputReader;
    public DialogController dialogController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !flag)
        {
            flag = true;

            inputReader.DisableInput();
            dialogController.Enable(0);
            Dialogo1();
            Invoke(nameof(Dialogo2), 5f);
            Invoke(nameof(Dialogo3), 7f);
            Invoke(nameof(Dialogo4), 9f);
            Invoke(nameof(Dialogo5), 5f);
            Invoke(nameof(Dialogo6), 7f);
            Invoke(nameof(Dialogo7), 9f);
            Invoke(nameof(FinalizarDialogo), 12f);
        }
    }

    private void Inicio()
    {
        StartCoroutine(LanzarAtaquesAbajo());
    }

    private IEnumerator LanzarAtaquesAbajo()
    {
        if (flag)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    float spawnX = Random.Range(spawnXADown, spawnXBDown);
                    Vector2 posSpawn = new Vector2(spawnX, spawnYDown);

                    GameObject ataqueGO = Instantiate(ataques2, posSpawn, Quaternion.identity);

                    EnemyAttack enemyAttack = ataqueGO.GetComponent<EnemyAttack>();
                    enemyAttack.direction = Vector2.down;
                    enemyAttack.speed = 5f;
                    enemyAttack.damage = 1;
                    enemyAttack.lifeTime = 6f;
                }
                yield return new WaitForSeconds(intervaloAtaques);
            }

            StartCoroutine(LanzarAtaquesIzquierda());
        }
    }

    private IEnumerator LanzarAtaquesIzquierda()
    {
        if (flag)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    float spawnY = Random.Range(spawnYALeft, spawnYBLeft);
                    Vector2 posSpawn = new Vector2(spawnXLeft, spawnY);

                    GameObject ataqueGO = Instantiate(ataques2, posSpawn, Quaternion.identity);

                    EnemyAttack enemyAttack = ataqueGO.GetComponent<EnemyAttack>();
                    enemyAttack.direction = Vector2.left;
                    enemyAttack.speed = 5f;
                    enemyAttack.damage = 1;
                    enemyAttack.lifeTime = 30f;
                }
                yield return new WaitForSeconds(intervaloAtaques);
            }

            CambiarEstadosZonas();
        }   
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

            wall.SetActive(false);

            Destroy(this);
        }
    }

    private void Dialogo1()
    {
        dialogController.ChangeText("—Me duele ver tu rostro.");
    }

    private void Dialogo2()
    {
        dialogController.ChangeText("—Pero me duele aún más ya no poder hacerlo.");
    }

    private void Dialogo3()
    {
        dialogController.ChangeText("—¿En serio quieres verla de nuevo?");
    }

    private void Dialogo4()
    {
        dialogController.ChangeText("—¿A pesar de lo que pasó en el puente?");
    }

    private void Dialogo5()
    {
        dialogController.ChangeText("—...");
    }

    private void Dialogo6()
    {
        dialogController.ChangeText("—Lo siento.");
    }

    private void Dialogo7()
    {
        dialogController.ChangeText("—Ordenes son ordenes.");
    }

    private void FinalizarDialogo()
    {
        dialogController.Disable();
        inputReader.EnableInput();

        Inicio();
        canvas.SetActive(true);

        enemigo.GetComponent<EnemyStatus>().Active();
        enemigo.GetComponent<EnemyStatus>().TakeDamage(0);

        wall.SetActive(true);
    }
}