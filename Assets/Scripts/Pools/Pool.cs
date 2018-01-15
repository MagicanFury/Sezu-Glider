using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolObjects {
    Wall,
    Tree,
    Coin
}

[System.Serializable]
public class Pool : MonoBehaviour {

    public PoolObject genesis;
    
    [Space(20), Header("Prefabs")]
    [SerializeField] private GameObject[] walls;
    [SerializeField] private GameObject[] trees;
    [SerializeField] private GameObject[] loot;

    #region RANDOM_PROPERTIES
    public GameObject RandomWall {
        get {
            return walls[Random.Range(0, walls.Length)];
        }
    }

    public GameObject RandomTree {
        get {
            return trees[Random.Range(0, trees.Length)];
        }
    }

    public GameObject RandomLoot {
        get {
            return loot[Random.Range(0, loot.Length)];
        }
    }
    #endregion

    void Awake() {
        genesis = new PoolObject();
    }

    void Start() {

    }

    public GameObject SpawnWall(Vector3 position) {
        return Instantiate(RandomWall, position, Quaternion.identity);
    }

    public GameObject SpawnCoin(Vector3 position) {
        return Instantiate(RandomLoot, position, Quaternion.identity);
    }

}
