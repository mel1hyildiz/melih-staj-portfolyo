using UnityEngine;

namespace FabrikaOtomasyonu.Cihazlar
{
    public class Vana : MonoBehaviour
    {
        public bool AcikMi { get; private set; }

        public void Ac()
        {
            AcikMi = true;

            Debug.Log("Vana Açýldý");
        }

        public void Kapat()
        {
            AcikMi = false;

            Debug.Log("Vana Kapatýldý");
        }
    }
}