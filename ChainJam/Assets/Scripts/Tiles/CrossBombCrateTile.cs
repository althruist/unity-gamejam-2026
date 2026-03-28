using UnityEngine;

public class CrossBombCrateTile : MonoBehaviour, IActionTile
{
    public void Action()
    {
        GameData.crossBombAmount++;
    }
}
