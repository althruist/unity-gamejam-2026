using UnityEngine;

public class CrossBombTile : MonoBehaviour, IActionTile
{
    public int bombLevel = 1;

    public void Action()
    {
        GetComponent<BoxCollider2D>().enabled = false;

        for (int i = 1; i <= bombLevel; i++)
        {
            RaycastHit2D hitTL = Physics2D.Raycast(transform.position + new Vector3(-i,i,0), Vector2.down, 0.1f);

            if (hitTL && hitTL.collider.tag == "Tile")
            {
                hitTL.collider.GetComponent<IActionTile>().Action();
            }

            RaycastHit2D hitTR = Physics2D.Raycast(transform.position + new Vector3(i, i, 0), Vector2.down, 0.1f);

            if (hitTR && hitTR.collider.tag == "Tile")
            {
                hitTR.collider.GetComponent<IActionTile>().Action();
            }

            RaycastHit2D hitBL = Physics2D.Raycast(transform.position + new Vector3(-i, -i, 0), Vector2.down, 0.1f);

            if (hitBL && hitBL.collider.tag == "Tile")
            {
                hitBL.collider.GetComponent<IActionTile>().Action();
            }

            RaycastHit2D hitBR = Physics2D.Raycast(transform.position + new Vector3(i, -i, 0), Vector2.down, 0.1f);

            if (hitBR && hitBR.collider.tag == "Tile")
            {
                hitBR.collider.GetComponent<IActionTile>().Action();
            }

        }
        Destroy(gameObject);
    }
}
