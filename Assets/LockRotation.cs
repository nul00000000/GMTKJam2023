using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour {

    public Transform follow;

    void Start() {
        
    }

    void Update() {
        transform.position = new Vector3(0, follow.position.y, -7.0f);
    }

}
