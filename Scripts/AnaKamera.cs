using UnityEngine;

public class AnaKamera : MonoBehaviour
{
    public GameObject Cam;
    public GameObject cam2;
    public GameObject cam3;
    public void Ac()
    {
        Cam.SetActive(true);
        cam2.SetActive(false);
        cam3.SetActive(false);
    }
}
