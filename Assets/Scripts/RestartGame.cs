using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    bool hasGameEnded = false;
    public float restartDelay = 1f;

    public void EndGame() {
        if(hasGameEnded == false) {
            hasGameEnded = true;
            Invoke("Restart", restartDelay);
        }
    }
    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
