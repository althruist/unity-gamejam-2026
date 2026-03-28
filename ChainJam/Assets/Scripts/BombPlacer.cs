using UnityEngine;

public class BombPlacer : MonoBehaviour
{
    public GameObject bombPrefab;
    public GameObject crossBombPrefab;
    public GameObject plusBombPrefab;

    void Update()
    {
        if (ShopManager.Instance.selectedBomb == BombType.None)
            return;

        if (Input.GetMouseButtonUp(0)) // release instead of click
        {
            TryPlaceBomb();
        }
    }

    void TryPlaceBomb()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.collider.GetComponent<NormalTile>())
            {
                PlaceBomb(hit.collider.transform.position);
                Destroy(hit.collider.gameObject);

                ShopManager.Instance.UseBomb(ShopManager.Instance.selectedBomb);
            }
        }
    }

    void PlaceBomb(Vector2 pos)
    {
        switch (ShopManager.Instance.selectedBomb)
        {
            case BombType.Bomb:
                Instantiate(bombPrefab, pos, Quaternion.identity);
                break;

            case BombType.CrossBomb:
                Instantiate(crossBombPrefab, pos, Quaternion.identity);
                break;

            case BombType.PlusBomb:
                Instantiate(plusBombPrefab, pos, Quaternion.identity);
                break;
        }
    }
}