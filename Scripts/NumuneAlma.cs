using System.Collections;
using UnityEngine;
using FabrikaOtomasyonu.Yonetim;

namespace FabrikaOtomasyonu.Cihazlar
{
    public class NumuneAlma : MonoBehaviour
    {
        [Header("Animatör")]
        [SerializeField] private Animator animator;

        [Header("UI")]
        [SerializeField] private UIYoneticisi uiYoneticisi;

        [Header("Animasyon Süreleri")]
        [SerializeField] private float kapakAcmaSuresi = 2f;

        [SerializeField] private float cubukInmeSuresi = 3f;

        [SerializeField] private float beklemeSuresi = 2f;

        [Header("Gameobject'ler")]
        [SerializeField] private GameObject cubuk1;
        [SerializeField] private GameObject cubuk2;
        [SerializeField] private GameObject cubuk3;
        [SerializeField] private GameObject cubuk4;

        [SerializeField] private GameObject karýstýrmaAparati1;
        [SerializeField] private GameObject karýstýrmaAparati2;
        [SerializeField] private GameObject karýstýrmaAparati3;
        [SerializeField] private GameObject karýstýrmaAparati4;

        public void NumuneBaslat()
        {
            StartCoroutine(NumuneRutini());
        }

        private IEnumerator NumuneRutini()
        {
            // Kapak Aç
            animator.SetTrigger("KapakAc");

            yield return new WaitForSeconds(kapakAcmaSuresi);

            // UI Güncelle
            uiYoneticisi.AsamaTamamla(9);

            karýstýrmaAparati1.SetActive(true);
            karýstýrmaAparati2.SetActive(true);
            karýstýrmaAparati3.SetActive(true);
            karýstýrmaAparati4.SetActive(true);
            animator.SetTrigger("Karýstýr");
            yield return new WaitForSeconds(4f);
            karýstýrmaAparati1.SetActive(false);
            karýstýrmaAparati2.SetActive(false);
            karýstýrmaAparati3.SetActive(false);
            karýstýrmaAparati4.SetActive(false);

            // Karýþtýrýldý
            uiYoneticisi.AsamaTamamla(10);

            yield return new WaitForSeconds(2f);
            cubuk1.SetActive(true);
            cubuk2.SetActive(true);
            cubuk3.SetActive(true);
            cubuk4.SetActive(true);

            // Çubuk Ýnsin
            animator.SetTrigger("Cubuk");

            yield return new WaitForSeconds(cubukInmeSuresi);
            cubuk1.SetActive(false);
            cubuk2.SetActive(false);
            cubuk3.SetActive(false);
            cubuk4.SetActive(false);

            yield return new WaitForSeconds(beklemeSuresi);
        }

        public void KapakKapat()
        {
            animator.SetTrigger("KapakKapat");
        }
    }
}