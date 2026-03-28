using UnityEngine;

public class BombCrateTile : MonoBehaviour, IActionTile
{
    public void Action()
    {
        GameData.bombAmount++;
    }
}
