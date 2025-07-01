using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ObstraclesLinesService : MonoBehaviour
{
    [SerializeField] private List<ObstraclesLine> _obstaclesLines;

    [Range(0,10)]
    [SerializeField] private int _chance;

    [SerializeField] private float _timeSpawn;
    private float _timeCooldown;


    private void Update()
    {
        _timeCooldown += Time.deltaTime;
        if (_timeCooldown >= _timeSpawn)
        {
            _timeCooldown = 0;
            int _randomChance = UnityEngine.Random.Range(0, 10);
            if (_randomChance <= _chance)
                SpawnObstaclesAtRandomLine();
        }
    }

    private void SpawnObstaclesAtRandomLine()
    {
        int lineNumber = UnityEngine.Random.Range(0, _obstaclesLines.Count);
        if (!_obstaclesLines[lineNumber].IsUsed)
        {
            _obstaclesLines[lineNumber].SetObject();
        }
    }
}
