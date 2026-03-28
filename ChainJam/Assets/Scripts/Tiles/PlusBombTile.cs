using UnityEngine;

public class PlusBombTile : BaseBombTile
{
    protected override void Explode()
    {
        DisableCollider();

        RaycastHit2D[] hitsVert = Physics2D.RaycastAll(
            transform.position + (Vector3.up * bombLevel),
            Vector2.down,
            bombLevel * 2
        );

        RaycastHit2D[] hitsHori = Physics2D.RaycastAll(
            transform.position + (Vector3.left * bombLevel),
            Vector2.right,
            bombLevel * 2
        );

        foreach (var hit in hitsVert)
        {
            if (hit.collider != null)
                TriggerTile(hit.collider);
        }

        foreach (var hit in hitsHori)
        {
            if (hit.collider != null)
                TriggerTile(hit.collider);
        }
    }
}