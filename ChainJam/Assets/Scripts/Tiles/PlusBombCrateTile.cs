using UnityEngine;

public class PlusBombCrateTile : MonoBehaviour, IActionTile
{
    public void Action()
    {
        GameData.plusBombAmount++;
    }
}
