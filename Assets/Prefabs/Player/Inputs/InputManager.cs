using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    public enum Type { KEYBOARD_MOUSE, GAMEPAD };
    [HideInInspector] public Type DeviceType = Type.KEYBOARD_MOUSE;

    public void OnControllerChange(PlayerInput playerInput)
    {
        if (playerInput.currentControlScheme.CompareTo("MouseKeyboard") == 0)
            DeviceType = Type.KEYBOARD_MOUSE;
        if (playerInput.currentControlScheme.CompareTo("Gamepad") == 0)
            DeviceType = Type.GAMEPAD;
    }
}