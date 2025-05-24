using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGate : Obstacle
{
    [Header("OBSTACLE GATE")]
    [SerializeField] private GameObject _topObj;
    [SerializeField] private GameObject _bottomObj;

    public override void Init()
    {
        float topRandValue = Random.Range(2f, 8f);
        float bottomRandValue = Random.Range((float)(2 - (topRandValue - 1)), 8f);

        _topObj.transform.localPosition = Vector3.up * (8 + topRandValue);
        _bottomObj.transform.localPosition = Vector3.down * (8 + bottomRandValue);

        base.Init();
    }
}
