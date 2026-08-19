using System.Collections;
using UnityEngine;

public class KutuDoluluk : MonoBehaviour
{
    public float minZ = 0.001f;
    public float maxZ = 54f;

    private Coroutine dolumCoroutine;

    public void Doldur(float hedefYuzde, float sure)
    {
        if (dolumCoroutine != null)
            StopCoroutine(dolumCoroutine);

        dolumCoroutine = StartCoroutine(DoldurCoroutine(hedefYuzde, sure));
    }

    IEnumerator DoldurCoroutine(float hedefYuzde, float sure)
    {
        Vector3 scale = transform.localScale;

        float baslangicZ = scale.z;
        float hedefZ = Mathf.Lerp(minZ, maxZ, hedefYuzde / 100f);

        float t = 0;

        while (t < sure)
        {
            t += Time.deltaTime;

            scale.z = Mathf.Lerp(baslangicZ, hedefZ, t / sure);
            transform.localScale = scale;

            yield return null;
        }

        scale.z = hedefZ;
        transform.localScale = scale;
    }
}