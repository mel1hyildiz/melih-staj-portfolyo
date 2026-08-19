using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TırWaypoint : MonoBehaviour
{
    [Header("Sonraki Waypoint")]
    public TırWaypoint nextWaypoint;

    [Header("Hedef Hız")]
    public float targetSpeed = 8f;

    [Header("Bekleme")]
    public bool waitHere = false;

    public float waitTime = 6f;

    [Header("Gizmos")]
    public float pointSize = 0.35f;
    public Color pointColor = Color.green;
    public Color waitPointColor = Color.yellow;
    public Color lineColor = Color.cyan;

    public TırWaypoint GetNextWaypoint()
    {
        return nextWaypoint;
    }

    private void OnDrawGizmos()
    {
        // Nokta rengi
        Gizmos.color = waitHere ? waitPointColor : pointColor;

        // Nokta
        Gizmos.DrawSphere(transform.position, pointSize);

        // Çizgi
        if (nextWaypoint != null)
        {
            Gizmos.color = lineColor;
            Gizmos.DrawLine(transform.position, nextWaypoint.transform.position);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.white;
        Handles.Label(transform.position + Vector3.up * 0.6f, gameObject.name);
    }
#endif
}