using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class SurecManager : MonoBehaviour
{
    [SerializeField] AnimatorController anim;
    [SerializeField] KonveyorYol konveyor;
    [SerializeField] CameraMove kamera;
    [SerializeField] KutuSpawner kutuSpawner;
    [SerializeField] KutuSpawner2 kutuSpawner2;
    [SerializeField] Asama1Kontrol asama1;
    [SerializeField] Asama2Kontrol asama2;
    [SerializeField] Button baslatButton;
    [SerializeField] Button hmiButton;
    [SerializeField] Button DurdurButton;
    [SerializeField] Button DevamButton;

    bool baslangic = true;
    bool acýk = false;
    bool acýldý = false;
    private bool hizlandir;
    private bool duraklatildi;

    public void Baslat()
    {
        baslatButton.interactable = false;

        if (baslangic)
        {
            Baslangýc();
            StartCoroutine(kamerakontrol());
        }

        else
            StartCoroutine(Surec());
    }
    public void Durdur()
    {
        duraklatildi = true;
        Time.timeScale = 0f;

        DurdurButton.interactable = false;
        DevamButton.interactable = true;
    }

    public void Devam()
    {
        duraklatildi = false;
        Time.timeScale = Input.GetKey(KeyCode.X) ? 5f : 1f;

        DevamButton.interactable = false;
        DurdurButton.interactable = true;
    }

    private void Update()
    {
        hizlandir = Input.GetKey(KeyCode.X);

        if (!duraklatildi)
        {
            Time.timeScale = hizlandir ? 5f : 1f;
        }
    }

    void Baslangýc()
    {
        kutuSpawner2.Ac();
        baslangic = false;
        Baslat();
    }

    IEnumerator Surec()
    {
        anim.KutuAl();
        yield return new WaitForSeconds(2f);
        anim.ArkanýDön();
        yield return new WaitForSeconds(2f);
        anim.KutuIleYürü();
        yield return new WaitForSeconds(1.7f);
        anim.KutuBýrak();
        yield return new WaitForSeconds(1f);
        anim.Yürü();
        yield return new WaitForSeconds(1.7f);
        anim.Dur();
        yield return new WaitForSeconds(3f);
        kutuSpawner2.Ac();
        yield return new WaitForSeconds(1.4f);
        kutuSpawner.SpawnTheBox();
        Baslat();
    }
    IEnumerator kamerakontrol()
    {
        yield return new WaitForSeconds(4f);
        kamera.Kamera1Git();
        yield return new WaitForSeconds(2.1f);
        kamera.Kamera2Git();
        yield return new WaitForSeconds(2f);
        kamera.SetMoveTime(15f);
        kamera.Kamera3Git();
        yield return new WaitForSeconds(15f);
        kamera.Kamera4Git();
        yield return new WaitForSeconds(25f);
        kamera.SetMoveTime(2f);
        kamera.Kamera5Git();
        yield return new WaitForSeconds(7f);
        kamera.SetMoveTime(3f);
        kamera.Kamera4Git();
        hmiButton.interactable = true;
    }


    public void HMIKontrol()
    {
        acýk = !acýk;

        if(acýk)
        {
            HMIac();
            acýldý = true;
        }

        else if (!acýk && acýldý)
        {
            if(acýldý)
            {
                HMIkapa();
                acýldý = false;
            }
        }
    }
    void HMIac()
    {
        kamera.SetMoveTime(2f);
        kamera.Kamera5Git();
    }

    void HMIkapa()
    {
        kamera.SetMoveTime(3f);
        kamera.Kamera4Git();
    }


    public void ilerleme()
    {
        if (asama2.KutuVar == false)
        {
            if (asama1.bitti)
            {
                StartCoroutine(a());
            }
        }

        else if(asama2.KutuVar == true)
        {
            if (asama1.bitti && asama2.bitti)
            {
                StartCoroutine(b());
            }
        }

    }

    IEnumerator a()
    {
        konveyor.IleriGit();
        yield return new WaitForSeconds(0.5f);
        asama1.bitti = false;
    }

    IEnumerator b()
    {
        konveyor.IleriGit();
        yield return new WaitForSeconds(0.5f);
        asama1.bitti = false;
        asama2.bitti = false;
    }
}
