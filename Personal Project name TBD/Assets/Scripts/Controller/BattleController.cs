using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public Board board;

    public GameObject player;
    public GameObject enemy;

    private void Start()
    {
        InitializeGame();
    }

    void InitializeGame()
    {
        PlaceUnit();
    }

    void PlaceUnit()
    {
        int rand = Random.Range(0, board.walkableTiles.Count);

        Instantiate(player, board.walkableTiles[rand].point, Quaternion.identity);
    }
}
