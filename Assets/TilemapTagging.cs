using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TilemapTagging : MonoBehaviour
{
    public TileBase[] Hazzards;
    public Tilemap HazzardMap;
    // Start is called before the first frame update
    void Start()
    {
        Tilemap tm = GetComponent<Tilemap>();
        for (int x = tm.cellBounds.xMin; x < tm.cellBounds.xMax; x++)
        {
            for (int y = tm.cellBounds.yMin; y < tm.cellBounds.yMax; y++)
            {
                if(IsHazzard(tm.GetTile(new Vector3Int(x, y, 0))))
                {
                    HazzardMap.SetTile(new Vector3Int(x, y, 0), tm.GetTile(new Vector3Int(x, y, 0)));
                    tm.SetTile(new Vector3Int(x, y, 0), null);
                }
            }
        }
    }
    private bool IsHazzard(TileBase tile)
    {
        foreach(TileBase h in Hazzards)
        {
            if(tile == h)
            {
                return true;
            }
        }
        return false;
    }
}
