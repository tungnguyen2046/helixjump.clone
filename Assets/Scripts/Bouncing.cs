using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class Bouncing : MonoBehaviour
{
    [SerializeField] float bounceSpeed;
    [SerializeField] GameObject splashPrefab;
    [SerializeField] AudioSource bounce;
    [SerializeField] AudioSource die;
    [SerializeField] AudioSource land;

    Rigidbody rb;
    GameManager gameManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.GetComponent<HelixPiece>())
        {
            CreateSplash(other);
            if (other.gameObject.GetComponent<HelixPiece>().IsDead())
            {
                die.Play();
                gameManager.GameOver();
                //gameObject.SetActive(false);
                Time.timeScale = 0;
            }
            if (other.gameObject.GetComponent<HelixPiece>().IsFinish())
            {
                land.Play();
                gameManager.NextLevel();
                Time.timeScale = 0;
            }
            else
            {
                rb.velocity = new Vector3(rb.velocity.x, bounceSpeed * Time.deltaTime, rb.velocity.z);
                bounce.Play();
            }
        }
    }

    private void CreateSplash(Collision other)
    {
        var splash = Instantiate(splashPrefab, other.transform);
        splash.transform.position = new Vector3(transform.position.x, other.transform.position.y + 0.01f, transform.position.z);
        Destroy(splash, 1f);
    }
}
