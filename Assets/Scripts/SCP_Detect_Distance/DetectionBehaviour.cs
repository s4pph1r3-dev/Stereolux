using System;
using UnityEngine;

public class DetectionBehaviour : MonoBehaviour
{
    public float DetectionDistance;

    public float actualDistance;

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
        actualDistance = Vector3.Distance(Camera.main.WorldToScreenPoint(transform.position), Camera.main.WorldToScreenPoint(_mousePos));
        if (Vector3.Distance(Camera.main.WorldToScreenPoint(transform.position), Camera.main.WorldToScreenPoint(_mousePos)) <= DetectionDistance)
        {
            Debug.Log("Hey, listen ! (mais sur jsp quel plateforme)");
        }
    }
}
