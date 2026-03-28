using UnityEngine;

public class NormalTile : MonoBehaviour, IActionTile
{
    public void Action()
    {
        Destroy(gameObject);
    }
}
