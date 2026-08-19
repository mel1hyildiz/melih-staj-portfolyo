using UnityEngine;

public class Bekle : MonoBehaviour
{
    public bool bekle = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Box"))
            bekle = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
            bekle = false;
    }
}
