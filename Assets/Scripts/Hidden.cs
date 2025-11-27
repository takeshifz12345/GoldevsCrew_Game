using UnityEngine;

public class CanvasVisibility : MonoBehaviour
{
    public bool isMobile = false;

    void Start()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            // Si es WebGL, lo mantiene visible
            OnEnable();

            isMobile = true;
        }
        if (Application.platform == RuntimePlatform.Android ||
            Application.platform == RuntimePlatform.IPhonePlayer)
        {
            // Si es móvil (APK Android/iOS), oculta el Canvas
            OnEnable();

            isMobile = true;
        }
        else{
            // En PC standalone (Windows/Mac/Linux), también lo oculta
            OnDisable();

            isMobile = false;
        }
    }

    public void OnEnable()
    {
        gameObject.SetActive(true);
    }

    public void OnDisable()
    {
        gameObject.SetActive(false);
    }

    public void SetEnable(bool value)
    {
        if (isMobile)
        {
            if (value)
                OnEnable();
            else
                OnDisable();
        }
    }
}