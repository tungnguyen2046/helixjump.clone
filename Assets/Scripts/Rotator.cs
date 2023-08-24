using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float rotateSpeed;

    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector3 rotation = Input.GetTouch(0).deltaPosition;
            transform.Rotate(0, -rotation.x * rotateSpeed * Time.deltaTime, 0);
        }
    }
}
