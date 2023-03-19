
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
    public TMP_Text scoreText;
    public TMP_Text prefabCountText;

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject player;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreText();
    }
    private void Update()
    {
        UpdatePrefabCountText();
    }
    public void CheckGameEnd()
    {
        int prefabCount = GameObject.FindGameObjectsWithTag("Collectible").Length;

        if (prefabCount == 10)
        {
            player.SetActive(false);
            gameOverScreen.SetActive(true);  
        }
    }
    private void UpdatePrefabCountText()
    {
        
        int prefabCount = GameObject.FindGameObjectsWithTag("Collectible").Length;
        prefabCountText.text = "Count: " + prefabCount + "/10";

        if (prefabCount == 10)
        {
            CheckGameEnd();
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
    public void StartNew()
    {    
       
        SceneManager.LoadScene(1);
    }
   
    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
