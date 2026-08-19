using UnityEngine;
using UnityEngine.UI;

public class SistemBaslat : MonoBehaviour
{
    public GameObject Týr;
    public Button button;

    public void SistemiBaslat()
    {
        Týr.SetActive(true);
        button.interactable = false;
    }
}
