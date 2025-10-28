using UnityEngine;

public class Lvl1_Stage3 : StageController
{
    [Header("Ataques")]
    public GameObject ataquePrefab;

    // Posiciones relativas de los disparos (respecto al trigger)
    private Vector2[] posicionesRelativas = new Vector2[]
    {
        new Vector2(15.5f, -2.5f),
        new Vector2(15.5f, -0.5f),
        new Vector2(15.5f,  1.5f)
    };

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (TriggerStage(other))
        {
            string[] dialog = new string[]
            {
                "—Tu padre me ordenó no dejarte salir.",
                "—Es por tu bien.",
                "—Te puedes hacer daño.",
                "—Te estaré viendo."
            };

            // Duraciones de cada línea (segundos)
            float[] tiempos = new float[] { 3f, 2f, 3f, 2f };

            // Datos de los tres ataques
            AttackData[] ataques = new AttackData[]
            {
                new AttackData
                {
                    prefab = ataquePrefab,
                    position = (Vector2)transform.position + posicionesRelativas[0],
                    direction = Vector2.left,
                    speed = 5f,
                    damage = 1,
                    lifeTime = 3f,
                    delay = 1f
                },
                new AttackData
                {
                    prefab = ataquePrefab,
                    position = (Vector2)transform.position + posicionesRelativas[1],
                    direction = Vector2.left,
                    speed = 5f,
                    damage = 1,
                    lifeTime = 3f,
                    delay = 3f
                },
                new AttackData
                {
                    prefab = ataquePrefab,
                    position = (Vector2)transform.position + posicionesRelativas[2],
                    direction = Vector2.left,
                    speed = 5f,
                    damage = 1,
                    lifeTime = 3f,
                    delay = 5f
                }
            };

            // Muestra el diálogo y luego dispara los ataques
            StartDialog(dialog, tiempos, () => LaunchAttacks(ataques));
        }
    }
}