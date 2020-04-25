using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Board : MonoBehaviour
{
    public List<Tile> walkableTiles;
    public List<Tile> notWalkableTiles;

    Vector2[] neighboringTiles = new Vector2[6] {
        new Vector2(0, 1), // North
        new Vector2(0.75f, 0.5f), // North east
        new Vector2(0.75f, -0.5f), // South east
        new Vector2(0, -1), // South
        new Vector2(-0.75f, -0.5f), // South west
        new Vector2(0.75f, 0.5f) // North west
    };

    #region Private

    private void Start()
    {
        GetAllTiles();
    }

    private void GetAllTiles()
    {
        // Get all tilemaps from children under Board game object
        Tilemap[] gridChildren = new Tilemap[gameObject.GetComponentsInChildren<Tilemap>().Length];
        gridChildren = gameObject.GetComponentsInChildren<Tilemap>();
        List<Vector3> availableTiles = new List<Vector3>();
        List<Vector2> walkable = new List<Vector2>();
        List<Vector2> notWalkable = new List<Vector2>();

        foreach (Tilemap tilemap in gridChildren) {
            for (int i = tilemap.cellBounds.xMin; i < tilemap.cellBounds.xMax; i++) {
                for (int j = tilemap.cellBounds.yMin; j < tilemap.cellBounds.yMax; j++) {
                    Vector3Int localPlace = new Vector3Int(i, j, (int)tilemap.transform.position.y);
                    Vector3 place = tilemap.CellToWorld(localPlace);
                    if (tilemap.HasTile(localPlace)) {
                        availableTiles.Add(place);
                    }
                    if(i == 1) {
                        notWalkable.Add(place);
                    }
                }
            }
        }
        walkable = GetWalkableTiles(availableTiles);

        SetupChildrenObjects(walkable, gridChildren[0], "Walkable");
        SetupChildrenObjects(notWalkable, gridChildren[1], "Not Walkable");
    }

    List<Vector2> GetWalkableTiles(List<Vector3> availableTiles)
    {
        HashSet<Vector2> tiles = new HashSet<Vector2>();
        foreach (Vector3 e in availableTiles)
            tiles.Add(e);
        List<Vector2> walkable = new List<Vector2>();
        foreach(Vector3 e in tiles) {
            walkable.Add(e);
        }
        return walkable;
    }
    private void SetupChildrenObjects(List<Vector2> tiles, Tilemap tilemap, string objName)
    {
        switch (objName) {
            case "Walkable":
                foreach (Vector2 pos in tiles) {
                    GameObject obj = new GameObject("Tile");
                    obj.transform.position = pos;
                    obj.transform.parent = tilemap.transform;
                    obj.AddComponent<Tile>();
                    Tile tile = obj.GetComponent<Tile>();
                    tile.point = pos;
                }
                break;
            case "Not Walkable": {
                    foreach (Vector2 pos in tiles) {
                        GameObject obj = new GameObject("Tile");
                        obj.transform.position = pos;
                        obj.transform.parent = tilemap.transform;
                        obj.AddComponent<Tile>();
                        Tile tile = obj.GetComponent<Tile>();
                        tile.point = pos;
                        tile.walkable = false;
                    }
                    break;
                }
        }
    }

    #endregion

    public List<Tile> Search(Tile start, Tile addTile)
    {
        List<Tile> returnValue = new List<Tile>();
        returnValue.Add(start);

        ClearSearch();
        Queue<Tile> checkNext = new Queue<Tile>();
        Queue<Tile> checkNow = new Queue<Tile>();

        checkNow.Enqueue(start);

        while(checkNow.Count > 0) {
            Tile t = checkNow.Dequeue();
            for(int i = 0; i < 6; i++) {
                
            }
        }
        return returnValue;
    }

    void ClearSearch()
    {
        foreach(Tile t in walkableTiles) {
            t.prev = null;          
        }
    }
}
