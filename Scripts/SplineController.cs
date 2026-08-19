using System.Collections;
using UnityEngine;
using UnityEngine.Splines;

public class SplineController : MonoBehaviour
{
    [SerializeField] private SplineContainer splineContainer;

    private Coroutine moveCoroutine;

    public void SetSecondKnotY(float targetY)
    {
        if (moveCoroutine != null)
            StopCoroutine(moveCoroutine);

        moveCoroutine = StartCoroutine(AnimateSecondKnotY(targetY, 1f));
    }

    private IEnumerator AnimateSecondKnotY(float targetY, float duration)
    {
        Spline spline = splineContainer.Spline;

        if (spline.Count < 2)
            yield break;

        BezierKnot knot = spline[1];

        float startY = knot.Position.y;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float t = Mathf.Clamp01(elapsed / duration);

            // Ýstersen bunu SmoothStep yerine baþka easing ile deðiþtirebilirsin.
            t = Mathf.SmoothStep(0f, 1f, t);

            Vector3 pos = knot.Position;
            pos.y = Mathf.Lerp(startY, targetY, t);

            knot.Position = pos;
            spline.SetKnot(1, knot);

            yield return null;
        }

        Vector3 finalPos = knot.Position;
        finalPos.y = targetY;
        knot.Position = finalPos;
        spline.SetKnot(1, knot);

        moveCoroutine = null;
    }
}