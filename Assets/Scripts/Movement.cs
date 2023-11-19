using UnityEngine;

[RequireComponent(
    typeof(Rigidbody2D))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;

    private const string _horizontal = "Horizontal";
    
    private Rigidbody2D _rigidbody2D;
    private float _horizontalMove;

    private void Awake() => 
        _rigidbody2D = GetComponent<Rigidbody2D>();

    private void Update()
    {
        _horizontalMove = Input.GetAxis(_horizontal) * _speed;
        _rigidbody2D.velocity = new Vector2(_horizontalMove, _rigidbody2D.velocity.y);
    }
}