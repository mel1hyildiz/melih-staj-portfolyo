using UnityEngine;
using UnityEngine.UI;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Image cursorImage;
    [SerializeField] private Sprite normalCursor;
    [SerializeField] private Sprite clickCursor;

    private void Start()
    {
        Cursor.visible = false;
        cursorImage.sprite = normalCursor;
    }

    private void Update()
    {
        transform.position = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            cursorImage.sprite = clickCursor;
        }
        else
        {
            cursorImage.sprite = normalCursor;
        }
    }
}