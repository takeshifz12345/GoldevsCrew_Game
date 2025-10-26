using UnityEngine;
using UnityEngine.UI;

public class UICooldown : MonoBehaviour
{
    public Image cooldownImage;
    public Sprite spriteActive;
    public Sprite spriteInactive;

    public void UpdateCooldownUI(float cooldown)
    {
        cooldownImage.sprite = cooldown < 1f ? spriteActive : spriteInactive;
    }
}