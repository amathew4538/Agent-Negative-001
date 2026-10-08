using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;

public class DungeonGenerator : MonoBehaviour
{
    [System.Serializable]
    public struct MetroTiles
    {
        public TileBase track;
        public TileBase trackTurn;
        public TileBase trackTunnel;
        public TileBase yellowLineOne;
        public TileBase yellowLineTwo;
        public TileBase yellowLineThree;
        public TileBase topLeftCorner;
        public TileBase transitionTopLeftWall;
        public TileBase topMiddleWall;
        public TileBase transitionTopRightWall;
        public TileBase topRightCorner;
        public TileBase bottomLeftCorner;
        public TileBase insideTopLeftWall;
        public TileBase insideTopRightWall;
        public TileBase transitionBottomLeftWall;
        public TileBase bottomMiddleWall;
        public TileBase transitionBottomRightWall;
        public TileBase bottomRightCorner;
        public TileBase insideBottomLeftWall;
        public TileBase insideBottomRightWall;
        public TileBase leftWall;
        public TileBase rightWall;
        public TileBase floorOne;
        public TileBase floorTwo;
        public TileBase floorThree;
    }
    public MetroTiles tiles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
