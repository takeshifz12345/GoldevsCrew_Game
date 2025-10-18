using UnityEngine;

public class EyeManager : MonoBehaviour
{
    public Animator animator;

    public void SetOpen(bool open)
    {
        animator.SetBool("isOpen", open);
    }

    void Update()
    {

    }
}