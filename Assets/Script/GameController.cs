using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject endgame;
    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
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
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
        Time.timeScale = 0;
    }
}
