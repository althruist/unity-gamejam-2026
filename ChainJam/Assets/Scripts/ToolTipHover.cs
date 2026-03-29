using UnityEngine;
using UnityEngine.EventSystems;

public class HoverTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ToolTipManager tooltip;

    [TextArea] public string message;
    public Color cardColor;
    public Color textColor;

    [SerializeField] private BombType bombType;

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.Show(message, bombType, cardColor, textColor);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.Hide();
    }
}