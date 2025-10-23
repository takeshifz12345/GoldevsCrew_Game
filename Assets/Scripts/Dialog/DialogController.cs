using TMPro;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    TextMeshProUGUI text;

    void Start()
    {
        GameObject dialog = GameObject.Find("DialogText");
        text = dialog.GetComponent<TextMeshProUGUI>();
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void ChangeText(string newText)
    {
        text.text = newText;
    }
}