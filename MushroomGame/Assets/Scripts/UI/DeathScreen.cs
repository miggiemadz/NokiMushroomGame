using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameUI playerHealth;

    public bool isDead = false;

    public void Start()
    {
        Time.timeScale = 0f;
        isDead = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        isDead = false;
        Time.timeScale = 1.0f;
    }
}
