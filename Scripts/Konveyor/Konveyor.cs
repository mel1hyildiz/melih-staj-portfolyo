using System.Collections.Generic;
using UnityEngine;
using FabrikaOtomasyonu.Urunler;

namespace FabrikaOtomasyonu.Cihazlar
{
    public class Konveyor : FabrikaCihazi
    {
        [SerializeField] private AyranBardagi bardakPrefab;

        [SerializeField] private List<Transform> noktalar;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                BardakOlustur();
            }
        }
        public void BardakOlustur()
        {
            AyranBardagi bardak = Instantiate(
                bardakPrefab,
                noktalar[0].position,
                noktalar[0].rotation);

            bardak.YoluAyarla(noktalar);
        }
    }
}