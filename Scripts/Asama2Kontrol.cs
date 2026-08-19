using System.Collections;
using UnityEngine;

public class Asama2Kontrol : MonoBehaviour
{
    public bool KutuVar = false;
    public bool bitti = false;
    public Animator animator;
    public KutuDoluluk kutuDoluluk;
    private KutuDoluluk aktifKutu;
    public SurecManager surecManager;
    [SerializeField] private SplineController splineController;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Box"))
            return;

        KutuVar = true;

        aktifKutu = other.GetComponentInChildren<KutuDoluluk>();

        StartCoroutine(BoruyuIndir());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            KutuVar = false;
        }
    }

    public IEnumerator BoruyuIndir()
    {
        yield return new WaitForSeconds(2f);

        animator.SetBool("Ýndir", true);
        splineController.SetSecondKnotY(-0.38f);

        aktifKutu.Doldur(100, 5f);

        yield return new WaitForSeconds(5f);

        animator.SetBool("Kaldýr", true);
        animator.SetBool("Ýndir", false);

        StartCoroutine(hortum());
        yield return new WaitForSeconds(1f);
        animator.SetBool("Kaldýr", false);
        bitti = true;
        surecManager.ilerleme();
    }

    public IEnumerator hortum()
    {
        yield return new WaitForSeconds(0.75f);
        splineController.SetSecondKnotY(-1.725f);
    }
}
