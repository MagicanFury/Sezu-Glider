using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Player = PlayerController;

public enum ChunkType {
    Default,
    Runway
}

public class ChunkManager : MonoBehaviour {

    const int PATH_WIDTH = 10;

    [SerializeField] private float minWallLength = 5;
    [SerializeField] private float maxWallLength = 15;
    
    private static Vector3 startPosition;

    [SerializeField]
    private Pool pool;

    #region PROPERTIES
    public static ChunkManager Instance { get; private set; }

    public Vector3 SpawnPosition {
        get {
            return startPosition;
        }
    }

    public Pool Pool {
        get {
            return pool;
        }

        private set {
            pool = value;
        }
    }

    public float RandomLength {
        get {
            return Random.Range(minWallLength, maxWallLength);
        }
    }
    #endregion

    void Awake() {
        Instance = this;
    }
    

    #region RUNWAY
    public static void GenerateRunway(Vector3 start, int pathwidth = PATH_WIDTH) {
        const int RUNWAY_LENGTH = 20;
        startPosition = Instance.GenerateRunway(start, pathwidth, RUNWAY_LENGTH);
    }

    private Vector3 GenerateRunway(Vector3 start, int pathwidth, int pathLength) {
        var chunk = Chunk.Generate();

        Vector3 position = start;
        for (int i = 0; i < pathLength; i++) {
            position = position + Player.down_left * 2f;
            GameObject[] poolCollection = {
                Pool.SpawnWall(position)
            };
            chunk.AddWalls(poolCollection);
        }
        Vector3 returnval = position;
        position = start + Player.down_right * pathwidth;
        for (int i = 0; i < pathLength; i++) {
            position = position + Player.down_left * 2f;
            GameObject[] poolCollection = {
                Pool.SpawnWall(position)
            };
            chunk.AddWalls(poolCollection);
        }
        return returnval;
    }
    #endregion

    #region PATH
    public static void Generate(int pathwidth = PATH_WIDTH) {
        startPosition = Instance.Generate(startPosition, pathwidth,
            (int) Instance.RandomLength, 
            (int) Instance.RandomLength);
    }

    private Vector3 Generate(Vector3 start, int pathwidth, int left_length, int down_length) {
        var chunk = Chunk.Generate();

        Vector3 position = start;
        Vector3 mirrorOffset = Player.down_right * pathwidth + Player.up_right * pathwidth;
        for (int i = 0; i < left_length; i++) {
            position = position + Player.down_left * 2f;
            GameObject[] poolCollection = {
                Pool.SpawnWall(position),
                Pool.SpawnWall(position + mirrorOffset)
            };
            chunk.AddWalls(poolCollection);
            if (Random.Range(1, 10) == 1) {
                chunk.AddLoot(Pool.SpawnCoin(position + mirrorOffset / 2f));
            }
        }
        for (int i = 0; i < down_length; i++) {
            position = position + Player.down_right * 2f;
            GameObject[] poolCollection = {
                Pool.SpawnWall(position),
                Pool.SpawnWall(position + mirrorOffset)
            };
            chunk.AddWalls(poolCollection);
        }
        return position;
    }
    #endregion

}