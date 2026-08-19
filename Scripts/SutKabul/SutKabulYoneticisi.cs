using FabrikaOtomasyonu.Cihazlar;
using FabrikaOtomasyonu.Hatlar;
using FabrikaOtomasyonu.Sistemler;
using FabrikaOtomasyonu.Veriler;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FabrikaOtomasyonu.Yonetim
{
    public class SutKabulYoneticisi : MonoBehaviour
    {
        [Header("Baðlantýlar")]
        [SerializeField] private UIYoneticisi ui;
        [SerializeField] private NumuneAlma numuneAlma;
        [SerializeField] private KameraYoneticisi kamera;
        [SerializeField] private SutAnalizSistemi analizSistemi;
        [SerializeField] private TankerVanaAcma vanaAcma;
        [SerializeField] private TransferHatti transferHatti;
        [SerializeField] private PompaBaðlama pompaBaglama;
        [SerializeField] private ArduinoYoneticisi arduino;
        [SerializeField] private VideoManager videoManager;
        [SerializeField] private GameObject Pompa;

        [Header("Durum")]
        [SerializeField]
        private SutKabulDurumu mevcutDurum = SutKabulDurumu.Bekleniyor;

        public SutKabulDurumu MevcutDurum => mevcutDurum;

        #region Yardýmcý

        private void DurumDegistir(SutKabulDurumu yeniDurum)
        {
            mevcutDurum = yeniDurum;

            Debug.Log("<color=cyan>[SÜT KABUL]</color> => " + yeniDurum);
        }

        #endregion

        //--------------------------------------------------
        // 1
        //--------------------------------------------------

        public void TirGeldi()
        {
            DurumDegistir(SutKabulDurumu.TirFabrikayaGeldi);

            ui.AsamaTamamla(1);
            ui.DurumYaz("Týr fabrikaya giriþ yaptý.");

            kamera.KameraAc(KameraTipi.Bariyer);
        }

        //--------------------------------------------------
        // 2
        //--------------------------------------------------

        public void BariyerAcildi()
        {
            DurumDegistir(SutKabulDurumu.BariyerAcildi);

            ui.AsamaTamamla(2);
            ui.DurumYaz("Bariyer açýldý. Týr içeri girdi.");

            kamera.KameraAc(KameraTipi.Bariyer);
        }

        //--------------------------------------------------
        // 3
        //--------------------------------------------------

        public void TartimBasladi()
        {
            DurumDegistir(SutKabulDurumu.TartimBasladi);

            ui.AsamaTamamla(3);
            ui.DurumYaz("Týr tartýlýyor...");

            kamera.KameraAc(KameraTipi.Kantar);
        }

        //--------------------------------------------------
        // 4
        //--------------------------------------------------

        public void TartimTamamlandi(float agirlik)
        {
            DurumDegistir(SutKabulDurumu.TartimTamamlandi);

            ui.AsamaTamamla(4);
            ui.AgirlikYaz(agirlik.ToString("0.00") + " Ton");

            ui.DurumYaz("Tartým tamamlandý.");
        }

        //--------------------------------------------------
        // 5
        //--------------------------------------------------

        public void TartimAlaniBosaldi()
        {
            DurumDegistir(SutKabulDurumu.TartimAlaniBosaldi);

            ui.AsamaTamamla(5);

            ui.DurumYaz("Týr kantardan ayrýldý. Boþaltma alanýna doðru ilerliyor.");

            kamera.KameraAc(KameraTipi.Yol);
        }

        //--------------------------------------------------
        // 6
        //--------------------------------------------------

        public void BosaltmaAlaninaGeldi()
        {
            ui.SonrakiSayfa();
            StartCoroutine(TakozSureci());
            DurumDegistir(SutKabulDurumu.BosaltmaAlaninaGeldi);

            ui.DurumYaz("Boþaltma alanýna ulaþýldý.");

            kamera.KameraAc(KameraTipi.Takoz);
        }

        private IEnumerator TakozSureci()
        {
            yield return new WaitForSeconds(5f);
            ui.AsamaTamamla(6);

            yield return new WaitForSeconds(1f);
            ui.AsamaTamamla(7);

            yield return new WaitForSeconds(1f);
            ui.AsamaTamamla(8);

            yield return new WaitForSeconds(1.5f);
            NumuneAlindi();

        }

        //--------------------------------------------------
        // 9
        //--------------------------------------------------
        public void Karýþtýrma()
        {

        }
        public void NumuneAlindi()
        {
            ui.SonrakiSayfa();

            kamera.KameraAc(KameraTipi.Numune);

            DurumDegistir(SutKabulDurumu.NumuneAliniyor);

            numuneAlma.NumuneBaslat();

            ui.AsamaTamamla(9);

            ui.DurumYaz("Numune laboratuvar'a gönderilmek için tankerin üst kapaðýndan alýnýyor.");

            StartCoroutine(bekle2());

        }

        private IEnumerator bekle2()
        {
            yield return new WaitForSeconds(11f);
            ui.AnalizButonunuAc();
        }

        //--------------------------------------------------
        // 10
        //--------------------------------------------------

        public void AnalizYap()
        {
            ui.numuneAl();
            ui.AnalizButonunuKapat();

            SutAnalizSonucu sonuc = analizSistemi.AnalizYap();

            ui.AnalizSonucuGoster(sonuc);

            if (sonuc.kabulEdildi)
            {
                DurumDegistir(SutKabulDurumu.KabulEdildi);

                ui.DurumYaz("Süt kabul edildi.");
                ui.AsamaTamamla(11);
                //StartCoroutine(bekle());
                StartCoroutine(TransferSenaryosu());
            }
            else
            {
                DurumDegistir(SutKabulDurumu.Reddedildi);
                StartCoroutine(reddedilme());
                ui.DurumYaz("Bu sepepten dolayý reddedildi : " + sonuc.redSebebi);
            }
        }

        /*private IEnumerator bekle()
        {
            yield return new WaitForSeconds(2f);
            ui.SonrakiSayfa();
            yield return new WaitForSeconds(2f);
            HortumBaglama();
        }

        //--------------------------------------------------
        // 11
        //--------------------------------------------------

        public void HortumBaglama()
        {
            StartCoroutine(pompaBaglama.FadeAndExecute(() =>
            {
                Pompa.SetActive(true);
                kamera.KameraAc(KameraTipi.Transfer);
            }));
            StartCoroutine(bekle4());
        }
        private IEnumerator bekle4()
        {
            yield return new WaitForSeconds(6f);
            VanaAcma();
        }
        public void VanaAcma()
        {
            kamera.KameraAc(KameraTipi.Vana);
            vanaAcma.döndür();
            StartCoroutine(bekle3());
        }

        private IEnumerator bekle3()
        {
            yield return new WaitForSeconds(2f);
            TransferBaslat();
        }

        public void TransferBaslat()
        {
            if (mevcutDurum != SutKabulDurumu.KabulEdildi)
            {
                Debug.LogWarning("Numune kabul edilmeden transfer baslatýlamaz.");
                return;
            }

            DurumDegistir(SutKabulDurumu.TransferBasladi);

            ui.AsamaTamamla(12);

            ui.DurumYaz("Süt transferi basladý.");

            StartCoroutine(degis());

            transferHatti.Baslat();
        }

        private IEnumerator degis()
        {
            kamera.KameraAc(KameraTipi.Transfer);
            yield return new WaitForSeconds(5f);
            kamera.KameraAc(KameraTipi.Proses1);
            yield return new WaitForSeconds(5f);
            kamera.KameraAc(KameraTipi.Proses2);
            yield return new WaitForSeconds(5f);
            kamera.KameraAc(KameraTipi.Proses3);
            yield return new WaitForSeconds(10f);
            ui.AsamaTamamla(13);
            kamera.KameraAc(KameraTipi.Proses4);
        }

        //--------------------------------------------------
        // 12
        //--------------------------------------------------
        */
        public void TransferTamamlandi()
        {
            DurumDegistir(SutKabulDurumu.TransferTamamlandi);

            ui.DurumYaz("Transfer baþarýyla tamamlandý.");
        }

        private IEnumerator reddedilme()
        {
            yield return new WaitForSeconds(3f);
            numuneAlma.KapakKapat();
            ui.numuneAlKapa();
            yield return new WaitForSeconds(2f);
            StartCoroutine(ui.reddedildi());
            arduino.reddedildi();
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("New Scene");
        }

        private IEnumerator TransferSenaryosu()
        {
            yield return new WaitForSeconds(3f);
            numuneAlma.KapakKapat();
            ui.numuneAlKapa();
            yield return new WaitForSeconds(2f);
            StartCoroutine(ui.dogrulandý());
            yield return new WaitForSeconds(3f);

            //==================================================
            // HORTUM BAÐLAMA
            //==================================================

            ui.SonrakiSayfa();
            ui.DurumYaz("Transfer hortumu baðlanýyor...");

            yield return new WaitForSeconds(1.5f);

            yield return StartCoroutine(
                pompaBaglama.FadeAndExecute(() =>
                {
                    kamera.KameraAc(KameraTipi.Transfer);
                    Pompa.SetActive(true);
                }));

            ui.DurumYaz("Pompa baðlantýsý tamamlandý.");
            ui.AsamaTamamla(12);

            yield return new WaitForSeconds(3f);



            //==================================================
            // VANA
            //==================================================

            kamera.KameraAc(KameraTipi.Vana);

            ui.DurumYaz("Tanker'in çýkýþ vanasý açýlýyor...");
            ui.AsamaTamamla(13);

            yield return new WaitForSeconds(1.5f);

            vanaAcma.döndür();

            yield return new WaitForSeconds(4f);



            //==================================================
            // TRANSFER
            //==================================================

            kamera.KameraAc(KameraTipi.Pompa);
            ui.DurumYaz("Süt transferi baþlatýlýyor...");
            ui.AsamaTamamla(14);

            yield return new WaitForSeconds(3f);



            //==================================================
            // DEBÝMETRE
            //==================================================

            kamera.KameraAc(KameraTipi.Debimetre);

            transferHatti.Baslat();
            ui.DurumYaz("Debi ölçülüyor.");
            ui.AsamaTamamla(15);

            yield return new WaitForSeconds(3f);



            //==================================================
            // SEPERATÖR
            //==================================================

            kamera.KameraAc(KameraTipi.Proses1);

            ui.DurumYaz("Süt ön iþlemlerden geçiriliyor.");
            ui.AsamaTamamla(16);

            yield return new WaitForSeconds(6f);



            //==================================================
            // HOMOJENÝZATÖR
            //==================================================

            kamera.KameraAc(KameraTipi.Proses2);

            ui.DurumYaz("Süt soðuk depolama tankýna aktarýlýyor.");
            ui.AsamaTamamla(17);

            yield return new WaitForSeconds(10f);
            ui.SonrakiSayfa();



            //==================================================
            // PASTÖRÝZASYON
            //==================================================

            kamera.KameraAc(KameraTipi.Proses3);

            ui.DurumYaz("Süt iþleniyor...");
            ui.AsamaTamamla(18);

            yield return new WaitForSeconds(10f);



            //==================================================
            // TANK
            //==================================================

            kamera.KameraAc(KameraTipi.Proses4);

            ui.DurumYaz("Süt depolama tankýna aktarýlýyor.");
            ui.AsamaTamamla(19);


            //==================================================
            // BÝTÝÞ
            //==================================================

            ui.DurumYaz("Transfer baþarýyla tamamlandý.");
            ui.AsamaTamamla(20);
            yield return new WaitForSeconds(5f);
            ui.DurumYaz("Proses'in Digital Twin sunumu tamamamlanmýþtýr. Teþekkürler!");
            videoManager.Oynat();
        }
    }
}