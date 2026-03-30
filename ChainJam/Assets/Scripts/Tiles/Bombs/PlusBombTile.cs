using System.Collections.Generic;
using UnityEngine;

public class PlusBombTile : BaseBombTile
{
    protected override IEnumerable<Vector3> GetExplosionOffsets()
    {
        for (int i = 1; i <= GameData.plusBombLevel; i++)
        {
            yield return Vector3.up * i;
            yield return Vector3.down * i;
            yield return Vector3.left * i;
            yield return Vector3.right * i;
        }
    }
}