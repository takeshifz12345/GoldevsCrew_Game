using System.Collections;
using UnityEngine;

public class Lvl2_Stage7 : StageController
{
    [Header("Spawns Abajo")]
    public GameObject ataques2;
    public float spawnXADown;
    public float spawnXBDown;
    public float spawnYDown;

    [Header("Spawns Izquierda")]
    public float spawnYARight;
    public float spawnYBRight;
    public float spawnXRight;

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

    public MusicController music;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!TriggerStage(other)) return;

        music.MuteMusic();

        string[] lines = {
            "—Eres genial, Jester.",
            "—Sí, y divertido.",
            "—Lo siento. Pero solo sigo órdenes del rey."
        };

        float[] times = { 1.5f, 1.5f, 3f };

        StartDialog(lines, times, FinalizarDialogo);
    }

    public override IEnumerator DialogRoutine(string[] lines, float[] times, System.Action onComplete)
    {
        dialogController?.Enable(spriteDialog);

        for (int i = 0; i < lines.Length; i++)
        {
            dialogController.ChangeProfile(i);
            dialogController?.ChangeText(lines[i]);
            yield return new WaitForSeconds(times[i]);
        }

        dialogController?.Disable();
        inputReader?.EnableInput();
        onComplete?.Invoke();
    }

    private void FinalizarDialogo()
    {
        canvas.SetActive(true);
        enemigo.GetComponent<EnemyStatus>().Active();
        enemigo.GetComponent<EnemyStatus>().TakeDamage(0);
        wall.SetActive(true);

        music.PlayBattleMusic();

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
            float spawnY = Random.Range(spawnYARight, spawnYBRight);
            Vector2 posSpawn = new(spawnXRight, spawnY);

            GameObject ataqueGO = Instantiate(ataques2, posSpawn, Quaternion.identity);
            EnemyAttack ea = ataqueGO.GetComponent<EnemyAttack>();
            ea.direction = Vector2.right;
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
            
        ojo1.SetOpen(false);
        ojo2.SetOpen(false);
        ojo3.SetOpen(false);
        zona1.Enable();
        zona2.Enable();
        zona3.Enable();
        wall.SetActive(false);
    }
}