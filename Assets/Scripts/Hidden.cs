using UnityEngine;

public class CanvasVisibility : MonoBehaviour
{
    void Start()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            // Si es WebGL, lo mantiene visible
            gameObject.SetActive(true);
        }
        if (Application.platform == RuntimePlatform.Android ||
            Application.platform == RuntimePlatform.IPhonePlayer)
        {
            // Si es móvil (APK Android/iOS), oculta el Canvas
            gameObject.SetActive(true);
        }
        else{
            // En PC standalone (Windows/Mac/Linux), también lo oculta
            gameObject.SetActive(false);
        }
    }
}