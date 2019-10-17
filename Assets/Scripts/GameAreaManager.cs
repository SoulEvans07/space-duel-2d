using UnityEngine;

public class GameAreaManager : MonoBehaviour {
    public static float MIN_WIDTH;
    public static float MIN_HEIGHT;
    public static float MAX_WIDTH;
    public static float MAX_HEIGHT;
    public static float BOTTOM;
    public static float TOP;

    public Transform player_one;
    public Transform player_two;
    public Transform barrier_top;
    public Transform barrier_bottom;

    public Rect gameArea;
    
    public float timer = 0f;
    public float startDelay = 20f;
    public float barrierSpeed = 0f;

    private void UpdateArea() {
        MIN_WIDTH = gameArea.x;
        MIN_HEIGHT = gameArea.y;
        MAX_WIDTH = gameArea.width;
        MAX_HEIGHT = gameArea.height;

        barrier_top.position = new Vector3(
            barrier_top.position.x, 
            gameArea.height
        );

        barrier_bottom.position = new Vector3(
            barrier_top.position.x, 
            gameArea.y
        );
    }

    private void Awake() {
        MIN_WIDTH = gameArea.x;
        MIN_HEIGHT = gameArea.y;
        MAX_WIDTH = gameArea.width;
        MAX_HEIGHT = gameArea.height;
        BOTTOM = gameArea.y + 1f;
        TOP = gameArea.height - 1f;
    }

    private void Update() {
        timer += Time.unscaledDeltaTime;

        if (timer > startDelay) {
            Shrink(Time.unscaledDeltaTime);
        }
    }

    private void Shrink(float deltaTime) {
        if (gameArea.height > 0) {
            gameArea.y += barrierSpeed * Time.deltaTime / 2;
            gameArea.height -= barrierSpeed * Time.deltaTime / 2;

            UpdateArea();
        }
    }

    private static void Nudge(Transform player) {

    }
}