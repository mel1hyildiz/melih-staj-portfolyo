using System.Collections;
using TMPro;
using UnityEngine;

public class AnalizText : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void Start()
    {
        StartCoroutine(loading());
    }

    private IEnumerator loading()
    {
        yield return new WaitForSeconds(0.5f);
        text.text = "Analiz Ediliyor.";
        yield return new WaitForSeconds(0.5f);
        text.text = "Analiz Ediliyor..";
        yield return new WaitForSeconds(0.5f);
        text.text = "Analiz Ediliyor...";
        yield return new WaitForSeconds(0.5f);
        text.text = "Analiz Ediliyor.";
        yield return new WaitForSeconds(0.5f);
        text.text = "Analiz Ediliyor..";
        yield return new WaitForSeconds(0.5f);
        text.text = "Analiz Ediliyor...";
    }
}
