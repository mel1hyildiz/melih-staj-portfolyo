using System;
using TMPro;
using UnityEngine;

public class HMI : MonoBehaviour
{
    public GameObject HMI_Screen;
    public KontrolPaneli kontrolPaneli;
    public KontrolPaneli2 kontrolPaneli2;
    public ModChange ModChange;

    public int adetMiktarý = 0;

    public TextMeshProUGUI adet1;
    public TextMeshProUGUI adet2;
    public TextMeshProUGUI deger1;
    public TextMeshProUGUI deger2;
    public TextMeshProUGUI tarih1;
    public TextMeshProUGUI tarih2;
    public TextMeshProUGUI saat1;
    public TextMeshProUGUI saat2;
    public bool Açýk = false;
    void Update()
    {
        // Tarih
        tarih1.text = DateTime.Now.ToString("dd/MM/yyyy");
        tarih2.text = DateTime.Now.ToString("dd/MM/yyyy");

        // Saat
        saat1.text = DateTime.Now.ToString("HH:mm:ss tt");
        saat2.text = DateTime.Now.ToString("HH:mm:ss tt");

        if(ModChange.uretim)
        {
            kontrolPaneli.t7 = false;
        }
        if (!ModChange.uretim)
        {
            kontrolPaneli.t7 = true;
        }
        if(ModChange.cip)
        {
            kontrolPaneli2.t7 = false;
        }
        if (ModChange.cip)
        {
            kontrolPaneli2.t7 = true;
        }

    }

    public void HMI_Aç_Kapa()
    {
        if(!Açýk)
        {
            HMI_Screen.SetActive(true);
            Açýk = true;
        }
        else if (Açýk)
        {
            HMI_Screen.SetActive(false);
            Açýk = false;
        }
    }

    public void KutuSay()
    {
        adetMiktarý++;

        adet1.text = adetMiktarý.ToString();
        adet2.text = adetMiktarý.ToString();
    }

    public void DegerUret()
    {
        int deger = 17800;
        deger1.text = "+" + deger.ToString();
        deger2.text = "+" + deger.ToString();
    }
}
