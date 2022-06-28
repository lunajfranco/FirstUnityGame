using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    GameManagerX gameManager;
    float horizontal;
    float vertical;
    Rigidbody rgPlayer;
    float Zlimit = 7.5f;
    int maxHp = 3;
    public ParticleSystem[] particlesEnemies;
    public GameObject[] hearts;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        StopParticles();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerX>();
        rgPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        LimitPlayerPosition();
        MovementPlayer();
    }

    void MovementPlayer()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        rgPlayer.AddForce(Vector3.forward * speed * vertical);
        rgPlayer.AddForce(Vector3.right * speed * horizontal);
    }

    void LimitPlayerPosition()
    {
        if (transform.position.z < -Zlimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -Zlimit);
        }
        if (transform.position.z > Zlimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Zlimit);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ReduceHp();
            particlesEnemies[maxHp].Play();
            hearts[maxHp].SetActive(false);
            if (maxHp == 0)
            {
                gameManager.GameOver();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            particlesEnemies[maxHp].Stop();
            hearts[maxHp].SetActive(true);
            IncreaseHp();
        }
    }
    void ReduceHp()
    {
        maxHp--;
    }

    void IncreaseHp()
    {
        maxHp++;
        if (maxHp > 3)
        {
            maxHp = 3;
        }
    }

    void StopParticles()
    {
        foreach (var item in particlesEnemies)
        {
            item.Stop();
        }
    }
}
