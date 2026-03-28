using UnityEngine;

public class PlusBombTile : BaseBombTile
{
    protected override void Explode()
    {
        DisableCollider();

        RaycastHit2D[] hitsVert = Physics2D.RaycastAll(
            transform.position + (Vector3.up * GameData.plusBombLevel),
            Vector2.down,
            GameData.plusBombLevel * 2
        );

        RaycastHit2D[] hitsHori = Physics2D.RaycastAll(
            transform.position + (Vector3.left * GameData.plusBombLevel),
            Vector2.right,
            GameData.plusBombLevel * 2
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