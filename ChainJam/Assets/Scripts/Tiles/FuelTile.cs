using UnityEngine;

public class FuelTile : MonoBehaviour, IActionTile
{
    public void Action()
    {
        GameData.fuel += 100;
    }
}
