using UnityEngine;

public class Lvl2_Stage3 : StageController
{
    [Header("Ataques")]
    public GameObject ataquePrefab;

    [Tooltip("Posiciones donde aparecerán los ataques (en coordenadas de mundo o relativas al trigger)")]
    public Vector2[] posicionesAtaques;

    [Tooltip("Velocidad con la que los ataques subirán")]
    public float velocidadAtaques = 6f;

    [Tooltip("Tiempo de vida de cada ataque")]
    public float duracionAtaques = 4f;

    [Tooltip("Retraso entre cada ataque")]
    public float intervaloAtaques = 0.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (TriggerStage(other))
        {
            // Diálogo
            string[] dialog = new string[]
            {
                "—Ya lo sé.",
                "—Quieres ver las estrellas en el puente ¿cierto?",
                "—No necesitas salir, ya me encargué de eso."
            };

            float[] tiempos = new float[] { 2f, 3f, 3f };

            // Construcción dinámica de los ataques
            AttackData[] ataques = new AttackData[posicionesAtaques.Length];
            for (int i = 0; i < posicionesAtaques.Length; i++)
            {
                ataques[i] = new AttackData
                {
                    prefab = ataquePrefab,
                    position = (Vector2)transform.position + posicionesAtaques[i],
                    direction = Vector2.up, // De abajo hacia arriba
                    speed = velocidadAtaques,
                    damage = 1,
                    lifeTime = duracionAtaques,
                    delay = intervaloAtaques * i
                };
            }

            // Diálogo y ataques
            StartDialog(dialog, tiempos, () => LaunchAttacks(ataques));
        }
    }
}