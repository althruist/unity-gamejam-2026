using UnityEngine;
using TMPro;

public class EnergyTile : MonoBehaviour, IActionTile
{
    public Animator anim;
    public void Action(int chainID)
    {
        
        
        anim.SetTrigger("explode");

    }

    public void OnExplodeAnimationEnd()
    {
        //Debug.Log("EXPLOSION EVENT FIRED");

        Destroy(gameObject);
        GameData.energy += 100;
        UIManager.Instance.Modify(UIManager.StatType.Energy);
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
