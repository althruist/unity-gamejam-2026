using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;

    public BombType selectedBomb = BombType.None;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectBomb(BombType type)
    {
        // Check if player has bombs
        if (GetAmount(type) <= 0)
            return;

        selectedBomb = type;
        Debug.Log("Selected: " + type);
    }

    public int GetAmount(BombType type)
    {
        switch (type)
        {
            case BombType.Bomb: return GameData.bombAmount;
            case BombType.CrossBomb: return GameData.crossBombAmount;
            case BombType.PlusBomb: return GameData.plusBombAmount;
        }
        return 0;
    }

    public void UseBomb(BombType type)
    {
        switch (type)
        {
            case BombType.Bomb: GameData.bombAmount--; break;
            case BombType.CrossBomb: GameData.crossBombAmount--; break;
            case BombType.PlusBomb: GameData.plusBombAmount--; break;
        }

        selectedBomb = BombType.None; // reset after placing
    }
}