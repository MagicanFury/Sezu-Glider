using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField]
    private PlayerController player;

    private ChunkManager chunkManager;

    void Awake() {
        chunkManager = ChunkManager.Instance;
    }

    void Start() {
        ChunkManager.GenerateRunway(transform.position);
        ChunkManager.Generate();
        ChunkManager.Generate();
        ChunkManager.Generate();

        StartCoroutine(TrackPlayer(player.transform));
    }
    
    IEnumerator TrackPlayer(Transform player) {

        Vector3 lastSpawn = chunkManager.SpawnPosition;
        if (Vector3.Distance(player.position, lastSpawn) < 20f) {
            ChunkManager.Generate();
        }

        yield return new WaitForSeconds(0.1f);
        StartCoroutine(TrackPlayer(player));
    }

}
