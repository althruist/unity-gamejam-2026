using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipManager : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI text;

    [Header("Cursor")]
    public Texture2D hoverCursor;
    public Vector2 hotspot = Vector2.zero;
    void Start()
    {
        panel.SetActive(false);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void Show(string message, Color? cardColor = null, Color? textColor = null)
    {
        Debug.Log(message);
        panel.SetActive(true);
        panel.GetComponent<Image>().color = cardColor ?? Color.white;
        text.color = textColor ?? Color.black;
        text.text = message;

        Cursor.SetCursor(hoverCursor, hotspot, CursorMode.Auto);
    }

    public void Hide()
    {
        panel.SetActive(false);

        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    void Update()
    {
        panel.transform.position = Input.mousePosition + new Vector3(45, 35);
    }
}