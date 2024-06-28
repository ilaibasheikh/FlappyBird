using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public AudioSource point;
    

    void Start()
    {
        if (point == null)
        {
            point = GetComponent<AudioSource>();
        }
        
    }
    

[ContextMenu("Increasing Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore+= scoreToAdd;
        scoreText.text = playerScore.ToString();
        point.Play();
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        
    }
}
