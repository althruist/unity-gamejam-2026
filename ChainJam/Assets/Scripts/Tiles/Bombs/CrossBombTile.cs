using UnityEngine;
using System.Collections.Generic;

public class CrossBombTile : BaseBombTile
{
    protected override IEnumerable<Vector3> GetExplosionOffsets()
    {
        int size = GameData.crossBombLevel;

        for (int i = 1; i <= size; i++)
        {
            yield return new Vector3(-i, i, 0);
            yield return new Vector3(i, i, 0);
            yield return new Vector3(-i, -i, 0);
            yield return new Vector3(i, -i, 0);
        }
    }
}