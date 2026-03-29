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

    public void Show(string message, BombType bombType, Color? cardColor = null, Color? textColor = null)
    {
        panel.SetActive(true);

        panel.GetComponent<Image>().color = cardColor ?? Color.white;
        text.color = textColor ?? Color.black;

        int level = GetBombLevel(bombType);

        text.text = $"{message} Lv{level}";

        Cursor.SetCursor(hoverCursor, hotspot, CursorMode.Auto);
    }

    int GetBombLevel(BombType type)
    {
        switch (type)
        {
            case BombType.Bomb:
                return GameData.bombLevel;

            case BombType.CrossBomb:
                return GameData.crossBombLevel;

            case BombType.PlusBomb:
                return GameData.plusBombLevel;

            case BombType.None:
            default:
                return 0;
        }
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