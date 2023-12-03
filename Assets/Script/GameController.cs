using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject startGame;
    public GameObject endgame;
    public Button Restart;
    public Button Exit;
    // Start is called before the first frame update
    void Start()
    {
        startGame.SetActive(true);
        Time.timeScale = 0;
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        startGame.SetActive(false);
    }
    public void EndGame()
    {
        Time.timeScale = 0;
        endgame.SetActive(true);
    }
    public void RestartGame()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
        {
            Destroy(enemy);
        }
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
        Time.timeScale = 0;
    }
}
