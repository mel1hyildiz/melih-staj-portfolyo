namespace FabrikaOtomasyonu.Veriler
{
    [System.Serializable]
    public class SutAnalizSonucu
    {
        public float yag;
        public float protein;
        public float ph;
        public float sicaklik;

        public bool antibiyotikVar;

        public bool kabulEdildi;

        public string redSebebi;
    }
}