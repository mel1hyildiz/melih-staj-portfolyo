using UnityEngine;

public class KutuGidiyor : MonoBehaviour
{
    [SerializeField] private Transform waypoint;
    [SerializeField] private Bekle bekle;
    [SerializeField] private float speed = 0.6f;

    private bool hareketEt = false;

    private void Awake()
    {
        bekle = GetComponentInChildren<Bekle>();
    }

    public void HedefAyarla(Transform hedef)
    {
        waypoint = hedef;
    }

    public void Baslat()
    {
        Debug.Log("Waypoint: " + waypoint);

        if (waypoint == null)
        {
            Debug.LogError("Waypoint atanmadı!");
            return;
        }

        hareketEt = true;
    }

    private void Update()
    {
        if (!hareketEt || waypoint == null || bekle.bekle) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            waypoint.position,
            speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoint.position) < 0.01f)
        {
            hareketEt = false;
            enabled = false;
        }
    }
}