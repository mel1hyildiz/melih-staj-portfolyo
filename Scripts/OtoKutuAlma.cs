using UnityEngine;

public class OtoKutuAlma : MonoBehaviour
{
    [SerializeField] private Transform kutuGirisi;
    [SerializeField] private Transform kutuWaypoint;


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Box")) return;

        other.transform.SetParent(null);

        other.transform.position = kutuGirisi.position;
        other.transform.rotation = kutuGirisi.rotation;

        KutuGidiyor kg = other.GetComponent<KutuGidiyor>();

        if (kg != null)
        {
            kg.HedefAyarla(kutuWaypoint);
            kg.Baslat();
            Debug.Log("Atandý!");
        }
        else
        { Debug.Log("Atanmadý!"); }
    }
}