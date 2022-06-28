using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FowardGround : MonoBehaviour
{
    GameManagerX gameManager;
    Vector3 startPosition;
    float resetPosition = -9.27f;
    float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerX>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            transform.Translate(Vector3.forward * -speed * Time.deltaTime);
            if (transform.position.z < resetPosition)
            {
                transform.position = startPosition;
            }
        }
    }
}
