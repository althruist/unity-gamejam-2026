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
        if (BombManager.Instance.GetAmount(bombType) <= 0)
            return;

        BombManager.Instance.selectedBomb = bombType;

        dragIcon = new GameObject("DragIcon");
        dragIcon.transform.SetParent(canvas.transform, false);

        Image img = dragIcon.AddComponent<Image>();
        img.sprite = iconImage.sprite;
        
        img.raycastTarget = false;
        Color c = img.color;
        c.a = 0.5f; // 0 = invisible, 1 = fully visible
        img.color = c;

        dragRect = dragIcon.GetComponent<RectTransform>();
        dragRect.sizeDelta = new Vector2(64, 64);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragIcon == null) return;

        dragRect.position = Input.mousePosition;

        // Convert mouse to world
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        Image img = dragIcon.GetComponent<Image>();

        if (hit.collider != null && hit.collider.GetComponent<NormalTile>())
        {
            
            img.color = new Color(1, 1, 1, 1f);
        }
        else
        {
            
            img.color = new Color(1, 1, 1, 0.4f);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragIcon != null)
            Destroy(dragIcon);
    }
}