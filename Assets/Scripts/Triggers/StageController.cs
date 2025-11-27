using System.Collections;
using UnityEngine;

[System.Serializable]
public class AttackData
{
    public GameObject prefab;
    public Vector2 position;
    public Vector2 direction = Vector2.left;
    public float speed = 5f;
    public int damage = 1;
    public float lifeTime = 3f;
    public float delay = 0f;
}

public class StageController : MonoBehaviour
{
    [Header("Referencias")]
    public InputReader inputReader;
    public DialogController dialogController;
    public int spriteDialog;

    public bool triggered = false;

    private System.Action pendingOnComplete;

    protected virtual void Awake()
    {
        if (inputReader == null)
            inputReader = FindAnyObjectByType<InputReader>();

        if (dialogController == null)
            dialogController = FindAnyObjectByType<DialogController>();
    }

    protected bool TriggerStage(Collider2D other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            inputReader?.DisableInput();
            return true;
        }
        return false;
    }

    // =============================================================
    // NUEVA IMPLEMENTACIÓN usando DialogController (sin romper API)
    // =============================================================

    protected void StartDialog(string[] lines, float[] times, System.Action onComplete = null)
    {
        // Guardamos callback sin ejecutarlo aún.
        pendingOnComplete = onComplete;

        // Activar UI + sprite.
        dialogController.Enable(spriteDialog);

        // Iniciar diálogo multilínea.
        dialogController.StartDialog(lines);

        // Necesitamos esperar a que DialogController termine.
        StartCoroutine(WaitDialogEnd());
    }

    // Espera hasta que DialogController cierre su UI
    private IEnumerator WaitDialogEnd()
    {
        // Mientras el diálogo esté activo, seguimos esperando.
        while (dialogController.gameObject.activeInHierarchy &&
               dialogController.enabled &&
               dialogController.isActiveAndEnabled &&
               dialogController.gameObject.activeSelf &&
               dialogController.transform.GetChild(0).gameObject.activeSelf)
        {
            yield return null;
        }

        // Reactivar input.
        inputReader?.EnableInput();

        // Ejecutar callback.
        pendingOnComplete?.Invoke();
        pendingOnComplete = null;
    }

    // =============================================================

    protected void LaunchAttacks(AttackData[] attacks)
    {
        StartCoroutine(AttackRoutine(attacks));
    }

    private IEnumerator AttackRoutine(AttackData[] attacks)
    {
        foreach (var attack in attacks)
        {
            if (attack.delay > 0)
                yield return new WaitForSeconds(attack.delay);

            GameObject go = Instantiate(attack.prefab, attack.position, Quaternion.identity);
            var ea = go.GetComponent<EnemyAttack>();
            if (ea != null)
            {
                ea.direction = attack.direction;
                ea.speed = attack.speed;
                ea.damage = attack.damage;
                ea.lifeTime = attack.lifeTime;
            }
        }
    }
}