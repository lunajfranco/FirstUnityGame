using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerX : MonoBehaviour
{
    public Text gameOver;
    public GameObject TittleGame;
    public GameObject Hearts;
    public Button restartButton;
    float spawnRate = 2.0f;
    public bool isGameActive;
    GeneratorItems generatorItems;
    // Start is called before the first frame update
    void Start()
    {
        generatorItems = GameObject.Find("GenerateItems").GetComponent<GeneratorItems>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame(float difficulty)
    {
        isGameActive = true;
        spawnRate /= difficulty;
        TittleGame.SetActive(false);
        Hearts.SetActive(true);
        StartCoroutine(RespawnEnemies());
    }
    IEnumerator RespawnEnemies()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            if (isGameActive)
            {
                generatorItems.RespawnEnemies();
            }
        }
    }
    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
