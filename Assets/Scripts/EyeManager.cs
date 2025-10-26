using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EyeManager : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Abre o cierra el ojo
    /// </summary>
    public void SetOpen(bool open)
    {
        animator.SetBool("isOpen", open);
    }

    /// <summary>
    /// Cambia el estado del ojo al contrario
    /// </summary>
    public void ChangeState()
    {
        animator.SetBool("isOpen", !animator.GetBool("isOpen"));
    }
}