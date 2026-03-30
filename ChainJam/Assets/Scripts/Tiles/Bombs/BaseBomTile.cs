using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class BaseBombTile : MonoBehaviour, IActionTile
{
    protected BoxCollider2D col;   
    protected Animator anim;       
    protected int chainID;         
    private int currentChain;      


    protected virtual void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }


    public void Action(int chainID)
    {
        this.chainID = chainID;

        
        currentChain = GameManager.Instance.IncreaseChain(chainID);

        
        StartCoroutine(ExplodeSequence());
    }

    // Handles explosion flow (animation first, then logic)
    private IEnumerator ExplodeSequence()
    {
        
        DisableCollider();

        // If an animation exists, play it first
        if (anim != null)
        {
            anim.SetTrigger("explode");

            // Wait for animation event instead of continuing immediately
            yield break;
        }

        // If no animation, explode instantly
        DoExplosion();
    }

    // Called from animation event when explosion animation ends
    public void OnExplodeAnimationEnd()
    {
        DoExplosion();
    }

    // Core explosion logic
    private void DoExplosion()
    {
        // Loop through all positions this bomb affects
        foreach (Vector3 offset in GetExplosionOffsets())
        {
            CheckAndTrigger(offset);
        }

        // Remove this bomb from the chain system
        GameManager.Instance.DeleteChain(chainID, currentChain);

        // Destroy the bomb object
        Destroy(gameObject);
    }

    // Each bomb type defines its own explosion pattern
    protected abstract IEnumerable<Vector3> GetExplosionOffsets();

    // Checks if there's a tile at the offset and triggers it
    protected void CheckAndTrigger(Vector3 offset)
    {
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position + offset,
            Vector2.down,
            0.1f
        );

        // If something was hit, trigger it
        if (hit.collider != null)
            TriggerTile(hit.collider, chainID);
    }

    // Show affected tiles when hovering over bomb
    public virtual void ShowRange()
    {
        foreach (var offset in GetExplosionOffsets())
        {
            Highlight(offset);
        }
    }

    // Reset tile colors when no longer hovering
    public virtual void HideRange()
    {
        foreach (var offset in GetExplosionOffsets())
        {
            ResetTile(offset);
        }
    }

    // Highlights a tile in red to show explosion range
    protected void Highlight(Vector3 offset)
    {
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position + offset,
            Vector2.down,
            0.1f
        );

        if (hit.collider != null && hit.collider.CompareTag("Tile"))
        {
            var tile = hit.collider.GetComponent<SpriteRenderer>();
            if (tile != null)
                tile.color = Color.red;
        }
    }

    // Resets tile color back to normal
    protected void ResetTile(Vector3 offset)
    {
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position + offset,
            Vector2.down,
            0.1f
        );

        if (hit.collider != null && hit.collider.CompareTag("Tile"))
        {
            var tile = hit.collider.GetComponent<SpriteRenderer>();
            if (tile != null)
                tile.color = Color.white;
        }
    }

    // Triggers another tile if it implements IActionTile
    protected void TriggerTile(Collider2D collider, int chainID)
    {
        if (collider.CompareTag("Tile"))
        {
            IActionTile tile = collider.GetComponent<IActionTile>();
            if (tile != null)
                tile.Action(chainID);
        }
    }

    // Disables collider so the bomb can't be triggered multiple times
    protected void DisableCollider()
    {
        if (col != null)
            col.enabled = false;
    }

    
    private void OnMouseEnter()
    {
        ShowRange();
    }

    
    private void OnMouseExit()
    {
        HideRange();
    }

    // Triggered when a laser hits the bomb
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Laser"))
        {
            // Get chain ID from the laser and trigger explosion
            chainID = collision.GetComponent<Laser>().chainID;
            Action(chainID);
        }
    }
}