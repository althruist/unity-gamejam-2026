using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BombDragUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public BombType bombType;
    public Image iconImage;

    private GameObject dragIcon;
    private RectTransform dragRect;
    private Canvas canvas;

    private void Start()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (ShopManager.Instance.GetAmount(bombType) <= 0)
            return;

        ShopManager.Instance.selectedBomb = bombType;

        dragIcon = new GameObject("DragIcon");
        dragIcon.transform.SetParent(canvas.transform, false);

        Image img = dragIcon.AddComponent<Image>();
        img.sprite = iconImage.sprite;
        img.raycastTarget = false;

        dragRect = dragIcon.GetComponent<RectTransform>();
        dragRect.sizeDelta = new Vector2(64, 64);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragIcon == null) return;

        dragRect.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragIcon != null)
            Destroy(dragIcon);
    }
}