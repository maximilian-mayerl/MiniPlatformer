using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {
    private GameController gameController;

    void Start() {
        this.gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            // When the player touches a coin, it should be collected.
            // (1) Make the coin disappear.
            this.gameObject.SetActive(false);

            // (2) Increase score.
            this.gameController.IncreaseScore();
        }
    }
}
