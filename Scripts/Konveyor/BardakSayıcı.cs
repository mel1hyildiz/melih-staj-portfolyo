using FabrikaOtomasyonu.Yonetim;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FabrikaOtomasyonu.Yonetim
{
    public class BardakSayıcı : MonoBehaviour
    {
        private int bardak = 0;
        private int kalan = 24;

        PaketlemeYoneticisi paketleme;

        [SerializeField] private TextMeshProUGUI bardaksayisi;
        [SerializeField] private TextMeshProUGUI kalanbardak;

        private void Update()
        {
            bardaksayisi.text = bardak.ToString();
            kalanbardak.text = kalan.ToString();

            if (kalan == 0)
            {
                bardak = 0;
                kalan = 24;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Ayran"))
            {
                bardak++;
                kalan--;
            }
        }
    }
}
