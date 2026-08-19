using UnityEngine;

public class KutuKonveyorGetirme : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed = 1f;

    private int currentWaypoint = 0;
    private bool hareketEt = false;

    public void Baslat()
    {
        currentWaypoint = 0;
        hareketEt = true;
    }

    void Update()
    {
        if (!hareketEt) return;

        Transform target = waypoints[currentWaypoint];

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.01f)
        {
            currentWaypoint++;

            if (currentWaypoint >= waypoints.Length)
            {
                hareketEt = false;
            }
        }
    }
}