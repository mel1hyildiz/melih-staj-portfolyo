using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PompaBağlama : MonoBehaviour
{
    public Image fadeImage;
    public GameObject Image;
    public float fadeDuration = 0.5f;

    public IEnumerator FadeOut()
    {
        float t = 0;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            Color c = fadeImage.color;
            c.a = Mathf.Lerp(0, 1, t / fadeDuration);
            fadeImage.color = c;
            yield return null;
        }
    }

    public IEnumerator FadeIn()
    {
        float t = 0;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            Color c = fadeImage.color;
            c.a = Mathf.Lerp(1, 0, t / fadeDuration);
            fadeImage.color = c;
            yield return null;
        }
    }

    public IEnumerator FadeAndExecute(System.Action action)
    {
        Image.SetActive(true);
        yield return FadeOut();

        action?.Invoke();

        yield return FadeIn();

        yield return new WaitForSeconds(1f);
        Image.SetActive(false);
    }
}