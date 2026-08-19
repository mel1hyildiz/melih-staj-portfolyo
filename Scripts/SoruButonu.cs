using UnityEngine;
using UnityEngine.EventSystems;

public class PanelHoverController : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler
{
    [SerializeField] private GameObject panel;

    private bool isPointerOnButton;
    private bool isPointerOnPanel;

    private void Start()
    {
        panel.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOnButton = true;
        panel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOnButton = false;

        Invoke(nameof(CheckHide), 0.02f);
    }

    public void PanelEnter()
    {
        isPointerOnPanel = true;
    }

    public void PanelExit()
    {
        isPointerOnPanel = false;

        Invoke(nameof(CheckHide), 0.02f);
    }

    void CheckHide()
    {
        if (!isPointerOnButton && !isPointerOnPanel)
        {
            panel.SetActive(false);
        }
    }
}