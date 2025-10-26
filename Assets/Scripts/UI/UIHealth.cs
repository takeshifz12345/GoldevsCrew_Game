using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    public Image[] stars; // Asigna las 10 estrellas desde el Inspector
    public Sprite SprStarOn;
    public Sprite SprStarOff;

    public void UpdateHealthUI(int current)
    {
        current = Mathf.Clamp(current, 0, stars.Length);

        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].sprite = i < current ? SprStarOn : SprStarOff;
        }
    }
}