using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float MoveSpeed = 8f;
    public Transform PlayerSpritesTransform;
    private Animator _animator;
	private Rigidbody2D _rigidBody2D;
	private Vector2 _movementsVector;
	
	private void Awake()
	{
		_rigidBody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
	}
	
	private void FixedUpdate()
	{
		Vector2 newVelocity = _movementsVector * MoveSpeed;
		FlipSprites(_movementsVector.x);
        _animator.SetBool("Walking", _movementsVector != Vector2.zero);
		_rigidBody2D.velocity = newVelocity;
	}

	private void FlipSprites(float newVelocityX)
	{
        if (newVelocityX < 0f && PlayerSpritesTransform.localRotation.eulerAngles.y == 0f)
            PlayerSpritesTransform.Rotate(new Vector3(0f, 180f, 0f));
        if (newVelocityX > 0f && PlayerSpritesTransform.localRotation.eulerAngles.y == 180f)
            PlayerSpritesTransform.Rotate(new Vector3(0f, -180f, 0f));
	}
	
	public void OnMovements(InputAction.CallbackContext context)
	{
		_movementsVector = context.ReadValue<Vector2>();
	}
}