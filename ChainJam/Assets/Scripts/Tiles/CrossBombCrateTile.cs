using UnityEngine;

public class CrossBombCrateTile : MonoBehaviour, IActionTile
{
    public void Action()
    {
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
