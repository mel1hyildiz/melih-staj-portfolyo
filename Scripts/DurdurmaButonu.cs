using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class DurdurmaDevamEtmeButonu : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool SimDurdu = false;
    public GameObject Durdu;
    public GameObject Devam;
    private void Update()
    {
        if (SimDurdu == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Hýz();
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                Normal();
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Hýz();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Normal();
    }
    public void Hýz()
    {
        Time.timeScale = 3f;
    }

    public void Normal()
    {
        Time.timeScale = 1f;
    }
    public void Durdur()
    {
        SimDurdu = true;
            Time.timeScale = 0f;
            Devam.SetActive(true);
            Durdu.SetActive(false);
    }

    public void DevamEt()
    {
        SimDurdu = false;
            Time.timeScale = 1f;
            Durdu.SetActive(true);
            Devam.SetActive(false);
    }

    public void Yeniden()
    {
        SceneManager.LoadScene("New Scene");
    }
}
