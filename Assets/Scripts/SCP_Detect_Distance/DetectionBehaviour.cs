using System;
using UnityEngine;

public class DetectionBehaviour : MonoBehaviour
{
    [SerializeField] float _detectionDistance;
    [SerializeField] float _actualDistance;

    [SerializeField] float _startDetectTime = 0;
    [SerializeField] float _timeToDetect;

    private bool _isFind;

    [SerializeField] private float _time;

    [SerializeField] private Vector2 _mousePos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerInputHandlerBehaviour.OnPlayerTouch += GetMousePosition;
    }

    private void GetMousePosition(Vector2 vector)
    {
        _mousePos = vector;
    }

    // Update is called once per frame
    void Update()
    {
        _time = Time.time;

        if (_isFind) return;

        _actualDistance = Vector3.Distance(Camera.main.WorldToScreenPoint(transform.position), Camera.main.WorldToScreenPoint(_mousePos));

        if (_actualDistance <= _detectionDistance)
        {
            if(_startDetectTime == 0)
            {
                Debug.Log("Hey, Start listen ! (mais sur jsp quel plateforme)");
                _startDetectTime = Time.time;
            }
            else if (Time.time - _startDetectTime >= _timeToDetect)
            {
                Debug.Log("I'm find !:D");
                _isFind = true;
            }
        }
        else
        {
            _startDetectTime = 0;
        }
    }
}