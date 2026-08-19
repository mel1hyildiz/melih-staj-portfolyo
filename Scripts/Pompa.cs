using UnityEngine;

namespace FabrikaOtomasyonu.Cihazlar
{
    public class Pompa : MonoBehaviour
    {
        [Header("Baðlantýlar")]
        [SerializeField] private Debimetre debimetre;
        [SerializeField] private TankSeviyesi tank;

        [Header("Pompa")]
        [SerializeField] private bool otomatikBaslat = false;

        [Tooltip("Pompanýn maksimum debisi (Litre/Saat)")]
        [SerializeField] private float pompaDebisi = 12000f;

        public bool Calisiyor { get; private set; }

        public void Calistir()
        {
            if (Calisiyor)
                return;

            Calisiyor = true;

            if (debimetre != null)
                debimetre.Baslat();

            Debug.Log("<color=green>Pompa Çalýþtý</color>");
        }

        public void Durdur()
        {
            if (!Calisiyor)
                return;

            Calisiyor = false;

            if (debimetre != null)
                debimetre.Durdur();

            Debug.Log("<color=red>Pompa Durdu</color>");
        }

        public void DebiAyarla(float yeniDebi)
        {
            pompaDebisi = yeniDebi;
        }

        public float DebiGetir()
        {
            return pompaDebisi;
        }
    }
}