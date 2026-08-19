using FabrikaOtomasyonu.Yonetim;
using UnityEngine;

namespace FabrikaOtomasyonu.Cihazlar
{
    public class Debimetre : MonoBehaviour
    {
        [Header("UI Yöneticisi")]
        [SerializeField]
        private UIYoneticisi ui;

        [Header("Debimetre")]

        [SerializeField]
        private float anlikDebi;          // Litre / Saat

        [SerializeField]
        private float toplamLitre;

        public float AnlikDebi => anlikDebi;

        public float ToplamLitre => toplamLitre;

        public bool Calisiyor { get; private set; }

        public void Baslat()
        {
            Calisiyor = true;
        }

        public void Durdur()
        {
            Calisiyor = false;
            anlikDebi = 0;
        }

        public void DebiGuncelle(float debi)
        {
            if (!Calisiyor)
                return;

            anlikDebi = debi;
            ui.DebiDeðeriGir(debi.ToString());
        }

        private void Update()
        {
            if (!Calisiyor)
                return;

            // Saatlik debiyi saniyelik litreye çevir
            toplamLitre += (anlikDebi / 3600f) * Time.deltaTime;
        }

        public void Sifirla()
        {
            anlikDebi = 0;
            toplamLitre = 0;
        }
    }
}