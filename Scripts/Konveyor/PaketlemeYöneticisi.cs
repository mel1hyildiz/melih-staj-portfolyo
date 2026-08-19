using System.Collections.Generic;
using UnityEngine;

namespace FabrikaOtomasyonu.Yonetim
{
    public class PaketlemeYoneticisi : MonoBehaviour
    {
        [Header("Paket Ayarları")]
        [SerializeField] private GameObject paketPrefab;

        [SerializeField] private List<Transform> paketNoktalari;

        [SerializeField] private int paketBoyutu = 24;

        private int bardakSayisi;

        private int olusanPaketSayisi;

        public void BardakPaketlendi()
        {
            bardakSayisi++;

            if (bardakSayisi >= paketBoyutu)
            {
                PaketOlustur();

                bardakSayisi = 0;
            }
        }

        private void PaketOlustur()
        {
            if (olusanPaketSayisi >= paketNoktalari.Count)
            {
                Debug.Log("Paket koyacak yer kalmadı.");

                return;
            }

            Instantiate(
                paketPrefab,
                paketNoktalari[olusanPaketSayisi].position,
                paketNoktalari[olusanPaketSayisi].rotation);

            olusanPaketSayisi++;
        }
    }
}