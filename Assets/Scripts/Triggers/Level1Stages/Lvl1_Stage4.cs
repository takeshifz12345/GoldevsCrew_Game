using System.Collections;
using UnityEngine;

public class Lvl1_Stage4 : StageController
{
    [Header("Configuración general")]
    public GameObject ataques;
    public float spawnXA;
    public float spawnXB;
    public float spawnY;
    public float intervaloAtaques = 1f;

    [Header("Zonas y ojos")]
    public SignalZone zona1, zona2, zona3, zona4;
    public EyeManager ojo1, ojo2, ojo3, ojo4;

    [Header("Referencias externas")]
    public GameObject enemigo;
    public GameObject canvas;

    private Coroutine ataqueLoop;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!TriggerStage(other)) return;

        string[] lines = {
            "—¿Tanto quieres ver a tu amiga?",
            "—Lo siento.",
            "—Pero son órdenes.",
            "PRESIONA LA TECLA E PARA DISPARAR.",
            "PERO CUIDADO, PIERDES VIDA AL DISPARAR."
        };

        float[] times = { 3f, 2f, 3f, 4f, 5f };

        StartDialog(lines, times, () =>
        {
            canvas.SetActive(true);
            enemigo.GetComponent<EnemyStatus>().Active();
            ataqueLoop = StartCoroutine(LanzarAtaquesInfinitos());
        });
    }

    private IEnumerator LanzarAtaquesInfinitos()
    {
        while (enemigo != null)
        {
            // 5 rondas de 3 ataques
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    float spawnX = Random.Range(spawnXA, spawnXB);
                    Vector2 spawnPos = new(spawnX, spawnY);
                    Instantiate(ataques, spawnPos, Quaternion.identity);
                }
                yield return new WaitForSeconds(intervaloAtaques);
            }

            CambiarEstadosZonas();
            yield return new WaitForSeconds(2f);
        }

        TerminarStage();
    }

    private void CambiarEstadosZonas()
    {
        EyeManager[] ojos = { ojo1, ojo2, ojo3, ojo4 };
        SignalZone[] zonas = { zona1, zona2, zona3, zona4 };

        for (int i = 0; i < ojos.Length; i++)
        {
            if (Random.value > 0.5f)
            {
                ojos[i].ChangeState();
                zonas[i].ChangeState();
            }
        }
    }

    public void TerminarStage()
    {
        if (ataqueLoop != null)
            StopCoroutine(ataqueLoop);

        ojo1.SetOpen(false);
        ojo2.SetOpen(false);
        ojo3.SetOpen(false);
        ojo4.SetOpen(false);

        zona1.Enable();
    }
}