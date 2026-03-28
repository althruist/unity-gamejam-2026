using UnityEngine;

public class NormalTile : MonoBehaviour, IActionTile
{
    public void Action()
    {
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
