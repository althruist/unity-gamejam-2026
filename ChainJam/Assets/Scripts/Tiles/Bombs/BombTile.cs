using UnityEngine;
using System.Collections.Generic;

public class BombTile : BaseBombTile
{
    protected override IEnumerable<Vector3> GetExplosionOffsets()
    {
        int size = GameData.bombLevel;

        for (int x = -size; x <= size; x++)
        {
            for (int y = -size; y <= size; y++)
            {
                yield return new Vector3(x, y, 0);
            }
        }
    }
}