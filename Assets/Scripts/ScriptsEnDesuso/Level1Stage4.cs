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
            Invoke(nameof(Dialogo2), 3f);
            Invoke(nameof(Dialogo3), 5f);
            Invoke(nameof(Dialogo4), 8f);
            Invoke(nameof(Dialogo5), 12f);
            Invoke(nameof(FinalizarDialogo), 17f);
        }
    }

    private void Dialogo1()
    {
        dialogController.ChangeText("—¿Tanto quieres ver a tu amiga?");
    }

    private void Dialogo2()
    {
        dialogController.ChangeText("—Lo siento.");
    }

    private void Dialogo3()
    {
        dialogController.ChangeText("—Pero son ordenes.");
    }

    private void Dialogo4()
    {
        dialogController.ChangeText("PRESIONA LA TECLA E PARA DISPARAR.");
    }

    private void Dialogo5()
    {
        dialogController.ChangeText("PERO CUIDADO POR QUE PIERDES VIDA POR DISPARO.");
    }

    private void FinalizarDialogo()
    {
        dialogController.Disable();
        inputReader.EnableInput();

        Inicio();

        canvas.SetActive(true);

        enemigo.GetComponent<EnemyStatus>().active = true;
    }

    private void Inicio()
    {
        if (flag)
        {
            StartCoroutine(LanzarAtaques());
        }
    }

    private IEnumerator LanzarAtaques()
    {
        if (flag)
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
    }

    private void CambiarEstadosZonas()
    {
        if (flag)
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