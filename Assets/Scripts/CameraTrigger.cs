using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    private Camera cam;
    private BoxCollider2D triggerZone;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        triggerZone = GetComponent<BoxCollider2D>();

        cam.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            ActivateThisCamera();
    }

    private void ActivateThisCamera()
    {
        // Apaga otras cámaras y reactiva sus triggers
        CameraTrigger[] allCameras = FindObjectsByType<CameraTrigger>(FindObjectsSortMode.None);
        foreach (CameraTrigger ct in allCameras)
        {
            ct.cam.enabled = false;
            ct.triggerZone.enabled = true;
        }

        // Activa esta cámara y desactiva su trigger
        cam.enabled = true;
        triggerZone.enabled = false;
    }
}
