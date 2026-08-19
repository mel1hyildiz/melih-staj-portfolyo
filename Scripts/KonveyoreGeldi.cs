using FabrikaOtomasyonu.Cihazlar;
using System.Collections;
using UnityEngine;

public class KonveyoreGeldi : MonoBehaviour
{
    public KonveyorYol konveyor;
    bool git = false;
    private void OnTriggerEnter(Collider other)
    {
        if(git == false)
        {
            if (other.CompareTag("Box"))
            {
                git = true;
                konveyor.IleriGit();
            }
        }
    }
}
