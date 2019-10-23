using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public string gameScene = "GameScene";
    
    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void Quit() {
        Application.Quit();
    }
}