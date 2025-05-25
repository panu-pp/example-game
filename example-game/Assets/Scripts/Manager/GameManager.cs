using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public static string OBSTACLE_TAG_NAME = "Obstacle";
    public static string CHECKPOINT_TAG_NAME = "Checkpoint";

    [SerializeField] private float _timeSacle = 1;

    [SerializeField] private float _obstacleSpeed = 1;
    [SerializeField] private float _obstacleInterval = 5;
    public float TimeSacle { get => _timeSacle; set => _timeSacle = value; }
    public float ObstacleSpeed { get => _obstacleSpeed; }
    public float ObstacleInterval { get => _obstacleInterval; }

    private void Start()
    {
        StateManager.Instance.SwitchState(StateManager.GameState.Home);
    }
    public void SetPaused(bool value)
    {
        Debug.Log($"PAUSED: {value}");
        Time.timeScale = value ? 0 : _timeSacle;
    }
}
