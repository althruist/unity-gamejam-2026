using UnityEngine;
using System.Collections;

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
        Debug.Log(currentChain);
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
        
        //Debug.Log("id" + chainID + " chain: " + currentChain);
        //Debug.Log("EXPLOSION EVENT FIRED");
        Explode();
        GameManager.Instance.DeleteChain(chainID, currentChain);
        Destroy(gameObject);
        
    }

    protected abstract void Explode();

    protected void TriggerTile(Collider2D collider, int chainID)
    {
        if (collider.CompareTag("Tile"))
        {
            IActionTile tile = collider.GetComponent<IActionTile>();
            //this.chainID = chainID;
            //Debug.Log("trigger ID" + chainID);
            if (tile != null)

                tile.Action(chainID);
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
            chainID =  collision.gameObject.GetComponent<Laser>().chainID;
            //Debug.Log("laser ID" + chainID);
            Action(chainID);
            
        }
    }
}