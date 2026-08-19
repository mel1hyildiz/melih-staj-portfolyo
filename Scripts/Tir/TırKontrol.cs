using FabrikaOtomasyonu.Yonetim;
using System.Collections;
using TMPro;
using UnityEngine;

public class TirKontrol : MonoBehaviour
{
    [Header("Referanslar")]
    [SerializeField] private SutKabulYoneticisi sutKabulYoneticisi;
    [SerializeField] private UIYoneticisi uiYoneticisi;

    [Header("Ayarlar")]
    [SerializeField] private float tartimSuresi = 5f;
    [SerializeField] private float guncellemeAraligi = 0.1f;

    private Coroutine weighingRoutine;
    private TırAgırlık currentTruck;

    private void OnTriggerEnter(Collider other)
    {
        TırAgırlık tir = other.GetComponent<TırAgırlık>();

        if (tir == null)
            return;

        if (weighingRoutine != null)
            return;

        currentTruck = tir;

        sutKabulYoneticisi.TartimBasladi();

        weighingRoutine = StartCoroutine(WeighTruck());
    }

    private void OnTriggerExit(Collider other)
    {
        TırAgırlık tir = other.GetComponent<TırAgırlık>();

        if (tir != currentTruck)
            return;

        if (weighingRoutine != null)
        {
            StopCoroutine(weighingRoutine);
            weighingRoutine = null;
        }

        currentTruck = null;

        sutKabulYoneticisi.TartimAlaniBosaldi();
    }

    private IEnumerator WeighTruck()
    {
        if (currentTruck == null)
            yield break;

        float elapsed = 0f;
        float targetWeight = currentTruck.weight;

        while (elapsed < tartimSuresi)
        {
            elapsed += guncellemeAraligi;

            float progress = elapsed / tartimSuresi;

            float display =
                Mathf.Lerp(0, targetWeight, progress) +
                Random.Range(-0.35f, 0.35f);

            display = Mathf.Clamp(display, 0, targetWeight);

            uiYoneticisi.AgirlikYaz(display.ToString("0.00") + " Ton");

            yield return new WaitForSeconds(guncellemeAraligi);
        }

        uiYoneticisi.AgirlikYaz(targetWeight.ToString("0.00") + " Ton");

        sutKabulYoneticisi.TartimTamamlandi(targetWeight);

        weighingRoutine = null;
    }
}