using FabrikaOtomasyonu.Yonetim;
using System.Collections;
using UnityEngine;

public class Bariyer : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SutKabulYoneticisi sutKabulYoneticisi;

    private readonly int ac = Animator.StringToHash("ac");
    private readonly int kapat = Animator.StringToHash("kapat");

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Týr"))
        {
            animator.SetTrigger(ac);
            sutKabulYoneticisi.TirGeldi();
            StartCoroutine(acýldý());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Týr"))
        {
            animator.SetTrigger(kapat);
        }
    }
    private IEnumerator acýldý()
    {
        yield return new WaitForSeconds(1f);
        sutKabulYoneticisi.BariyerAcildi();
    }
}
