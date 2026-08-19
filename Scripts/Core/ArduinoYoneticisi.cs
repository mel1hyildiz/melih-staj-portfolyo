using FabrikaOtomasyonu.Cihazlar;
using FabrikaOtomasyonu.Sistemler;
using FabrikaOtomasyonu.Veriler;
using System.IO.Ports;
using UnityEditor;
using UnityEngine;

public class ArduinoYoneticisi : MonoBehaviour
{
    [Header("Baðlantýlar")]
    [SerializeField] private Debimetre debimetre;
    [SerializeField] private Tank tank;
    [SerializeField] private Pompa pompa;
    [SerializeField] private Vana vana;
    [SerializeField] private SutAnalizSistemi sonuc;
    [SerializeField] private SutKabulDurumu sutKabulDurumu;
    [SerializeField] private GameObject uyarý;
    [SerializeField] private GameObject HMI;

    [Header("Arduino")]
    [SerializeField] private string portAdi = "COM6";
    [SerializeField] private int baudRate = 115200;

    private SerialPort serialPort;
    private float timer;
    public bool red = false;

    private void Start()
    {
        try
        {
            serialPort = new (portAdi, baudRate);
            serialPort.Open();

            Debug.Log("<color=green>Arduino Baðlandý.</color>");
        }
        catch
        {
            Debug.LogWarning("Arduino bulunamadý.");
            uyarý.SetActive(true);
            HMI.SetActive(false);
        }
    }

    public void Cýk()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

    public void Devam()
    {
        uyarý.SetActive(false);
        HMI.SetActive(true);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.2f)
        {
            timer = 0f;

            VeriGonder();
        } 
    }
    public void reddedildi()
    {
        red = true;
    }
    private void VeriGonder()
    {
        if (serialPort == null || !serialPort.IsOpen)
            return;

        string veri =
            "FLOW=" + debimetre.AnlikDebi.ToString("0") +
            ";LEVEL=" + tank.DolulukYuzdesi.ToString("0") +
            ";PUMP=" + (pompa.Calisiyor ? 1 : 0) +
            ";VALVE=" + (vana.AcikMi ? 1 : 0) +
            ";ALARM=" + (red ? 1 : 0);

        serialPort.WriteLine(veri);
    }

    private void OnApplicationQuit()
    {
        if (serialPort != null && serialPort.IsOpen)
            serialPort.Close();
    }
}