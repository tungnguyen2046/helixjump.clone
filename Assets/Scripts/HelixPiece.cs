using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixPiece : MonoBehaviour
{
    Bouncing ball;
    [SerializeField] bool isDead = false; public bool IsDead() { return isDead; }
    [SerializeField] bool isFinish = false; public bool IsFinish() { return isFinish;  }

    void Awake()
    {
        ball = FindObjectOfType<Bouncing>();
    }
    private void Update()
    {
        if(ball != null)
        {
            if (transform.position.y > ball.transform.position.y)
            {
                Destroy(gameObject);
            }
        }   
    }
}
