using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private Transform player;

    [SerializeField]
    private float followSpeed = 4f;

    private Vector3 offset;

    void Awake() {
        offset = transform.position - player.position;
    }

    void Update() {
        transform.position = Vector3.Lerp(
            transform.position,
            player.position + offset,
            followSpeed * Time.deltaTime);
    }

}
