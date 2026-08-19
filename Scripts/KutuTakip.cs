using UnityEngine;

public class KutuTakip : MonoBehaviour
{
    public Transform Kutu;
    public Transform Kamera;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;

    bool takip = false;

    private void Update()
    {
        if (takip)
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(true);

            Kamera.transform.position = Kutu.transform.position + new Vector3(-0.2f,0.75f,1.5f);
            Kamera.transform.rotation = Quaternion.Euler(0,180,0);
        }
        else
        {
            cam3.SetActive(false);
            cam1.SetActive(true);
        }
    }
    public void TakipEt()
    {
        if(!takip)
        { takip = true;}

        else
        { takip = false;}
    }
}
