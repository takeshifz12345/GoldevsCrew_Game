using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstDamage : MonoBehaviour
{
    public float posX;
    public float posY;
    public GameObject ataque;
    public bool flag = false;
    public InputReader inputReader;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!flag)
            {
                Vector2 posSpawn = new Vector2(posX, posY);
                Instantiate(ataque, posSpawn, Quaternion.identity);
                flag = true;

                //acà se debe colocar el còdigo que desactive los inputs del jugador y que luego de x tiempo vuelva a activarse
               
                if (inputReader != null) StartCoroutine(ReactivarInput(inputReader, 2f));
            }
        }
    }

    private IEnumerator ReactivarInput(InputReader p, float t)
    {
        p.DisableInput();
        yield return new WaitForSeconds(t);
             p.EnableInput();

    }

    void Start()
    {

    }

    void Update()
    {
        
    }
}
