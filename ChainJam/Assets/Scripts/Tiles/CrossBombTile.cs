using UnityEngine;

public class CrossBombTile : BaseBombTile
{
    protected override void Explode()
    {
        DisableCollider();

        for (int i = 1; i <= bombLevel; i++)
        {
            Check(new Vector3(-i, i, 0));
            Check(new Vector3(i, i, 0));
            Check(new Vector3(-i, -i, 0));
            Check(new Vector3(i, -i, 0));
        }
    }

    void Check(Vector3 offset)
    {
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position + offset,
            Vector2.down,
            0.1f
        );

        if (hit.collider != null)
            TriggerTile(hit.collider);
    }
}