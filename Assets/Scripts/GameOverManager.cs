using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour {
    public PlayerHealth player_one;
    public PlayerHealth player_two;

    public GameObject gameOverPanel;
    public TextMeshProUGUI winText;

    [SerializeField]
    public static bool gameOver;

    private void Awake() {
        GameOverManager.gameOver = false;
        gameOverPanel.SetActive(false);
    }

    private void FixedUpdate() {
        if (player_one.IsDead) {
            winText.text = "Red won!";
        }

        if (player_two.IsDead) {
            winText.text = "Green won!";
        }

        if (player_one.IsDead && player_two.IsDead) {
            if (player_one.healthValue > player_two.healthValue) {
                winText.text = "Green Won!";
            } else if (player_two.healthValue > player_one.healthValue) {
                winText.text = "Red Won!";
            } else {
                winText.text = "Game Over";
            }

            GameOver();
        }

        if (player_one.IsDead || player_two.IsDead) {
            GameOver();
        }
    }

    private void GameOver() {
        GameOverManager.gameOver = true;
        gameOverPanel.SetActive(true);
    }

    private void Update() {
        if (GameOverManager.gameOver && Input.GetButton("Restart")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}