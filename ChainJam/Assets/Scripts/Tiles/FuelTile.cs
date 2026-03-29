using UnityEngine;

public class FuelTile : MonoBehaviour, IActionTile
{
    public Animator anim;
    public void Action()
    {


        anim.SetTrigger("explode");

    }

    public void OnExplodeAnimationEnd()
    {
        Debug.Log("EXPLOSION EVENT FIRED");

        Destroy(gameObject);
        GameData.fuel += 100;
        UIManager.Instance.Modify(UIManager.StatType.Fuel);
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
