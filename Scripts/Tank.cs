using UnityEngine;

namespace FabrikaOtomasyonu.Cihazlar
{
    public class Tank : FabrikaCihazi
    {
        [Header("Tank Bilgileri")]
        [SerializeField] private float kapasite = 25000f;

        [SerializeField]
        private float mevcutLitre = 0f;

        [Header("Sývý Animasyonu")]
        [SerializeField]
        private Transform sivi;

        [SerializeField]
        private float minimumY = 0f;

        [SerializeField]
        private float maksimumY = 1f;

        public float Kapasite => kapasite;

        public float MevcutLitre => mevcutLitre;

        public float DolulukOrani => mevcutLitre / kapasite;

        public float DolulukYuzdesi => DolulukOrani * 100f;

        private void Start()
        {
            AnimasyonuGuncelle();
        }

        public void SutEkle(float litre)
        {
            mevcutLitre += litre;
            mevcutLitre = Mathf.Clamp(mevcutLitre, 0f, kapasite);

            AnimasyonuGuncelle();
        }

        public void SutCikar(float litre)
        {
            mevcutLitre -= litre;
            mevcutLitre = Mathf.Clamp(mevcutLitre, 0f, kapasite);

            AnimasyonuGuncelle();
        }

        public bool TankDolu()
        {
            return mevcutLitre >= kapasite;
        }

        public bool TankBos()
        {
            return mevcutLitre <= 0f;
        }

        public void Sifirla()
        {
            mevcutLitre = 0f;

            AnimasyonuGuncelle();
        }

        private void AnimasyonuGuncelle()
        {
            if (sivi == null)
                return;

            Vector3 scale = sivi.localScale;

            scale.y = Mathf.Lerp(0f, 1f, DolulukOrani);

            sivi.localScale = scale;
        }
    }
}