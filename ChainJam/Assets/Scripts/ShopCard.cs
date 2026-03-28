using UnityEngine;

public class ShopCard : MonoBehaviour
{
    public BombType bombType;

    public void OnClick()
    {
        ShopManager.Instance.SelectBomb(bombType);
        Debug.Log($"Selected bomb: {bombType}");
    }
}