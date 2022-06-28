using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorItems : MonoBehaviour
{
    GameManagerX gameManager;
    public GameObject[] enemies;
    public GameObject powerUp;
    private float respawnEnemiesZ = 14.0f;
    private float respawnX;
    private float respawnPowerUpZ = 7.0f;
    float timeRespawnPowerUp = 8.0f;
    private int index;
    bool isGameActive;
    float lastSpawnedTime;
    // Update is called once per frame
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerX>();
    }

    void Update()
    {
        index = Random.Range(0, enemies.Length);
        respawnX = Random.Range(-respawnEnemiesZ, respawnEnemiesZ);
        if (Time.time > lastSpawnedTime + timeRespawnPowerUp && gameManager.isGameActive)
        {
            RespawnPowerUp();
            lastSpawnedTime = Time.time;
        }
    }

    public void RespawnEnemies()
    {
        Instantiate(enemies[index], new Vector3(respawnX, 0.6f, respawnEnemiesZ), enemies[index].transform.rotation);
    }

    void RespawnPowerUp()
    {
        GameObject destroy = Instantiate(powerUp, new Vector3(respawnX, 1.0f, Random.Range(-respawnPowerUpZ, respawnPowerUpZ)), enemies[index].transform.rotation);
        Destroy(destroy, 3);
    }
}
