using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolObject : IPoolable<PoolObject> {
    
    [SerializeField] private List<GameObject> walls;
    [SerializeField] private List<GameObject> trees;
    [SerializeField] private List<GameObject> loot;

    #region PROPERTIES
    public List<GameObject> Walls {
        get {
            return walls;
        }

        set {
            walls = value;
        }
    }

    public List<GameObject> Trees {
        get {
            return trees;
        }

        set {
            trees = value;
        }
    }

    public List<GameObject> Loot {
        get {
            return loot;
        }

        set {
            loot = value;
        }
    }
    #endregion

    public PoolObject() {
        Walls = new List<GameObject>();
        Trees = new List<GameObject>();
        Loot = new List<GameObject>();
    }
    
    public void SetVisibility(bool visible) {
        foreach (var obj in Walls) {
            obj.SetActive(visible);
        }
        foreach (var obj in Trees) {
            obj.SetActive(visible);
        }
        foreach (var obj in Loot) {
            obj.SetActive(visible);
        }
    }

    public void TransferPoolObjects(PoolObject pool) {
        SetVisibility(false);
        pool.Walls.AddRange(Walls);
        pool.Trees.AddRange(Trees);
        pool.Loot.AddRange(Loot);
        ClearPool();
    }

    public void ClearPool() {
        Walls.Clear();
        Trees.Clear();
        Loot.Clear();
    }
    
}
