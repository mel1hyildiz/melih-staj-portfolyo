using UnityEngine;

namespace FabrikaOtomasyonu.Cihazlar
{
    public class TankSeviyesi : MonoBehaviour
    {
        [Header("Tank")]

        [SerializeField] private float kapasite = 25000f;

        public float MevcutLitre { get; private set; }

        public float DolulukYuzdesi
        {
            get
            {
                return (MevcutLitre / kapasite) * 100f;
            }
        }

        public void SutEkle(float litre)
        {
            MevcutLitre += litre;

            if (MevcutLitre > kapasite)
                MevcutLitre = kapasite;
        }

        public void SutCikar(float litre)
        {
            MevcutLitre -= litre;

            if (MevcutLitre < 0)
                MevcutLitre = 0;
        }

        public bool TankDolu()
        {
            return MevcutLitre >= kapasite;
        }

        public bool TankBos()
        {
            return MevcutLitre <= 0;
        }

        public void Sifirla()
        {
            MevcutLitre = 0;
        }
    }
}