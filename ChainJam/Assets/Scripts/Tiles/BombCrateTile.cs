using UnityEngine;

public class BombCrateTile : MonoBehaviour, IActionTile
{
    public Animator anim;
    public void Action()
    {
        anim.SetTrigger("explode");

    }




    public void OnExplodeAnimationEnd()
    {
        Debug.Log("EXPLOSION EVENT FIRED");
        GameData.bombAmount++;
        Destroy(gameObject);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Normal tile hit");
        if (collision.gameObject.CompareTag("Laser"))
        {
            Action();

        }

    }
}
