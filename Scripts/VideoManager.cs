using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer player;
    public GameObject video;

    public void Oynat()
    {
        video.SetActive(true);
        player.Play();
    }

    public void Durdur()
    {
        player.Stop();
    }

    public void Duraklat()
    {
        player.Pause();
    }
}