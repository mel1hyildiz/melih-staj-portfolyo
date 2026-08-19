using FabrikaOtomasyonu.Yonetim;
using System.Collections.Generic;
using UnityEngine;

namespace FabrikaOtomasyonu.Urunler
{
    public class AyranBardagi : MonoBehaviour
    {
        [SerializeField] private float hiz = 1.5f;

        [Header("Parçalar")]
        [SerializeField] private GameObject ayran;
        [SerializeField] private GameObject kapak;

        private List<Transform> noktalar;
        private int hedefIndex;

        public PaketlemeYoneticisi paketleme;

        public void YoluAyarla(List<Transform> yeniNoktalar)
        {
            noktalar = yeniNoktalar;
            hedefIndex = 0;

            transform.position = noktalar[0].position;

            ayran.SetActive(false);
            kapak.SetActive(false);
        }

        private void Update()
        {
            if (noktalar == null || hedefIndex >= noktalar.Count)
                return;

            Transform hedef = noktalar[hedefIndex];

            transform.position = Vector3.MoveTowards(
                transform.position,
                hedef.position,
                hiz * Time.deltaTime);

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                hedef.rotation,
                300 * Time.deltaTime);

            if (Vector3.Distance(transform.position, hedef.position) < 0.01f)
            {
                NoktayaUlasti(hedefIndex);

                hedefIndex++;
            }

            if (hedefIndex >= noktalar.Count)
            {
                PaketlemeYoneticisi paketleme =
                    FindFirstObjectByType<PaketlemeYoneticisi>();

                if (paketleme != null)
                {
                    paketleme.BardakPaketlendi();
                }

                Destroy(gameObject);

                return;
            }
        }

        private void NoktayaUlasti(int nokta)
        {
            switch (nokta)
            {
                case 4:
                    ayran.SetActive(true);
                    break;

                case 6:
                    kapak.SetActive(true);
                    break;
            }
        }
    }
}