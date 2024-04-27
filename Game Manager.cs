using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    public TextMeshProUGUI parkedText;

    public TextMeshProUGUI timerText;
    private float timer;

    public Button startGame;

    public bool alive;

    // Start is called before the first frame update
    void Start()
    {
        // Physics.gravity = new Vector3(0, -15, 0);
        alive = true;
        timer = 0;


    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    public void GameOverScreen()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void ParkedScreen()
    {
        parkedText.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        timer = 0;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    void Timer()
    {
        if (alive)
        {
            timer = Time.timeSinceLevelLoad;
            timerText.text = "" + ((int)timer);
        }

    }
}
