using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private float _timeSacle = 1;
    public float TimeSacle { get => _timeSacle; set => _timeSacle = value; }

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
