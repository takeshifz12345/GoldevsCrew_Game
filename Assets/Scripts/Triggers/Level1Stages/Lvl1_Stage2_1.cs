using UnityEngine;

public class Level1Stage2_1 : StageController
{
    [Header("Ataque")]
    public GameObject ataque;
    public Vector2 ataqueSpawn;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TriggerStage(other);

            string[] dialog = new string[]
            {
            "—Por si acaso, no pude quitar el desastre que tú y tu amiga hicieron en la pared.",
            "—Jester se quedó sin pintura amarilla.",
            "—No salgas de esta habitación.",
            "—Te estaré viendo."
            };

            float[] tiempos = new float[] { 5f, 2f, 2f, 3f };

            AttackData[] attacks = new AttackData[]
            {
            new AttackData
            {
                prefab = ataque,
                position = ataqueSpawn,
                direction = Vector2.down,
                speed = 15f,
                damage = 1,
                lifeTime = 3f,
                delay = 0.5f
            }
            };

            // Ejecuta diálogo y luego ataque
            StartDialog(dialog, tiempos, () => LaunchAttacks(attacks));
        }
    }
}