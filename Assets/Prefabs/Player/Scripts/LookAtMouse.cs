using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookAtMouse: MonoBehaviour {
    public InputManager InputManager;
    public float MaxEyesDistance = 0.015f;
    [HideInInspector] public Vector2 LookPosition;

    void FixedUpdate() {
        Vector2 relativeMousePos = transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(LookPosition));
        Vector3 newPosition = Vector3.zero;

        newPosition.x = Mathf.Clamp(relativeMousePos.x * MaxEyesDistance, -MaxEyesDistance,  MaxEyesDistance);
        newPosition.y = Mathf.Clamp(relativeMousePos.y * MaxEyesDistance, -MaxEyesDistance,  MaxEyesDistance);
        transform.localPosition = newPosition;
    }

	public void OnAim(InputAction.CallbackContext context)
	{
        Vector2 aimVector = context.ReadValue<Vector2>();

        switch (InputManager.DeviceType) {
            case InputManager.Type.KEYBOARD_MOUSE:
                LookPosition = aimVector;
                break;
            case InputManager.Type.GAMEPAD:
                LookPosition = Camera.main.WorldToScreenPoint(transform.position + (new Vector3(aimVector.x, aimVector.y, 0f) * 3f));
                break;
        }
	}
}
