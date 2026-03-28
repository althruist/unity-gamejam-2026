using UnityEngine;

public class BombTile : MonoBehaviour, IActionTile
{
    public int bombLevel = 1;

    public void Action()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, new Vector2((bombLevel * 2) - 1 , (bombLevel * 2) - 1), 0.0f, Vector2.zero);

        GetComponent<BoxCollider2D>().enabled = false;
        for (int i = hits.Length - 1; i >= 0; i--)
        {
            if (hits[i] && hits[i].collider.tag == "Tile")
            {
                hits[i].collider.GetComponent<IActionTile>().Action();
                //Debug.Log(i);
            }
        }
        Destroy(gameObject);
    }
}
