using UnityEngine;

public class EnergyTile : MonoBehaviour, IActionTile
{
    public void Action()
    {
        GameData.energy += 100;
    }
}
