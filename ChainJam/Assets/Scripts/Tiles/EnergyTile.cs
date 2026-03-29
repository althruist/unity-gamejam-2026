using UnityEngine;
using TMPro;

public class EnergyTile : MonoBehaviour, IActionTile
{
    public Animator anim;
    public void Action(int chainID)
    {
        
        
        anim.SetTrigger("explode");
        GameData.energy += 20;
        UIManager.Instance.Modify(UIManager.StatType.Energy);

    }

    public void OnExplodeAnimationEnd()
    {
        //Debug.Log("EXPLOSION EVENT FIRED");
        

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
