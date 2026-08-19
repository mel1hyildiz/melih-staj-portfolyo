using FabrikaOtomasyonu.Yonetim;
using UnityEngine;

namespace FabrikaOtomasyonu.Cihazlar
{
    public class Takoz : MonoBehaviour
    {
        [SerializeField] private UIYoneticisi uIYoneticisi;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Týr"))
                return;

            uIYoneticisi.AsamaTamamla(6);
        }
    }
}