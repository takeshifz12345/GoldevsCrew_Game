using UnityEngine;

public class Level1Stage2_1 : StageController
{
    [Header("Ataque")]
    public GameObject ataque;
    public Vector2 ataqueSpawn;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (TriggerStage(other))
        {
            string[] dialog = new string[]
            {
            "—Por si acaso, no pude quitar el desastre que tú y tu amiga hicieron en la pared.",
            "—El almacén de pintura de Jester se quedó vacío.",
            "—…",
            "—No salgas de esta habitación.",
            "—Te estaré viendo."
            };

            float[] tiempos = new float[] { 7f, 4f, 3f, 2f, 1f };

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