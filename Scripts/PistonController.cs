using System.Collections;
using UnityEngine;

public class PistonController : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] private Animator animator;

    [Header("Trigger Ýsimleri")]
    [SerializeField] private string baslatTrigger = "Baslat";
    [SerializeField] private string durdurTrigger = "Durdur";

    private bool makineVar = false;

    private void Start()
    {
        Baslat();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger girdi: " + other.name);

        if (other.CompareTag("Makine"))
        {
            Durdur();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger çýktý: " + other.name);

        if (other.CompareTag("Makine"))
        {
            StartCoroutine(bekle());
        }
    }

    IEnumerator bekle()
    {
        yield return new WaitForSeconds(1f);
        Baslat();
    }
    public void Baslat()
    {
        if (animator == null)
            return;

        animator.ResetTrigger(durdurTrigger);
        animator.SetTrigger(baslatTrigger);
    }

    public void Durdur()
    {
        if (animator == null)
            return;

        animator.ResetTrigger(baslatTrigger);
        animator.SetTrigger(durdurTrigger);
    }
}