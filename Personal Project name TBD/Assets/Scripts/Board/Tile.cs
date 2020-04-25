using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject content;

    [HideInInspector] public Tile prev;

    public Vector2 point;

    public bool walkable = true;
    public GameObject trap;

    public GameObject environment;
    public bool destructable = false;

    public GameObject aura;

    public Vector2 GetTilePosition()
    {
        return point;
    }
}
