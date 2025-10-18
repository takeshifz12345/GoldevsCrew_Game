using UnityEngine;

public class EyeManager : MonoBehaviour
{
    public Animator animator;

    public void SetOpen(bool open)
    {
        animator.SetBool("isOpen", open);
    }

    public void ChangeState()
    {
        // Cambia el valor actual de "isOpen" al contrario
        bool currentState = animator.GetBool("isOpen");
        animator.SetBool("isOpen", !currentState);
    }

    void Update()
    {

    }
}