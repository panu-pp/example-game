using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : MonoSingleton<HomeUI>
{
    [SerializeField] private Button _startButton;

    private void Start()
    {
        _startButton.onClick.AddListener(OnStart);
    }
    private void OnDestroy()
    {
        _startButton.onClick.RemoveAllListeners();
    }

    private void OnStart()
    {
        StateManager.Instance.SwitchState(StateManager.GameState.Play);
    }

    public void ToggleHomeUI(bool isActive)
    {
        _startButton.gameObject.SetActive(isActive);
    }
}
