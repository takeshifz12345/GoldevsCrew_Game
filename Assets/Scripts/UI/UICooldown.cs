using UnityEngine;
using UnityEngine.UI;

public class UICooldown : MonoBehaviour
{
    public Image cooldownImage;
    public Sprite cooldownImageOn;
    public Sprite cooldownImageOff;

    public void UpdateCooldownUI(float cooldown)
    {
        if (cooldown < 1)
        {
            cooldownImage.sprite = cooldownImageOn;
        }
        else
        {
            cooldownImage.sprite = cooldownImageOff;
        }
    }
}