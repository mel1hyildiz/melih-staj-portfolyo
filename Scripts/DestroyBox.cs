using UnityEngine;

public class DestroyBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Box"))
        {
            Destroy(other.gameObject);
        }
    }
}
