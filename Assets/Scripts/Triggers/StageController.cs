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

    private bool triggered = false;

    protected virtual void Awake()
    {
        // Si no se asignan, se buscan automáticamente en la escena
        if (inputReader == null)
            inputReader = FindAnyObjectByType<InputReader>();

        if (dialogController == null)
            dialogController = FindAnyObjectByType<DialogController>();
    }

    protected void TriggerStage(Collider2D other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            inputReader?.DisableInput();
        }
    }

    protected void StartDialog(string[] lines, float[] times, System.Action onComplete = null)
    {
        StartCoroutine(DialogRoutine(lines, times, onComplete));
    }

    private IEnumerator DialogRoutine(string[] lines, float[] times, System.Action onComplete)
    {
        dialogController?.Enable();

        for (int i = 0; i < lines.Length; i++)
        {
            dialogController?.ChangeText(lines[i]);
            yield return new WaitForSeconds(times[i]);
        }

        dialogController?.Disable();
        inputReader?.EnableInput();
        onComplete?.Invoke();
    }

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