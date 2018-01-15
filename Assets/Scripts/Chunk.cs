using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour {

    private static int chunkNum;

    public static Chunk Generate() {
        GameObject parent = new GameObject();
        Chunk chunk = parent.AddComponent<Chunk>();
        chunk.Init(chunkNum++);
        return chunk;
    }

    [SerializeField]
    private PoolObject poolObject;

    #region PROPERTIES
    public PoolObject PoolObject {
        get {
            return poolObject;
        }

        private set {
            poolObject = value;
        }
    }
    #endregion

    public void Init(int num) {
        gameObject.name = "Chunk #" + chunkNum;
        PoolObject = new PoolObject();
    }

    public void AddWalls(params GameObject[] objects) {
        SetParent(objects);
        PoolObject.Walls.AddRange(objects);
    }

    public void AddTrees(params GameObject[] objects) {
        SetParent(objects);
        PoolObject.Trees.AddRange(objects);
    }

    public void AddLoot(params GameObject[] objects) {
        SetParent(objects);
        PoolObject.Loot.AddRange(objects);
    }

    private void SetParent(params GameObject[] objects) {
        foreach (var obj in objects) {
            obj.transform.SetParent(transform);
        }
    }
    
    public void Disable(params GameObject[] objects) {
        foreach (var obj in objects) {
            obj.SetActive(false);
        }
    }
    

}
