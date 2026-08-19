using UnityEngine;
using UnityEngine.EventSystems;

public class HoverPanel : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler
{
    public PanelHoverController controller;

    public void OnPointerEnter(PointerEventData eventData)
    {
        controller.PanelEnter();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        controller.PanelExit();
    }
}