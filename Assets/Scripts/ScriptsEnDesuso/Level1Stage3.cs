using UnityEngine;

public class Level1Stage3 : MonoBehaviour
{
    public GameObject ataque;
    public bool flag = false;
    public InputReader inputReader;
    public DialogController dialogController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!flag)
            {
                inputReader.DisableInput();
                dialogController.Enable(0);
                Dialogo1();
                Invoke(nameof(Dialogo2), 3f);
                Invoke(nameof(Dialogo3), 5f);
                Invoke(nameof(Dialogo4), 8f);
                Invoke(nameof(FinalizarDialogo), 10f);

                flag = true;
            }

        }
    }
    
    void DisparoX1()
    {
        Vector2 posSpawn = new Vector2(transform.position.x + 15.5f, transform.position.y - 2.5f);
        GameObject ataqueGO = Instantiate(ataque, posSpawn, Quaternion.identity);

        // Configurar par�metros del ataque
        EnemyAttack enemyAttack = ataqueGO.GetComponent<EnemyAttack>();
        enemyAttack.direction = Vector2.left;  // Hacia la izquierda
        enemyAttack.speed = 5f;                // Velocidad
        enemyAttack.damage = 1;               // Da�o
        enemyAttack.lifeTime = 3f;             // Tiempo de vida
    }

    void DisparoX2()
    {
        Vector2 posSpawn = new Vector2(transform.position.x + 15.5f, transform.position.y - 0.5f);
        GameObject ataqueGO = Instantiate(ataque, posSpawn, Quaternion.identity);

        // Configurar par�metros del ataque
        EnemyAttack enemyAttack = ataqueGO.GetComponent<EnemyAttack>();
        enemyAttack.direction = Vector2.left;  // Hacia la izquierda
        enemyAttack.speed = 5f;                // Velocidad
        enemyAttack.damage = 1;               // Da�o
        enemyAttack.lifeTime = 3f;             // Tiempo de vida
    }

    void DisparoX3()
    {
        Vector2 posSpawn = new Vector2(transform.position.x + 15.5f, transform.position.y + 1.5f);
        GameObject ataqueGO = Instantiate(ataque, posSpawn, Quaternion.identity);

        // Configurar par�metros del ataque
        EnemyAttack enemyAttack = ataqueGO.GetComponent<EnemyAttack>();
        enemyAttack.direction = Vector2.left;  // Hacia la izquierda
        enemyAttack.speed = 5f;                // Velocidad
        enemyAttack.damage = 1;               // Da�o
        enemyAttack.lifeTime = 3f;             // Tiempo de vida
    }

    private void Dialogo1()
    {
        dialogController.ChangeText("—Tu padre me ordenó no dejarte salir.");
    }

    private void Dialogo2()
    {
        dialogController.ChangeText("—Es por tu bien.");
    }

    private void Dialogo3()
    {
        dialogController.ChangeText("—Te puedes hacer daño.");
    }

    private void Dialogo4()
    {
        dialogController.ChangeText("—Te estaré viendo.");
    }

    private void FinalizarDialogo()
    {
        dialogController.Disable();
        inputReader.EnableInput();

        Invoke("DisparoX1", 1f);
        Invoke("DisparoX2", 3f);
        Invoke("DisparoX3", 5f);
    }
}