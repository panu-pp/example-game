using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Obstacle : MonoBehaviour
{
    private void Update()
    {
        transform.position += Vector3.left * GameManager.Instance.ObstacleSpeed * Time.deltaTime;

        if(transform.position.x <= -13)
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
