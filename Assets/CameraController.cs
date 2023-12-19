using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private GameObject player;

    void Start() {
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        this.transform.position = new Vector3(this.player.transform.position.x, this.transform.position.y, this.transform.position.z);
    }
}
