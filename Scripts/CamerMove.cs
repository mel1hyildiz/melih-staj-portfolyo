using System.Collections;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float moveTime = 1f;

    [Header("Kamera Noktalarý")]
    [SerializeField] private Transform kamera1;
    [SerializeField] private Transform kamera2;
    [SerializeField] private Transform kamera3;
    [SerializeField] private Transform kamera4;
    [SerializeField] private Transform kamera5;

    private Coroutine moveCoroutine;

    public void SetMoveTime(float yeniSure)
    {
        moveTime = yeniSure;
    }

    public void Kamera1Git() => Git(kamera1);
    public void Kamera2Git() => Git(kamera2);
    public void Kamera3Git() => Git(kamera3);
    public void Kamera4Git() => Git(kamera4);
    public void Kamera5Git() => Git(kamera5);

    private void Git(Transform hedef)
    {
        if (hedef == null) return;

        if (moveCoroutine != null)
            StopCoroutine(moveCoroutine);

        moveCoroutine = StartCoroutine(HareketEt(hedef));
    }

    private IEnumerator HareketEt(Transform hedef)
    {
        Vector3 baslangicPos = transform.position;
        Quaternion baslangicRot = transform.rotation;

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / moveTime;
            float smooth = Mathf.SmoothStep(0f, 1f, t);

            transform.position = Vector3.Lerp(baslangicPos, hedef.position, smooth);
            transform.rotation = Quaternion.Slerp(baslangicRot, hedef.rotation, smooth);

            yield return null;
        }

        transform.position = hedef.position;
        transform.rotation = hedef.rotation;

        moveCoroutine = null;
    }
}