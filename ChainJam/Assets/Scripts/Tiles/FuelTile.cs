using UnityEngine;

public class FuelTile : MonoBehaviour, IActionTile
{
    public void Action()
    {
        GameData.fuel += 100;
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
