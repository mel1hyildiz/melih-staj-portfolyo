using System.Collections;
using UnityEngine;

public class TankerVanaAcma : MonoBehaviour
{
    [SerializeField] private Transform[] objectsToRotate;
    [SerializeField] private float rotateDuration = 1f;


    public void döndür()
    {
        StartCoroutine(RotateSmooth());
    }

    private IEnumerator RotateSmooth()
    {
        Quaternion[] startRotations = new Quaternion[objectsToRotate.Length];
        Quaternion[] targetRotations = new Quaternion[objectsToRotate.Length];

        for (int i = 0; i < objectsToRotate.Length; i++)
        {
            startRotations[i] = objectsToRotate[i].rotation;
            targetRotations[i] = startRotations[i] * Quaternion.Euler(0, -90, 0);
        }

        float time = 0f;

        while (time < rotateDuration)
        {
            time += Time.deltaTime;
            float t = time / rotateDuration;

            for (int i = 0; i < objectsToRotate.Length; i++)
            {
                objectsToRotate[i].rotation = Quaternion.Slerp(
                    startRotations[i],
                    targetRotations[i],
                    t
                );
            }

            yield return null;
        }

        // Son açýyý garanti et
        for (int i = 0; i < objectsToRotate.Length; i++)
        {
            objectsToRotate[i].rotation = targetRotations[i];
        }
    }
}