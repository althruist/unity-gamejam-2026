using JetBrains.Annotations;
using UnityEngine;

public class FuelTile : MonoBehaviour, IActionTile
{

    public Animator anim;
    public void Action(int chainID)
    {
        if (!gameObject.activeSelf) return;

        GameManager.Instance.remainingFuelTiles--;

        Debug.Log("Fuel tile destroyed. Remaining: " + GameManager.Instance.remainingFuelTiles);

        if (GameManager.Instance.GetChain(chainID) > 1)
            GameData.fuel += 15 * GameManager.Instance.GetChain(chainID);
        else
            GameData.fuel += 20;

        UIManager.Instance.Modify(UIManager.StatType.Fuel);

        anim.SetTrigger("explode");

        // Prevent double triggering
        GetComponent<Collider2D>().enabled = false;
    }

    public void OnExplodeAnimationEnd()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Debug.Log("Normal tile hit");
        if (collision.gameObject.CompareTag("Laser"))
        {
            int chainID = collision.gameObject.GetComponent<Laser>().chainID;
            Action(chainID);
        }

    }
}
