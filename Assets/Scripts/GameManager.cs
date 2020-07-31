using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    
    public static GameManager _instance;

    [SerializeField] float slowDownValue = 10f;

    [Header("Score")]
    [SerializeField] Text scoreText;
    [SerializeField] int scoreAmount;

    [Header("Pause")]
    [SerializeField] GameObject pauseUI;

    private int totalScore = 0;
    private bool isPaused = false;

	private void Awake()
	{
        _instance = this;
	}

	private void Update()
	{
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                Time.timeScale = 0f;
                pauseUI.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                pauseUI.SetActive(false);
            }
        }

	}

	public void EndGame()
    {
        StartCoroutine(RestartLevel());
    }

    public void AddScore()
    {
        totalScore += scoreAmount;

        scoreText.text = totalScore.ToString();
    }

    IEnumerator RestartLevel ()
    {
        Time.timeScale = 1 / slowDownValue;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowDownValue;

        yield return new WaitForSeconds(1f / slowDownValue);

        Time.timeScale = 1;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowDownValue;

        totalScore = 0;
        SceneManager.LoadScene(0);
    }

}
