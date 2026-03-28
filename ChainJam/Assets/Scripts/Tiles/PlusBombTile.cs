using UnityEngine;

public class PlusBombTile : MonoBehaviour, IActionTile
{
    public int bombLevel = 1;

    public void Action()
    {
        RaycastHit2D[] hitsVert = Physics2D.RaycastAll(transform.position + (Vector3.up * (bombLevel )), Vector2.down, (bombLevel * 2));
        RaycastHit2D[] hitsHori = Physics2D.RaycastAll(transform.position + (Vector3.left * (bombLevel )), Vector2.right, (bombLevel * 2));

        GetComponent<BoxCollider2D>().enabled = false;

        for (int i = hitsVert.Length - 1; i >= 0; i--)
        {
            if (hitsVert[i] && hitsVert[i].collider.tag == "Tile")
            {
                hitsVert[i].collider.GetComponent<IActionTile>().Action();
                //Debug.Log(i);
            }
        }

        for (int i = hitsHori.Length - 1; i >= 0; i--)
        {
            if (hitsHori[i] && hitsHori[i].collider.tag == "Tile")
            {
                hitsHori[i].collider.GetComponent<IActionTile>().Action();
                //Debug.Log(i);
            }
        }

        Destroy(gameObject);
    }
}
