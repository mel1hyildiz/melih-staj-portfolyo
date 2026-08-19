using UnityEngine;

namespace FabrikaOtomasyonu.Cihazlar
{
    public abstract class FabrikaCihazi : MonoBehaviour
    {
        [Header("Cihaz Bilgileri")]
        [SerializeField] protected string cihazAdi;

        [SerializeField] protected bool calisiyor;

        [SerializeField] protected bool arizali;

        public string CihazAdi => cihazAdi;

        public bool Calisiyor => calisiyor;

        public bool Arizali => arizali;

        public virtual void Baslat()
        {
            if (arizali)
                return;

            calisiyor = true;
        }

        public virtual void Durdur()
        {
            calisiyor = false;
        }

        public virtual void ArizaOlustur()
        {
            arizali = true;
            Durdur();
        }

        public virtual void ArizaTemizle()
        {
            arizali = false;
        }
    }
}