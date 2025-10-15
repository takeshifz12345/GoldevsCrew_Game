using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    public Image star1;
    public Image star2;
    public Image star3;
    public Image star4;
    public Image star5;
    public Image star6;
    public Image star7;
    public Image star8;
    public Image star9;
    public Image star10;
    public Sprite SprStarOn;
    public Sprite SprStarOff;

    public void UpdateHealthUI(int current)
    {
        switch (current)
        {
            case 0:
                star1.sprite = SprStarOff;
                star2.sprite = SprStarOff;
                star3.sprite = SprStarOff;
                star4.sprite = SprStarOff;
                star5.sprite = SprStarOff;
                star6.sprite = SprStarOff;
                star7.sprite = SprStarOff;
                star8.sprite = SprStarOff;
                star9.sprite = SprStarOff;
                star10.sprite = SprStarOff;
                break;
            case 1:
                star1.sprite = SprStarOn;
                star2.sprite = SprStarOff;
                star3.sprite = SprStarOff;
                star4.sprite = SprStarOff;
                star5.sprite = SprStarOff;
                star6.sprite = SprStarOff;
                star7.sprite = SprStarOff;
                star8.sprite = SprStarOff;
                star9.sprite = SprStarOff;
                star10.sprite = SprStarOff;
                break;
            case 2:
                star1.sprite = SprStarOn;
                star2.sprite = SprStarOn;
                star3.sprite = SprStarOff;
                star4.sprite = SprStarOff;
                star5.sprite = SprStarOff;
                star6.sprite = SprStarOff;
                star7.sprite = SprStarOff;
                star8.sprite = SprStarOff;
                star9.sprite = SprStarOff;
                star10.sprite = SprStarOff;
                break;
            case 3:
                star1.sprite = SprStarOn;
                star2.sprite = SprStarOn;
                star3.sprite = SprStarOn;
                star4.sprite = SprStarOff;
                star5.sprite = SprStarOff;
                star6.sprite = SprStarOff;
                star7.sprite = SprStarOff;
                star8.sprite = SprStarOff;
                star9.sprite = SprStarOff;
                star10.sprite = SprStarOff;
                break;
            case 4:
                star1.sprite = SprStarOn;
                star2.sprite = SprStarOn;
                star3.sprite = SprStarOn;
                star4.sprite = SprStarOn;
                star5.sprite = SprStarOff;
                star6.sprite = SprStarOff;
                star7.sprite = SprStarOff;
                star8.sprite = SprStarOff;
                star9.sprite = SprStarOff;
                star10.sprite = SprStarOff;
                break;
            case 5:
                star1.sprite = SprStarOn;
                star2.sprite = SprStarOn;
                star3.sprite = SprStarOn;
                star4.sprite = SprStarOn;
                star5.sprite = SprStarOn;
                star6.sprite = SprStarOff;
                star7.sprite = SprStarOff;
                star8.sprite = SprStarOff;
                star9.sprite = SprStarOff;
                star10.sprite = SprStarOff;
                break;
            case 6:
                star1.sprite = SprStarOn;
                star2.sprite = SprStarOn;
                star3.sprite = SprStarOn;
                star4.sprite = SprStarOn;
                star5.sprite = SprStarOn;
                star6.sprite = SprStarOn;
                star7.sprite = SprStarOff;
                star8.sprite = SprStarOff;
                star9.sprite = SprStarOff;
                star10.sprite = SprStarOff;
                break;
            case 7:
                star1.sprite = SprStarOn;
                star2.sprite = SprStarOn;
                star3.sprite = SprStarOn;
                star4.sprite = SprStarOn;
                star5.sprite = SprStarOn;
                star6.sprite = SprStarOn;
                star7.sprite = SprStarOn;
                star8.sprite = SprStarOff;
                star9.sprite = SprStarOff;
                star10.sprite = SprStarOff;
                break;
            case 8:
                star1.sprite = SprStarOn;
                star2.sprite = SprStarOn;
                star3.sprite = SprStarOn;
                star4.sprite = SprStarOn;
                star5.sprite = SprStarOn;
                star6.sprite = SprStarOn;
                star7.sprite = SprStarOn;
                star8.sprite = SprStarOn;
                star9.sprite = SprStarOff;
                star10.sprite = SprStarOff;
                break;
            case 9:
                star1.sprite = SprStarOn;
                star2.sprite = SprStarOn;
                star3.sprite = SprStarOn;
                star4.sprite = SprStarOn;
                star5.sprite = SprStarOn;
                star6.sprite = SprStarOn;
                star7.sprite = SprStarOn;
                star8.sprite = SprStarOn;
                star9.sprite = SprStarOn;
                star10.sprite = SprStarOff;
                break;
            case 10:
                star1.sprite = SprStarOn;
                star2.sprite = SprStarOn;
                star3.sprite = SprStarOn;
                star4.sprite = SprStarOn;
                star5.sprite = SprStarOn;
                star6.sprite = SprStarOn;
                star7.sprite = SprStarOn;
                star8.sprite = SprStarOn;
                star9.sprite = SprStarOn;
                star10.sprite = SprStarOn;
                break;
        }
    }
}