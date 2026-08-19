using System;
using System.Collections.Generic;
using UnityEngine;

namespace FabrikaOtomasyonu.Yonetim
{
    [Serializable]
    public class KameraGrubu
    {
        public KameraTipi kameraTipi;

        public List<GameObject> kameralar = new List<GameObject>();
    }
}