using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider2D))]
public class PlayerGun : MonoBehaviour
{
    public ParticleSystem AbsorbParticles;
    public float FireSpeed = 1f;
    public GameObject CursorObject;
    private GameObject _holdedItem = null;
    private Collider2D _gunCollider;
    private bool _usingGun = false;

    private void Awake()
    {
        AbsorbParticles.Stop();
        _gunCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (_holdedItem != null)
            WhileHolding();
    }

    private void ClearObject()
    {
        CursorObject.SetActive(false);
        _holdedItem = null;
    }

    private void WhileHolding()
    {
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition.z = 0f;
        if (cursorPosition.x < transform.parent.position.x && transform.parent.localRotation.eulerAngles.y == 0f)
            transform.parent.Rotate(new Vector3(0f, 180f, 0f));
        if (cursorPosition.x > transform.parent.position.x && transform.parent.localRotation.eulerAngles.y == 180f)
            transform.parent.Rotate(new Vector3(0f, -180f, 0f));
        CursorObject.transform.position = cursorPosition;
    }

    private void FireObject()
    {
        Vector3 newVelocity = transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        newVelocity.z = 0f;
        if (transform.parent.localRotation.eulerAngles.y == 180f)
            newVelocity.x *= -1;
        _holdedItem.transform.parent = null;
        _holdedItem.layer = 10;
        _holdedItem.tag = "GoodBullet";
        Rigidbody2D rb = _holdedItem.GetComponent<Rigidbody2D>();
        rb.velocity = newVelocity.normalized * FireSpeed;
        rb.isKinematic = false;
        ClearObject();
        Camera.main.orthographicSize = 3f;
    }

    public void CatchBullet(GameObject bulletPrefab)
    {
        _holdedItem = Instantiate(bulletPrefab, transform);
        GameManager.Instance.score += 5;
        _holdedItem.transform.localPosition = (Vector3.right * 0.2f);
        Camera.main.orthographicSize = 5f;
        CursorObject.SetActive(true);
        _gunCollider.enabled = false;
        AbsorbParticles.Stop();
    }

    public void OnUseGun(InputAction.CallbackContext context)
    {
        bool newState = context.ReadValueAsButton();

        if (newState != _usingGun) {
            _usingGun = newState;
            if (_usingGun)
                OnUsePressed();
            else
                OnUseReleased();
        }
    }

    private void OnUsePressed()
    {
        AbsorbParticles.Play();
        _gunCollider.enabled = true;
    }

    private void OnUseReleased()
    {
        if (_holdedItem != null)
            FireObject();
        AbsorbParticles.Stop();
        _gunCollider.enabled = false;

    }
}
