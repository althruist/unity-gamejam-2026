using JetBrains.Annotations;
using UnityEngine;

public class FuelTile : MonoBehaviour, IActionTile
{
    void Start()
    {
        GameManager.Instance.remainingFuelTiles++;
    }
    public Animator anim;
    public void Action(int chainID)
    {
        if (GameManager.Instance.GetChain(chainID) > 1)
            GameData.fuel += 30 * GameManager.Instance.GetChain(chainID);
        else
        {
            GameData.fuel += 30;
        }
        UIManager.Instance.Modify(UIManager.StatType.Fuel);
        anim.SetTrigger("explode");

    }

    public void OnExplodeAnimationEnd()
    {
        //Debug.Log("EXPLOSION EVENT FIRED");

        Destroy(gameObject);
        GameManager.Instance.remainingFuelTiles--;

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
