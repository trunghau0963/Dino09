using System;
using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private float gameSpeed = 5f;
    [SerializeField]
    private float speedIncreaseInterval = 0.15f;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    private float score = 0;
    [SerializeField] private GameObject scoreTextObj;
    [SerializeField] private GameObject gameOverTextObj;
    [SerializeField] private GameObject gameStartTextObj;
    [SerializeField] private GameObject buttonQuit;
    private bool isGameOver = false;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public float GetGameSpeed()
    {
        return gameSpeed;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonQuit.GetComponent<Button>().onClick.AddListener(QuitGame);
        StartGame();
    }
    // Update is called once per frame
    void Update()
    {
        PlayGame();
        if (!isGameOver)
        {
            UpdateGameSpeed();
            IncreaseScore();
        }
    }

    private void UpdateGameSpeed()
    {
        gameSpeed += Time.deltaTime * speedIncreaseInterval;
    }
    
    public void IncreaseScore()
    {
        score += Time.deltaTime * 5;
        scoreText.text = "Score: " + Mathf.FloorToInt(score);
    }
    
    public void StartGame()
    {
        Time.timeScale = 0;
        gameStartTextObj.SetActive(true);
        gameOverTextObj.SetActive(false);
        scoreTextObj.SetActive(false);
    }
    
    public void PlayGame()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !isGameOver)
        {
            Time.timeScale = 1;
            scoreTextObj.SetActive(true);
            gameStartTextObj.SetActive(false);
        }
    }
    
    public void GameOver()
    {
        isGameOver = true;
        gameOverTextObj.SetActive(true);
        Time.timeScale = 0;
        StartCoroutine(ReloadScene());
    }
    
    private static IEnumerator ReloadScene()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
