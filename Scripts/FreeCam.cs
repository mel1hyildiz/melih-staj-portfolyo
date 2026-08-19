using UnityEngine;

public class FreeCam : MonoBehaviour
{
    [Header("Hareket")]
    public float moveSpeed = 8f;
    public float smoothTime = 0.08f;

    [Header("Mouse")]
    public float lookSensitivity = 2f;

    [Header("Zoom")]
    public float zoomSpeed = 15f;

    private Vector3 currentVelocity;

    private float rotationX;
    private float rotationY;

    private bool aktif = false;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotationX = angles.y;
        rotationY = angles.x;
    }

    void Update()
    {
        if (!aktif)
            return;

        MouseLook();
        Move();
        Zoom();
    }

    public void KameraBaslat()
    {
        aktif = true;
    }

    public void KameraDurdur()
    {
        aktif = false;
    }

    void MouseLook()
    {
        if (Input.GetMouseButton(1))
        {
            rotationX += Input.GetAxis("Mouse X") * lookSensitivity;
            rotationY -= Input.GetAxis("Mouse Y") * lookSensitivity;

            rotationY = Mathf.Clamp(rotationY, -89f, 89f);

            Quaternion targetRotation = Quaternion.Euler(rotationY, rotationX, 0);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                Time.deltaTime * 15f);
        }
    }

    void Move()
    {
        Vector3 direction = Vector3.zero;

        direction += transform.forward * Input.GetAxisRaw("Vertical");
        direction += transform.right * Input.GetAxisRaw("Horizontal");

        // Space = Yukarý
        if (Input.GetKey(KeyCode.Space))
            direction += Vector3.up;

        // Shift = Aþaðý
        if (Input.GetKey(KeyCode.LeftShift))
            direction += Vector3.down;

        direction.Normalize();

        Vector3 targetVelocity = direction * moveSpeed;

        currentVelocity = Vector3.Lerp(
            currentVelocity,
            targetVelocity,
            Time.deltaTime / smoothTime);

        transform.position += currentVelocity * Time.deltaTime;
    }

    void Zoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (Mathf.Abs(scroll) > 0.01f)
        {
            transform.position += transform.forward * scroll * zoomSpeed;
        }
    }
}