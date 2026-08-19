using UnityEngine;

namespace FabrikaOtomasyonu.Yonetim
{
    public class FabrikaYoneticisi : MonoBehaviour
    {
        [Header("Modüller")]
        [SerializeField] private SutKabulYoneticisi sutKabulYoneticisi;

        public SutKabulYoneticisi SutKabul => sutKabulYoneticisi;

        private void Awake()
        {
            if (sutKabulYoneticisi == null)
            {
                Debug.LogError("Süt Kabul Yöneticisi atanmamýþ!");
            }
        }

        private void Start()
        {
            Debug.Log("<color=green>Fabrika Otomasyonu Baþlatýldý.</color>");
        }
    }
}