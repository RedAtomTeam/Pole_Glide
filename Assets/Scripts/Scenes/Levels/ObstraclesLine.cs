using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ObstraclesLine : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _endPosition;
    [SerializeField] private GameObject _obj;

    [SerializeField] private List<GameObject> _obstacles;

    public Vector3 ObstaclePosition {
        get => _obj.transform.position;
    }

    public bool IsUsed
    {
        get
        {
            foreach (var obstacle in _obstacles)
                if (obstacle.activeSelf)
                    return true;
            return false;
        }
    }


    private void Start()
    {
        _obj.transform.position = _startPosition.position;
        foreach (var obstacle in _obstacles) 
            obstacle.SetActive(false);
    }

    private void Update()
    {
        var step = _speed * Time.deltaTime;
        _obj.transform.position = Vector3.MoveTowards(_obj.transform.position, _endPosition.position, step);

        if (Vector3.Distance(_obj.transform.position, _endPosition.position) < 0.001f)
        {
            _obj.transform.position = _startPosition.position;
            foreach (var obstacle in _obstacles)
                obstacle.SetActive(false);
        }
    }

    public void Move()
    {
        
    }

    public void SetObject()
    {
        _obj.transform.position = _startPosition.position;
        _obstacles[Random.Range(0, _obstacles.Count)].SetActive(true);
    }
}
