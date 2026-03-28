using UnityEngine;

public abstract class BaseBombTile : MonoBehaviour, IActionTile
{
    public int bombLevel = 1;
    protected BoxCollider2D col;

    protected virtual void Awake()
    {
        col = GetComponent<BoxCollider2D>();
    }

    public void Action()
    {
        Explode();
        Destroy(gameObject);
    }

    protected abstract void Explode(); // each bomb defines this

    protected void TriggerTile(Collider2D collider)
    {
        if (collider.CompareTag("Tile"))
        {
            IActionTile tile = collider.GetComponent<IActionTile>();
            if (tile != null)
                tile.Action();
        }
    }

    protected void DisableCollider()
    {
        if (col != null)
            col.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Laser"))
        {
            Action();
        }
    }
}