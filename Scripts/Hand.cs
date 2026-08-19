using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private Transform holdPoint;

    private Transform heldObject;
    private Rigidbody heldRb;
    private bool canPickUp = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!canPickUp) return;

        if (heldObject != null) return;

        if (other.CompareTag("Box"))
        {
            heldObject = other.transform;
            heldRb = other.GetComponent<Rigidbody>();

            Tut();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == heldObject)
        {
            heldRb.useGravity = true;

            heldObject = null;
            heldRb = null;
        }
    }

    public void Tut()
    {
        if (heldObject == null) return;

        heldObject.SetParent(holdPoint, true);

        if (heldRb != null)
        {
            heldRb.isKinematic = false;
            heldRb.useGravity = false;
        }
    }

    public void Birak()
    {
        if (heldObject == null) return;

        heldObject.SetParent(null, true);

        if (heldRb != null)
        {
            heldRb.isKinematic = false;
            heldRb.useGravity = true;
        }

        heldObject = null;
        heldRb = null;

        canPickUp = false;
        Invoke(nameof(AcTutmayi), 0.2f);
    }

    private void AcTutmayi()
    {
        canPickUp = true;
    }
}