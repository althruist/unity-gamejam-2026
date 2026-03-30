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

    private IEnumerator ExplodeSequence()
    {
        DisableCollider();

        if (anim != null)
        {
            anim.SetTrigger("explode");
            yield break; 
        }

        
        DoExplosion();
    }

    
    public void OnExplodeAnimationEnd()
    {
        DoExplosion();
    }

    
    private void DoExplosion()
    {
        foreach (Vector3 offset in GetExplosionOffsets())
        {
            CheckAndTrigger(offset);
        }

        GameManager.Instance.DeleteChain(chainID, currentChain);
        Destroy(gameObject);
    }

    
    protected abstract IEnumerable<Vector3> GetExplosionOffsets();

    
    protected void CheckAndTrigger(Vector3 offset)
    {
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position + offset,
            Vector2.down,
            0.1f
        );

        if (hit.collider != null)
            TriggerTile(hit.collider, chainID);
    }

    
    public virtual void ShowRange()
    {
        foreach (var offset in GetExplosionOffsets())
        {
            Highlight(offset);
        }
    }

    public virtual void HideRange()
    {
        foreach (var offset in GetExplosionOffsets())
        {
            ResetTile(offset);
        }
    }

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

    protected void TriggerTile(Collider2D collider, int chainID)
    {
        if (collider.CompareTag("Tile"))
        {
            IActionTile tile = collider.GetComponent<IActionTile>();
            if (tile != null)
                tile.Action(chainID);
        }
    }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Laser"))
        {
            chainID = collision.GetComponent<Laser>().chainID;
            Action(chainID);
        }
    }
}