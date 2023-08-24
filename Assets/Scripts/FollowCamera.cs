using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject ball;
    float offset;

    void Awake()
    {
        transform.position = ball.transform.position;
    }

    void Update()
    {
        if(ball != null)
        {
            offset = transform.position.y - ball.transform.position.y;
        } 
        if(offset > 0)
        {
            transform.position = ball.transform.position;
        }
    }
}
