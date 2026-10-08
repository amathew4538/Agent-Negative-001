using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "TileInfo", menuName = "2D/Extras/Tile Info")]
public class TileInfo : Tile
{
    public bool isWalkable;
    public bool canBeRolledThrough;
    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);
    }
}
