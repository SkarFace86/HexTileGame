using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // What tile is the unit currently on
    public Tile tile { get; protected set; }

    // Place the unit on to a tile
    public void Place(Tile target)
    {
        // Make sure old tile location is not still pointing to this unit
        // (remove unit from tile)
        if (tile != null && tile.content == gameObject)
            tile.content = null;

        tile = target;

        // Place the unit onto the new tile
        if (target != null)
            target.content = gameObject;
    }
}
