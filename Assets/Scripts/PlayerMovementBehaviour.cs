using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    private PlayerInputHandlerBehaviour _input;

    private void Awake()
    {
        TryGetComponent(out _input);
        PlayerInputHandlerBehaviour.OnPlayerTouch += PlayerMovement;
    }

    private void PlayerMovement(Vector2 pos)
    {
        transform.position = pos;
    }
}
