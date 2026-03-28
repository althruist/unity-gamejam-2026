using UnityEngine;
using System.Collections;

public abstract class BaseBombTile : MonoBehaviour, IActionTile
{
    public int bombLevel = 1;
    protected BoxCollider2D col;
    protected Animator anim;

    protected virtual void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    public void Action()
    {
        StartCoroutine(ExplodeSequence());
    }

    private IEnumerator ExplodeSequence()
    {
        DisableCollider();

        if (anim != null)
        {
            anim.SetTrigger("explode");
        }

        yield break; // stop here, animation will handle the rest
    }
    public void OnExplodeAnimationEnd()
    {
        Debug.Log("EXPLOSION EVENT FIRED");
        Explode();
        Destroy(gameObject);
    }

    protected abstract void Explode();

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