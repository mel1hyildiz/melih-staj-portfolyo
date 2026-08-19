using UnityEngine;
using System;
using System.Collections;

namespace FabrikaOtomasyonu.Cihazlar
{
    public class Boru : FabrikaCihazi
    {
        [Header("Süt Görseli")]

        [SerializeField] private GameObject sut;

        [SerializeField] private float dolumSuresi = 1f;

        [SerializeField]
        private AkisEkseni akisEkseni = AkisEkseni.Z;

        [Header("Dolum Ayarlarý")]
        [SerializeField] private float maksimumDoluluk = 1f;

        private float doluluk;
        public bool TamamenDoldu => doluluk >= 1f;

        public void AkisiBaslat()
        {
            Baslat();
        }

        public void AkisiDurdur()
        {
            Durdur();

            doluluk = 0;

            GorseliGuncelle();
        }

        public void AkisiGuncelle(float deltaTime)
        {
            if (!Calisiyor)
                return;

            doluluk += deltaTime / dolumSuresi;

            doluluk = Mathf.Clamp01(doluluk);

            GorseliGuncelle();
        }

        private void GorseliGuncelle()
        {
            if (sut == null)
                return;

            Vector3 scale = sut.transform.localScale;

            switch (akisEkseni)
            {
                case AkisEkseni.X:
                    scale.x = doluluk * maksimumDoluluk;
                    break;

                case AkisEkseni.Y:
                    scale.y = doluluk * maksimumDoluluk;
                    break;

                case AkisEkseni.Z:
                    scale.z = doluluk * maksimumDoluluk;
                    break;
            }

            sut.transform.localScale = scale;
        }

        public enum AkisEkseni
        {
            X,
            Y,
            Z
        }
    }
}