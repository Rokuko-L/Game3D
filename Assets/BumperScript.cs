using UnityEngine;

public class BumperScript : MonoBehaviour
{
    [Header("Settings")]
    public float multiplier = 1.5f;
    public float maxSpeed = 50f;
    public Color hitColor = Color.red; 

    private Renderer _renderer;
    private Animator _animator;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _renderer.material.color = hitColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball")) 
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                ballRb.linearVelocity *= multiplier;
                if (ballRb.linearVelocity.magnitude > maxSpeed)
                {
                    ballRb.linearVelocity = ballRb.linearVelocity.normalized * maxSpeed;
                }
            }

            if (_animator != null)
            {
                _animator.SetTrigger("Hit");
            }
        }
    }
}
