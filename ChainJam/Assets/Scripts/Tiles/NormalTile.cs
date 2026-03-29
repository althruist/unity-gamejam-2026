using UnityEngine;

public class NormalTile : MonoBehaviour, IActionTile
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

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Debug.Log("Normal tile hit");
        if (collision.gameObject.CompareTag("Laser"))
        {
            Action(0);
            
        }

    }
}
