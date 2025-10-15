using System;
using UnityEngine;

public class DetectionBehaviour : MonoBehaviour
{
    #region Initialization

    public static event Action<DetectionBehaviour> OnObjectFound;
    public static event Action<DetectionBehaviour> OnObjectWaiting;
    public static event Action<DetectionBehaviour, bool> OnObjectSaveLoaded;

    [field: SerializeField] public bool IsProgramm { get; private set; }
    [SerializeField] private float _detectionDistance;
    [SerializeField] private float _timeToDetect;

    private float _actualDistance;
    private float _startDetectTime = 0;
    private Vector2 _mousePos;
    private bool _isFind;

    void Start()
    {
        PlayerInputHandlerBehaviour.OnPlayerTouch += GetMousePosition;
        OnObjectSaveLoaded?.Invoke(this, this.GetComponent<SaveableItemBehaviour>().IsFound);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _detectionDistance / 100f);
    }

    private void GetMousePosition(Vector2 pos)
    {
        _mousePos = pos;
    }

    #endregion

    void Update()
    {
        if (_isFind) return;

        _actualDistance = Vector3.Distance(Camera.main.WorldToScreenPoint(transform.position), Camera.main.WorldToScreenPoint(_mousePos));

        if (_actualDistance <= _detectionDistance)
        {
            if(_startDetectTime == 0)
            {
                OnObjectWaiting?.Invoke(this);
                _startDetectTime = Time.time;
            }

            else if (Time.time - _startDetectTime >= _timeToDetect)
            {
                OnObjectFound?.Invoke(this);
                _isFind = true;
            }
        }

        else _startDetectTime = 0;
    }
}