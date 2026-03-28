using UnityEngine;

public class BombCrateTile : MonoBehaviour, IActionTile
{
    public void Action()
    {
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
