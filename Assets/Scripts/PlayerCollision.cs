using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    [SerializeField]
    private Pool pool;

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Obstacle") {
            Debug.Log("Collision with " + other.name);
        } else if (other.tag == "Loot") {
            var chunk = other.transform.parent.GetComponent<Chunk>();
            chunk.Disable(other.gameObject);
            Score.Instance.IncrementScore();
        }
    }

}
