using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [Header("OBSTACLE")]
    [SerializeField] private float _obstacleSpeed = 1;
    [SerializeField] private float _obstacleInterval = 1;


    public float ObstacleSpeed { get => _obstacleSpeed; set => _obstacleSpeed = value; }
    public float ObstacleInterval { get => _obstacleInterval; set => _obstacleInterval = value; }
}
