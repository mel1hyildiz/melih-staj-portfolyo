using UnityEngine;
using FabrikaOtomasyonu.Veriler;

namespace FabrikaOtomasyonu.Sistemler
{
    public class SutAnalizSistemi : MonoBehaviour
    {
        [Header("Kabul Ýhtimali")]
        [Range(0, 100)]
        [SerializeField] private int kabulYuzdesi = 92;
        public bool AnalizBasladý = false;

        public SutAnalizSonucu AnalizYap()
        {
            SutAnalizSonucu sonuc = new SutAnalizSonucu();

            bool kabul = Random.Range(0, 100) < kabulYuzdesi;

            if (kabul)
            {
                sonuc.yag = Random.Range(3.45f, 3.95f);

                sonuc.protein = Random.Range(3.15f, 3.45f);

                sonuc.ph = Random.Range(6.60f, 6.80f);

                sonuc.sicaklik = Random.Range(3.2f, 5.5f);

                sonuc.antibiyotikVar = false;

                sonuc.kabulEdildi = true;

                sonuc.redSebebi = "";
            }
            else
            {
                sonuc.yag = Random.Range(3.45f, 3.95f);

                sonuc.protein = Random.Range(3.15f, 3.45f);

                sonuc.ph = Random.Range(6.60f, 6.80f);

                sonuc.sicaklik = Random.Range(3.2f, 5.5f);

                sonuc.antibiyotikVar = false;

                int hata = Random.Range(0, 4);

                switch (hata)
                {
                    case 0:

                        sonuc.sicaklik = Random.Range(7.0f, 11f);

                        sonuc.redSebebi = "Sýcaklýk Yüksek";

                        break;

                    case 1:

                        sonuc.ph = Random.Range(6.00f, 6.35f);

                        sonuc.redSebebi = "Asitlik Uygun Deðil";

                        break;

                    case 2:

                        sonuc.antibiyotikVar = true;

                        sonuc.redSebebi = "Antibiyotik Tespit Edildi";

                        break;

                    case 3:

                        sonuc.yag = Random.Range(2.6f, 3.0f);

                        sonuc.redSebebi = "Yað Oraný Düþük";

                        break;
                }

                sonuc.kabulEdildi = false;
            }
            return sonuc;
        }
    }
}