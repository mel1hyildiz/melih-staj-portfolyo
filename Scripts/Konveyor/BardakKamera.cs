using UnityEngine;

public class BardakKamera : MonoBehaviour
{
    [SerializeField] private Transform hedef;

    [SerializeField] private float mesafe = 2f;

    [SerializeField] private float donusHizi = 200f;

    [SerializeField] private float minY = -20f;
    [SerializeField] private float maxY = 70f;

    private float yatayAci;
    private float dikeyAci = 20f;

    private void LateUpdate()
    {
        if (hedef == null)
            return;

        if (Input.GetMouseButton(1))
        {
            yatayAci += Input.GetAxis("Mouse X") * donusHizi * Time.deltaTime;

            dikeyAci -= Input.GetAxis("Mouse Y") * donusHizi * Time.deltaTime;

            dikeyAci = Mathf.Clamp(dikeyAci, minY, maxY);
        }

        Quaternion donus = Quaternion.Euler(dikeyAci, yatayAci, 0);

        Vector3 pozisyon = hedef.position - donus * Vector3.forward * mesafe;

        transform.position = pozisyon;

        transform.LookAt(hedef);
    }
}