using UnityEngine;

public class CometController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 2f;
    [SerializeField] private float _gravityScale = 1f;
    [SerializeField] private Rigidbody2D _rb;

    public void GravityOn()
    {
        _rb.gravityScale = _gravityScale;
    }

    public void Jumping()
    {
        _rb.velocity = Vector2.up * _jumpForce;
    }
}
