using UnityEngine;
using UnityEngine.EventSystems;

public class HoverTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ToolTipManager tooltip;
    [TextArea] public string message;

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.Show(message);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.Hide();
    }
}