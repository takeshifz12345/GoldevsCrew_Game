using UnityEngine;

public class Joystick : MonoBehaviour
{
    // Variable para guardar la posición inicial en Y
    private float initialY;

    void Start()
    {
        // Guardamos la posición Y al iniciar
        initialY = transform.position.y;
    }

    void Update()
    {
        // Mantiene el eje Y fijo en el valor inicial
        transform.position = new Vector3(
            transform.position.x,
            initialY,
            transform.position.z
        );
    }
}
