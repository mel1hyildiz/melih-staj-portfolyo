using FabrikaOtomasyonu.Cihazlar;
using System.Collections;
using UnityEngine;

public class KutuSpawner2 : MonoBehaviour
{
    public GameObject prefab;
    public Transform Kutu;

    public bool islem = false;

    public void Ac()
    {
        if (!islem)
        bekle_yap();
    }
    public void bekle_yap()
    {
        islem = true;
        SpawnTheBox();
        islem = false;
    }
    public void SpawnTheBox()
    {
        Instantiate(prefab);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Box")) return;

        KutuGidiyor kg = other.GetComponent<KutuGidiyor>();

        if (kg != null)
        {
            kg.HedefAyarla(Kutu);
            kg.Baslat();
            Debug.Log("Atandý!");
        }
        else
        { Debug.Log("Atanmadý!"); }
    }
}
