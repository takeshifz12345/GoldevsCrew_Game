using TMPro;
using UnityEngine;

public class UISignal : MonoBehaviour
{
    public TextMeshProUGUI signalText;

    public void UpdateSignalUI(int signal)
    {
        signalText.text = "señal: " + signal;
    }
}