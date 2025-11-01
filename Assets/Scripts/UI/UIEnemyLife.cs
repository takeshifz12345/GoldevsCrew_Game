using UnityEngine;
using UnityEngine.UI;

public class UIEnemyLife : MonoBehaviour
{
    public Image[] life;
    public Sprite sprLife;

    public void UpdateLifeUI(int current)
    {
        current = Mathf.Clamp(current, 0, life.Length);

        for (int i = 0; i < life.Length; i++)
        {
            if (i < current)
            {
                life[i].enabled = true; // Primero habilitá el componente
                life[i].sprite = sprLife; // Luego asigná el sprite
            }
            else
            {
                life[i].sprite = null;
                life[i].enabled = false;
            }
        }
    }
}