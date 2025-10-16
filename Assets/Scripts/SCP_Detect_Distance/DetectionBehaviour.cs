using System;
using UnityEngine;

public class DetectionBehaviour : MonoBehaviour
{
    #region Initialization

    public static event Action<DetectionBehaviour> OnObjectFound;
    public static event Action<DetectionBehaviour> OnObjectWaiting;
    public static event Action<DetectionBehaviour, bool> OnObjectSaveLoaded;

    [field: SerializeField] public bool IsProgramm { get; private set; }
    [field:SerializeField] public float TimeToDetect { get; private set; }
    public float StartDetectTime { get; private set; } = 0;
    public bool IsFind { get; private set; }

    [SerializeField] private float _detectionDistance;
    private float _actualDistance;
    private Vector2 _mousePos;

    void Start()
    {
        PlayerInputHandlerBehaviour.OnPlayerTouch += GetMousePosition;
        IsFind = this.GetComponent<SaveableItemBehaviour>().IsFound;
        OnObjectSaveLoaded?.Invoke(this, IsFind);
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
        if (IsFind) return;

        _actualDistance = Vector3.Distance(Camera.main.WorldToScreenPoint(transform.position), Camera.main.WorldToScreenPoint(_mousePos));

        if (_actualDistance <= _detectionDistance)
        {
            if(StartDetectTime == 0)
            {
                OnObjectWaiting?.Invoke(this);
                StartDetectTime = Time.time;
            }

            else if (Time.time - StartDetectTime >= TimeToDetect)
            {
                OnObjectFound?.Invoke(this);
                IsFind = true;
            }
        }

        else StartDetectTime = 0;
    }

    private void OnDestroy()
    {
        PlayerInputHandlerBehaviour.OnPlayerTouch -= GetMousePosition;
    }
}