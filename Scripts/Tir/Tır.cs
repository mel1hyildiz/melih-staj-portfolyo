using UnityEngine;

namespace FabrikaOtomasyonu.Cihazlar
{
    public class Tır : FabrikaCihazi
    {
        [Header("Hareket Ayarları")]
        public float rotationSpeed = 90f;
        public float acceleration = 3f;

        [Header("Waypoint Ayarları")]
        public float waypointRadius = 4f;
        public TırWaypoint currentWaypoint;

        private float currentSpeed;

        private bool isWaiting = false;
        private float waitTimer = 0f;
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            if (currentWaypoint != null)
            {
                currentSpeed = currentWaypoint.targetSpeed;
            }
        }

        private void Update()
        {
            if (currentWaypoint == null)
                return;

            // Bekliyorsa hareket etme
            if (isWaiting)
            {
                waitTimer -= Time.deltaTime;

                if (waitTimer <= 0f)
                {
                    isWaiting = false;
                    GetNextTarget();
                }

                return;
            }

            MoveVehicle();
            RotateVehicle();
            CheckWaypointDistance();
        }

        private void MoveVehicle()
        {
            currentSpeed = Mathf.Lerp(
                currentSpeed,
                currentWaypoint.targetSpeed,
                acceleration * Time.deltaTime);

            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime, Space.Self);
        }

        private void RotateVehicle()
        {
            Vector3 direction = currentWaypoint.transform.position - transform.position;
            direction.y = 0;

            // Waypoint aracın arkasında kaldıysa dönme
            float dot = Vector3.Dot(transform.forward, direction.normalized);

            if (dot < 0f)
                return;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime);
        }

        private void CheckWaypointDistance()
        {
            float distance = Vector3.Distance(
                transform.position,
                currentWaypoint.transform.position);

            if (distance <= waypointRadius)
            {
                if (currentWaypoint.waitHere)
                {
                    isWaiting = true;
                    waitTimer = currentWaypoint.waitTime;
                    currentSpeed = 0f;
                }
                else
                {
                    GetNextTarget();
                }
            }
        }

        private void GetNextTarget()
        {
            TırWaypoint next = currentWaypoint.GetNextWaypoint();

            if (next != null)
            {
                currentWaypoint = next;
            }
            else
            {
                currentSpeed = 0f;
                enabled = false;
                rb.isKinematic = true;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, waypointRadius);
        }
    }
}