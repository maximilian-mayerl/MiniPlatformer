using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    [SerializeField] private Text scoreText;

    private GameObject player;
    private int currentScore = 0;

    void Start() {
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        this.CheckGameOver();
    }

    public void IncreaseScore() {
        this.currentScore++;
        this.scoreText.text = currentScore.ToString();
    }

    private void CheckGameOver() {
        // Check if the player has fallen down.
        // If so, reload the scene.
        if (this.player.transform.position.y < -7) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
