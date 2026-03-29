using UnityEngine;

public class TileTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            TileTestClick();
        }
    }

    void TileTestClick()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && hit.collider.tag == "Tile")
        {
            hit.collider.gameObject.GetComponent<IActionTile>().Action(0);
        }
    }
}
