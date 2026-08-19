using FabrikaOtomasyonu.Yonetim;
using UnityEngine;

public class Trigger1 : MonoBehaviour
{
    public SutKabulYoneticisi sutKabulYoneticisi;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Týr"))
        {
            sutKabulYoneticisi.BosaltmaAlaninaGeldi();
        }
    }
}
