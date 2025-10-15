using UnityEngine;

public class FirstDamage : MonoBehaviour
{
    public float posX;
    public float posY;
    public GameObject ataque;
    public bool flag = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!flag)
            {
                Vector2 posSpawn = new Vector2(posX, posY);
                Instantiate(ataque, posSpawn, Quaternion.identity);
                flag = true;
            }
        }  
    }

    void Start()
    {

    }

    void Update()
    {
        
    }
}
