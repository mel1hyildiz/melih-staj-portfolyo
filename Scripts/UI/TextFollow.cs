using UnityEngine;

public class TextFollow : MonoBehaviour
{
    void LateUpdate()
    {
        Camera cam = Camera.main;

        if (cam == null)
        {
            // MainCamera etiketi yoksa aktif kamerayý bul
            cam = FindFirstObjectByType<Camera>();
        }

        if (cam != null)
        {
            transform.LookAt(
                transform.position + cam.transform.rotation * Vector3.forward,
                cam.transform.rotation * Vector3.up
            );
        }
    }
}