using System.Collections;
using UnityEngine;

public class OtoKutuAlma2 : MonoBehaviour
{
    [SerializeField] private Transform kutuGirisi;
    [SerializeField] private Transform otoKutuAlma;
    [SerializeField] private float hareketSuresi = 15f;
    [SerializeField] private KonveyorYol konveyor;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Box")) return;

        konveyor.KutuBirak(other.transform);

        other.transform.SetParent(otoKutuAlma);

        StopAllCoroutines();
        StartCoroutine(BekleVeBirak(other.transform));
    }

    IEnumerator BekleVeBirak(Transform kutu)
    {
        Vector3 baslangicPos = kutu.position;
        Quaternion baslangicRot = kutu.rotation;

        float gecenSure = 0f;

        while (gecenSure < hareketSuresi)
        {
            gecenSure += Time.deltaTime;

            float t = gecenSure / hareketSuresi;
            t = Mathf.SmoothStep(0f, 1f, t); // Daha yumuþak baþlangýç ve bitiþ

            kutu.position = Vector3.Lerp(baslangicPos, kutuGirisi.position, t);
            kutu.rotation = Quaternion.Slerp(baslangicRot, kutuGirisi.rotation, t);

            yield return null;
        }

        kutu.position = kutuGirisi.position;
        kutu.rotation = kutuGirisi.rotation;
    }
}