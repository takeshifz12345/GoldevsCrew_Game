using UnityEngine.UI;
using UnityEngine;

public class UISignal : MonoBehaviour
{
    public Image signalImage1;
    public Image signalImage2;
    public Image signalImage3;
    public Sprite SprSignalNull1;
    public Sprite SprSignalNull2;
    public Sprite SprSignalNull3;
    public Sprite SprSignalLow1;
    public Sprite SprSignalGood1;
    public Sprite SprSignalGood2;
    public Sprite SprSignalFull1;
    public Sprite SprSignalFull2;
    public Sprite SprSignalFull3;

    public void UpdateSignalUI(int signal)
    {
        switch (signal)
        {
            case 0:
                signalImage1.sprite = SprSignalNull1;
                signalImage2.sprite = SprSignalNull2;
                signalImage3.sprite = SprSignalNull3;
                break;
            case 1:
                signalImage1.sprite = SprSignalLow1;
                signalImage2.sprite = SprSignalNull2;
                signalImage3.sprite = SprSignalNull3;
                break;
            case 2:
                signalImage1.sprite = SprSignalGood1;
                signalImage2.sprite = SprSignalGood2;
                signalImage3.sprite = SprSignalNull3;
                break;
            case 3:
                signalImage1.sprite = SprSignalFull1;
                signalImage2.sprite = SprSignalFull2;
                signalImage3.sprite = SprSignalFull3;
                break;
        }
    }
}