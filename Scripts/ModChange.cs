using UnityEngine;

public class ModChange : MonoBehaviour
{
    public GameObject Uretim;
    public GameObject Uretim2;
    public GameObject CIP;
    public GameObject CIP2;

    public bool uretim = false;
    public bool cip = false;

    public void UretimModu()
    {
        uretim = true;
        cip = false;
        CIP.SetActive(false);
        Uretim.SetActive(true);
    }

    public void CIPModu()
    {
        cip = true;
        uretim = false;
        Uretim.SetActive(false);
        CIP.SetActive(true);
    }
}
