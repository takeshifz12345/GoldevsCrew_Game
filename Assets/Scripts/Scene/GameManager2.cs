using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager2 : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    public Button button;

    public Camera introCam;

    public InputReader inputReader;

    public DialogController dialogController;

    public void Start()
    {
        introCam.enabled = true;
        button.onClick.AddListener(Reiniciar);
        IntroLevel3();
    }
    public void Update()
    {

    }

    public void ReiniciarNivel()
    {

    }

    public void ChangeJugador(bool player)
    {
        Player2.SetActive(!player);
        Player1.SetActive(player);

        inputReader.playerController = (player) ? Player1.GetComponent<PlayerController>() : Player2.GetComponent<PlayerController>();
        inputReader.playerHealth = (player) ? Player1.GetComponent<PlayerHealth>() : Player2.GetComponent<PlayerHealth>();
        inputReader.playerShoot = (player) ? Player1.GetComponent<PlayerShoot>() : Player2.GetComponent<PlayerShoot>();
    }

    public void IntroLevel3()
    {
        string[] dialog = new string[]
        {
                "Había una vez dos niñas que eran inseparables.",
                "Les encantaba dibujar en las paredes, hablar por teléfonos de latas y mirar las estrellas desde la muralla.",
                "Pero una noche… algo ocurrió.",
                "Escuché los gritos de mis subordinados; cada uno traía en brazos a una de las niñas, inconsciente.",
                "Habían caído de la muralla, y sus rostros…",
                "…",
                "Oh…",
                "Están aquí.",
                ""
        };

        float[] tiempos = new float[] { 5f, 7.5f, 1.5f, 7.5f, 3.5f, 0.5f, 1f, 1.25f, 0.25f };

        StartDialog(dialog, tiempos, () => Empezar());
    }

    public void StartDialog(string[] lines, float[] times, System.Action onComplete = null)
    {
        StartCoroutine(DialogRoutine(lines, times, onComplete));
    }

    public IEnumerator DialogRoutine(string[] lines, float[] times, System.Action onComplete)
    {
        dialogController?.Enable(0);

        for (int i = 0; i < lines.Length; i++)
        {
            dialogController?.ChangeText(lines[i]);
            yield return new WaitForSeconds(times[i]);
        }

        dialogController?.Disable();
        inputReader?.EnableInput();
        onComplete?.Invoke();
    }

    private void Reiniciar()
    {

    }

    public void Empezar()
    {
        ChangeJugador(true);
    }
}