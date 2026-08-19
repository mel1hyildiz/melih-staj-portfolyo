using FabrikaOtomasyonu.Cihazlar;
using FabrikaOtomasyonu.Yonetim;
using System.Collections;
using UnityEngine;

namespace FabrikaOtomasyonu.Hatlar
{
    public class TransferHatti : MonoBehaviour
    {
        [Header("Süt Kabul Yöneticisi")]
        [SerializeField] private SutKabulYoneticisi sutKabulYoneticisi;

        [Header("Hat Cihazlarý")]
        [SerializeField] private Vana vana;
        [SerializeField] private Pompa pompa;
        [SerializeField] private Debimetre debimetre;
        [SerializeField] private Tank tank;

        [Header("Ayarlar")]
        [SerializeField] private bool otomatikBaslat = false;
        [SerializeField] private float simulasyonHizi = 20f;

        public bool TransferDevamEdiyor { get; private set; }

        private Coroutine transferCoroutine;

        private void Start()
        {
            if (otomatikBaslat)
                Baslat();
        }

        public void Baslat()
        {
            if (TransferDevamEdiyor)
                return;

            transferCoroutine = StartCoroutine(TransferRutini());
        }

        public void Durdur()
        {
            if (!TransferDevamEdiyor)
                return;

            TransferDevamEdiyor = false;

            pompa.Durdur();
            debimetre.Durdur();
            vana.Kapat();

            Debug.Log("<color=green>Transfer Tamamlandý</color>");

            sutKabulYoneticisi.TransferTamamlandi();
        }

        private IEnumerator TransferRutini()
        {
            TransferDevamEdiyor = true;

            Debug.Log("Transfer Baþlatýlýyor...");

            // 1) Vana aç
            if (vana != null)
            {
                vana.Ac();
                yield return new WaitForSeconds(1f);
            }

            // 2) Pompa çalýþtýr
            pompa.Calistir();

            // 3) Transfer devam ettiði sürece
            while (TransferDevamEdiyor)
            {
                // Pompanýn debisini debimetreye gönder
                debimetre.DebiGuncelle(pompa.DebiGetir());

                // Debimetreden geçen sütü tanka aktar
                float litre = (debimetre.AnlikDebi / 3600f) * Time.deltaTime * simulasyonHizi;

                tank.SutEkle(litre);

                // Tank dolduysa transferi bitir
                if (tank.TankDolu())
                {
                    Debug.Log("<color=green>Tank doldu.</color>");

                    Durdur();

                    yield break;
                }

                yield return null;
            }
        }
    }
}