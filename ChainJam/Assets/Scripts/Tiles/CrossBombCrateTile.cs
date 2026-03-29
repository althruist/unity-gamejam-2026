using UnityEngine;

public class CrossBombCrateTile : MonoBehaviour, IActionTile
{

    public Animator anim;
    public void Action()
    {
        anim.SetTrigger("explode");

    }




    public void OnExplodeAnimationEnd()
    {
        Debug.Log("EXPLOSION EVENT FIRED");
        GameData.crossBombAmount++;
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
