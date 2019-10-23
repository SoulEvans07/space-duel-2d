using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {
    public PlayerHealth player_one;
    public PlayerHealth player_two;

    public GameObject gameOverPanel;
    public TextMeshProUGUI winText;

    public GameObject continueButton;
    private Navigation none;

    [SerializeField]
    public static bool gameOver;
    [SerializeField]
    public static bool paused;

    private void Awake() {
        GameManager.gameOver = false;
        gameOverPanel.SetActive(false);

        none = new Navigation();
        none.mode = Navigation.Mode.None;
    }

    private void FixedUpdate() {
        if (!GameManager.gameOver) {
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
    }

    private void Update() {
        if (!gameOver && !paused && Input.GetButton("Pause")) {
            PauseGame();
        } else if (!gameOver && paused && Input.GetButton("Pause")) {
            Continue();
        }
    }

    private void PauseGame() {
        if (gameOver) {
            continueButton.SetActive(false);
        }
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue() {
        if (!gameOver) {
            Time.timeScale = 1f;
            gameOverPanel.SetActive(false);
        }
    }

    private void GameOver() {
        GameManager.gameOver = true;
        PauseGame();
    }

    public void Restart() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit() {
        SceneManager.LoadScene(0);
    }
}