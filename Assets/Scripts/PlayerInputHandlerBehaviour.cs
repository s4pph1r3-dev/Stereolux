using System;
using UnityEngine;

public class PlayerInputHandlerBehaviour : MonoBehaviour
{
    static public event Action<Vector2> OnPlayerTouch;
    private bool _isMobile;

    private void Start()
    {
        _isMobile = Application.platform == RuntimePlatform.WebGLPlayer && Application.isMobilePlatform; // Stores the player's used platform (either mobile or PC).
    }

    private void Update()
    {
        // Mobile controls.
        if (_isMobile)
        {
            Touch touch = Input.GetTouch(0);
            OnPlayerTouch?.Invoke(Camera.main.ScreenToWorldPoint(touch.position));
        }

        // PC controls.
        else OnPlayerTouch?.Invoke(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}
