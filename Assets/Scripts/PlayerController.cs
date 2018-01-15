using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    private new Rigidbody rigidbody;

    public static Vector3 up_left;
    public static Vector3 up_right;
    public static Vector3 down_right;
    public static Vector3 down_left;

    void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        up_left = transform.right;
        up_right = -transform.forward;
        down_right = -transform.right;
        down_left = GetForwardVector();
    }

    public bool InputDown {
        get {
            return Input.GetKey(KeyCode.Space) || Input.touchCount > 0;
        }
    }

    private Vector3 GetForwardVector() {
        return transform.forward;
    }
    
    private float GetSteering(float y) {
        float target = InputDown ? 180 : 270;
        return Mathf.Lerp(y, target, rotateSpeed * Time.deltaTime);
    }

    void Update() {
        Vector3 euler = transform.eulerAngles;
        euler.y = GetSteering(euler.y);
        transform.eulerAngles = euler;

        rigidbody.MovePosition(rigidbody.position + GetForwardVector() * moveSpeed * Time.deltaTime);
    }

}
