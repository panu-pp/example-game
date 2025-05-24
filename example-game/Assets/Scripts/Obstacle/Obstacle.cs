using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Obstacle : MonoBehaviour
{
    protected Coroutine _movementCoroutine;

    protected void OnDestroy()
    {
        if (_movementCoroutine != null)
        {
            StopCoroutine(_movementCoroutine);
            _movementCoroutine = null;
        }
    }
    public virtual void Init()
    {
        if(_movementCoroutine != null)
        {
            StopCoroutine(_movementCoroutine);
            _movementCoroutine = null;
        }
        _movementCoroutine = StartCoroutine(ObstacleMovement());
    }
    protected virtual IEnumerator ObstacleMovement()
    {
        while (StateManager.Instance.gameState == StateManager.GameState.Play)
        {
            transform.position += Vector3.left * ObstacleManager.Instance.ObstacleSpeed * Time.deltaTime;

            if (transform.position.x <= -13)
            {
                Destroy(gameObject, 0.1f);
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
