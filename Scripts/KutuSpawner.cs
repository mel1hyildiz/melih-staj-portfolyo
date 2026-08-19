using UnityEngine;

public class KutuSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform Kutu;

    public KutuTakip KutuTakip;
    public Transform Kamera;

    public void SpawnTheBox()
    {
        Instantiate(prefab);
    }
}
