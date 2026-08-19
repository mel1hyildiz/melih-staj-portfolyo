using UnityEngine;

public class Asama3Kontrol : MonoBehaviour
{
    public HMI hmi;

    private KonveyorYol konveyor;


    private void Start()
    {
        konveyor = FindFirstObjectByType<KonveyorYol>();

        if (konveyor == null)
        {
            Debug.LogError("KonveyorYol bulunamadý!");
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Box"))
            return;


        BoxSayildi box = other.GetComponent<BoxSayildi>();


        if (box != null && !box.sayildi)
        {
            box.sayildi = true;


            // HMI iþlemleri
            hmi.KutuSay();
            hmi.DegerUret();

        }
    }
}