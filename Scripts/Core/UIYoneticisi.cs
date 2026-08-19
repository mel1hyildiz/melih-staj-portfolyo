using FabrikaOtomasyonu.Veriler;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FabrikaOtomasyonu.Yonetim
{
    public class UIYoneticisi : MonoBehaviour
    {
        [Header("Fotoðraflar")]
        [SerializeField] private GameObject tik;
        [SerializeField] private GameObject çarpý;

        [Header("Aþamalar")]
        [SerializeField] private Toggle[] asamalar;

        [Header("Yazýlar")]
        [SerializeField] private TMP_Text agirlikText;
        [SerializeField] private TMP_Text agirlikPanelText;
        [SerializeField] private TMP_Text debiDeðeri;
        [SerializeField] private TMP_Text durumText;
        [SerializeField] private TMP_Text durumText2;

        [Header("Analiz Sonuçlarý")]
        [SerializeField] private TMP_Text yagText;
        [SerializeField] private TMP_Text proteinText;
        [SerializeField] private TMP_Text phText;
        [SerializeField] private TMP_Text sicaklikText;
        [SerializeField] private TMP_Text antibiyotikText;

        [Header("Butonlar")]
        [SerializeField] private Button sonrakiButonu;
        [SerializeField] private Button analizButonu;

        [Header("Sayfalar")]
        [SerializeField] private GameObject[] sayfalar;
        [SerializeField] private GameObject numuneAlýnýyor;

        private int aktifSayfa;

        public void DebiDeðeriGir(string deger)
        {
            debiDeðeri.text = deger;
        }
        public void numuneAl()
        {
            numuneAlýnýyor.SetActive(true);
        }

        public void numuneAlKapa()
        {
            numuneAlýnýyor.SetActive(false);
        }

        #region Aþamalar

        public void AsamaTamamla(int asamaNo)
        {
            if (asamaNo <= 0 || asamaNo > asamalar.Length)
                return;

            asamalar[asamaNo - 1].isOn = true;
        }

        public void AsamaSifirla()
        {
            foreach (Toggle t in asamalar)
                t.isOn = false;
        }

        #endregion

        #region Yazýlar

        public void AgirlikYaz(string yazi)
        {
            agirlikText.text = yazi;
            agirlikPanelText.text = yazi;
        }

        public void DurumYaz(string yazi)
        {
            durumText.text = yazi;
        }

        #endregion

        #region Analiz

        public void AnalizSonucuGoster(FabrikaOtomasyonu.Veriler.SutAnalizSonucu sonuc)
        {
            yagText.text = "%" + sonuc.yag.ToString("0.00");

            proteinText.text = "%" + sonuc.protein.ToString("0.00");

            phText.text = sonuc.ph.ToString("0.00");

            sicaklikText.text = sonuc.sicaklik.ToString("0.0") + " °C";

            antibiyotikText.text = sonuc.antibiyotikVar
                ? "POZÝTÝF"
                : "NEGATÝF";
        }

        public IEnumerator dogrulandý()
        {
            tik.SetActive(true);
            yield return new WaitForSeconds(0.75f);
            tik.SetActive(false);
            yield return new WaitForSeconds(0.75f);
            tik.SetActive(true);
            yield return new WaitForSeconds(1f);
            tik.SetActive(false);

        }

        public IEnumerator reddedildi()
        {
            çarpý.SetActive(true);
            yield return new WaitForSeconds(0.75f);
            çarpý.SetActive(false);
            yield return new WaitForSeconds(0.75f);
            çarpý.SetActive(true);
            yield return new WaitForSeconds(1f);
            çarpý.SetActive(false);

        }
        #endregion

        #region Butonlar

        public void SonrakiButonunuAc()
        {
            sonrakiButonu.interactable = true;
        }

        public void SonrakiButonunuKapat()
        {
            sonrakiButonu.interactable = false;
        }

        public void AnalizButonunuAc()
        {
            analizButonu.interactable = true;
        }

        public void AnalizButonunuKapat()
        {
            analizButonu.interactable = false;
        }

        #endregion

        #region Sayfalar

        public void SayfaAc(int index)
        {
            if (index < 0 || index >= sayfalar.Length)
                return;

            for (int i = 0; i < sayfalar.Length; i++)
            {
                sayfalar[i].SetActive(i == index);
            }

            aktifSayfa = index;
        }

        public void SonrakiSayfa()
        {
            if (aktifSayfa >= sayfalar.Length - 1)
                return;

            SayfaAc(aktifSayfa + 1);
        }

        public void OncekiSayfa()
        {
            if (aktifSayfa <= 0)
                return;

            SayfaAc(aktifSayfa - 1);
        }

        #endregion

        #region Reset

        public void UISifirla()
        {
            AsamaSifirla();

            AgirlikYaz("--");

            DurumYaz("Hazýr");

            yagText.text = "--";
            proteinText.text = "--";
            phText.text = "--";
            sicaklikText.text = "--";
            antibiyotikText.text = "--";

            AnalizButonunuKapat();

            SonrakiButonunuKapat();

            SayfaAc(0);
        }

        #endregion
    }
}