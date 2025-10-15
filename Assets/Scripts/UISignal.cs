using UnityEngine.UI;
using UnityEngine;

public class UISignal : MonoBehaviour
{
    public Image signalImage1;
    public Image signalImage2;
    public Image signalImage3;
    public Sprite SprSignalOn;
    public Sprite SprSignalOff;

    public void UpdateSignalUI(int signal)
    {
        switch (signal)
        {
            case 0:
                signalImage1.sprite = SprSignalOff;
                signalImage2.sprite = SprSignalOff;
                signalImage3.sprite = SprSignalOff;
                break;
            case 1:
                signalImage1.sprite = SprSignalOn;
                signalImage2.sprite = SprSignalOff;
                signalImage3.sprite = SprSignalOff;
                break;
            case 2:
                signalImage1.sprite = SprSignalOn;
                signalImage2.sprite = SprSignalOn;
                signalImage3.sprite = SprSignalOff;
                break;
            case 3:
                signalImage1.sprite = SprSignalOn;
                signalImage2.sprite = SprSignalOn;
                signalImage3.sprite = SprSignalOn;
                break;
        }
    }
}