using System.Collections.Generic;
using UnityEngine;

namespace FabrikaOtomasyonu.Yonetim
{
    public class KameraYoneticisi : MonoBehaviour
    {
        [SerializeField]
        private List<KameraGrubu> kameraGruplari = new();

        private KameraGrubu aktifGrup;

        public void KameraAc(KameraTipi tip)
        {
            // Önce eski grubun tüm kameralarýný kapat
            if (aktifGrup != null)
            {
                foreach (GameObject kamera in aktifGrup.kameralar)
                {
                    if (kamera != null)
                        kamera.SetActive(false);
                }
            }

            // Yeni grubu bul
            foreach (KameraGrubu grup in kameraGruplari)
            {
                if (grup.kameraTipi == tip)
                {
                    foreach (GameObject kamera in grup.kameralar)
                    {
                        if (kamera != null)
                            kamera.SetActive(true);
                    }

                    aktifGrup = grup;
                    return;
                }
            }

            Debug.LogWarning("Kamera grubu bulunamadý : " + tip);
        }

        public void TumKameralariKapat()
        {
            foreach (KameraGrubu grup in kameraGruplari)
            {
                foreach (GameObject kamera in grup.kameralar)
                {
                    if (kamera != null)
                        kamera.SetActive(false);
                }
            }
        }
    }
}