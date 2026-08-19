using UnityEngine;

public class ConveyorRod : MonoBehaviour
{
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
        BoxState state = other.GetComponent<BoxState>();

        if (state != null)
        {
            if (state.konveyordenAyrildi)
                return;

            if (!state.konveyoreBaglanabilir)
                return;
        }

        if (!other.CompareTag("Box"))
            return;

        // Bu kutu artýk otomatik alma sistemindeyse tekrar baðlama
        if (other.transform.parent != null &&
            other.transform.parent.name == "OtoKutuAlma") // veya otoKutuAlma Transform'u
            return;

        if (state != null && !state.konveyoreBaglanabilir)
            return;

        if (konveyor.KutusuVarMi(transform))
            return;

        konveyor.KutuAta(transform, other.transform);

        Debug.Log("Kutu çubuða baðlandý: " + other.name);
    }
}