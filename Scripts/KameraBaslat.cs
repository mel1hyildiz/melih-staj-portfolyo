using UnityEngine;

public class KameraBaslat : MonoBehaviour
{
    public FreeCam freeCam;
    public GameObject cam;

    public bool açýk = false;
    public void AçKapa()
    {
        if (!açýk)
        {
            açýk = true;
            cam.SetActive(true);
            freeCam.KameraBaslat();
        }
        else
        {
            açýk = false;
            freeCam.KameraDurdur();
            cam.SetActive(false);
        }
    }
}
