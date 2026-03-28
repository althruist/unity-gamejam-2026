using UnityEngine;

public class PlusBombCrateTile : MonoBehaviour, IActionTile
{
    public void Action()
    {
        GameData.plusBombAmount++;
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
