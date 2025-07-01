using System;
using TMPro;
using UnityEngine;

public class DistanceConrtoller : MonoBehaviour
{
    [SerializeField] private int _start;
    [SerializeField] private int _end;
    [SerializeField] private float _speed;

    [SerializeField] private int _distance;
    [SerializeField] private TextMeshProUGUI _distanceText;
 
    private float _time = 0;

    public int Distance
    {
        get => _distance;
        set => _distance = value;
    }

    public int End
    {
        set => _end = value;
    }

    public event Action winEvent;


    private void Start()
    {
        winEvent += () => { Destroy(this); };
    }

    private void Update()
    {
        _time += Time.deltaTime;
        _distance = (int)(_time * _speed);
        _distanceText.text = _distance.ToString() + "M";

        if (_distance >= _end)
        {
            _distance = _end;
            winEvent?.Invoke();
        }
    }

}
