using UnityEngine;

public class BombTile : BaseBombTile
{
    protected override void Explode()
    {
        DisableCollider();

        RaycastHit2D[] hits = Physics2D.BoxCastAll(
            transform.position,
            new Vector2((bombLevel * 2) - 1, (bombLevel * 2) - 1),
            0f,
            Vector2.zero
        );

        foreach (var hit in hits)
        {
            if (hit.collider != null)
                TriggerTile(hit.collider);
        }
    }
}