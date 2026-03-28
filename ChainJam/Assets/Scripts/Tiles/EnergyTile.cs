using UnityEngine;

public class EnergyTile : MonoBehaviour, IActionTile
{
    public void Action()
    {
        GameData.energy += 100;
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
