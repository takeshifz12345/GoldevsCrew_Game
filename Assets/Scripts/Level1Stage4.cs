using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Level1Stage4 : MonoBehaviour
{
    public bool flag = false;
    public GameObject ataques;
    public float spawnXA;
    public float spawnXB;
    public float spawnY;
    public float intervaloAtaques = 1f;

    public SignalZone zona1;
    public SignalZone zona2;
    public SignalZone zona3;
    public SignalZone zona4;

    public EyeManager ojo1;
    public EyeManager ojo2;
    public EyeManager ojo3;
    public EyeManager ojo4;

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
        StartCoroutine(LanzarAtaques());
    }

    private IEnumerator LanzarAtaques()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                float spawnX = Random.Range(spawnXA, spawnXB);
                Vector2 spawnPos = new Vector2(spawnX, spawnY);
                Instantiate(ataques, spawnPos, Quaternion.identity);
            }
            yield return new WaitForSeconds(intervaloAtaques);
        }

        CambiarEstadosZonas();
    }

    private void CambiarEstadosZonas()
    {
        EyeManager[] ojos = { ojo1, ojo2, ojo3, ojo4 };
        SignalZone[] zonas = { zona1, zona2, zona3, zona4 };

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
            ojo4.SetOpen(false);
            zona1.Enable();
            zona2.Enable();
            zona3.Enable();
            zona4.Enable();

            Destroy(this);
        }
    }
}