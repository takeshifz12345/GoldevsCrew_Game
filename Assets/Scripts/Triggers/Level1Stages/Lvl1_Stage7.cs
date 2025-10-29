using System.Collections;
using UnityEngine;

public class Lvl1_Stage7 : StageController
{
    [Header("Spawns Abajo")]
    public GameObject ataques2;
    public float spawnXADown;
    public float spawnXBDown;
    public float spawnYDown;

    [Header("Spawns Izquierda")]
    public float spawnYALeft;
    public float spawnYBLeft;
    public float spawnXLeft;

    public float intervaloAtaques = 1f;

    [Header("Zonas y Ojos")]
    public SignalZone zona1, zona2, zona3;
    public EyeManager ojo1, ojo2, ojo3;

    [Header("Referencias")]
    public GameObject enemigo;
    public GameObject canvas;
    public GameObject wall;

    private Coroutine ataqueDownCoroutine;
    private Coroutine ataqueLeftCoroutine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!TriggerStage(other)) return;

        string[] lines = {
            "�Me duele ver tu rostro.",
            "�Pero me duele a�n m�s ya no poder hacerlo.",
            "��En serio quieres verla de nuevo?",
            "��A pesar de lo que pas� en el puente?",
            "�...",
            "�Lo siento.",
            "�Ordenes son ordenes."
        };

        float[] times = { 2f, 2f, 2f, 2f, 1.5f, 1.5f, 2f };

        StartDialog(lines, times, FinalizarDialogo);
    }

    private void FinalizarDialogo()
    {
        canvas.SetActive(true);
        enemigo.GetComponent<EnemyStatus>().active = true;
        enemigo.GetComponent<EnemyStatus>().TakeDamage(0);
        wall.SetActive(true);

        ataqueDownCoroutine = StartCoroutine(LanzarAtaquesAbajo());
        ataqueLeftCoroutine = StartCoroutine(LanzarAtaquesIzquierda());
    }

    private IEnumerator LanzarAtaquesAbajo()
    {
        while (enemigo != null)
        {
            float spawnX = Random.Range(spawnXADown, spawnXBDown);
            Vector2 posSpawn = new(spawnX, spawnYDown);

            GameObject ataqueGO = Instantiate(ataques2, posSpawn, Quaternion.identity);
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
            float spawnY = Random.Range(spawnYALeft, spawnYBLeft);
            Vector2 posSpawn = new(spawnXLeft, spawnY);

            GameObject ataqueGO = Instantiate(ataques2, posSpawn, Quaternion.identity);
            EnemyAttack ea = ataqueGO.GetComponent<EnemyAttack>();
            ea.direction = Vector2.left;
            ea.speed = 5f;
            ea.damage = 1;
            ea.lifeTime = 30f;

            CambiarEstadosZonas();
            yield return new WaitForSeconds(intervaloAtaques);
        }
    }

    private void CambiarEstadosZonas()
    {
        EyeManager[] ojos = { ojo1, ojo2, ojo3 };
        SignalZone[] zonas = { zona1, zona2, zona3 };

        for (int i = 0; i < ojos.Length; i++)
        {
            if (Random.value > 0.5f)
            {
                ojos[i].ChangeState();
                zonas[i].ChangeState();
            }
        }
    }

    private void Update()
    {
        if (enemigo == null)
        {
            desactivar();

            Destroy(this);
        }
    }

    public void desactivar()
    {
        if (ataqueDownCoroutine != null) StopCoroutine(ataqueDownCoroutine);
        if (ataqueLeftCoroutine != null) StopCoroutine(ataqueLeftCoroutine);
            
        canvas.SetActive(false);
        ojo1.SetOpen(false);
        ojo2.SetOpen(false);
        ojo3.SetOpen(false);
        zona1.Enable();
        zona2.Enable();
        zona3.Enable();
        wall.SetActive(false);
    }
}