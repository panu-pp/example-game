using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoSingleton<PlayerController>
{
    [SerializeField] private float _jumpVelocity = 8;
    [SerializeField] private float _torque = 50;

    [SerializeField] private float _maximumRotation = 60;
    [SerializeField] private float _minimumRotation = -70;
    [SerializeField] private float _rotationOvertime = 100;
    private Rigidbody2D _rigidbody;

    private Coroutine _rotationCoroutine;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (StateManager.Instance.gameState == StateManager.GameState.Play)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _rigidbody.velocity = new Vector2(0, _jumpVelocity);

                if (_rigidbody.rotation < _maximumRotation)
                {
                    _rigidbody.AddTorque(_torque);
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (_rigidbody.velocity.y > 0)
                {
                    _rigidbody.velocity = _rigidbody.velocity / 2;
                }

                if (_rigidbody.totalTorque > 0)
                {
                    _rigidbody.totalTorque = _rigidbody.totalTorque / 2;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StateManager.Instance.SwitchState(StateManager.GameState.Lose);
    }
    private IEnumerator RotationCoroutine()
    {
        while (StateManager.Instance.gameState == StateManager.GameState.Play)
        {
            if(_rigidbody.rotation > _minimumRotation)
            {
                _rigidbody.MoveRotation(_rigidbody.rotation - (_rotationOvertime * (1 + (_rigidbody.rotation / _maximumRotation))) * Time.deltaTime);
            }
            yield return new WaitForEndOfFrame();
        }
    }

    public void ResetPlayer()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);

        if(_rotationCoroutine != null)
        {
            StopCoroutine(_rotationCoroutine);
            _rotationCoroutine = null;
        }

        _rotationCoroutine = StartCoroutine(RotationCoroutine());
    }
}
