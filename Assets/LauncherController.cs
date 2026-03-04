using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public Rigidbody ballRb;
    public KeyCode input;
    public float maxForce = 100f;
    
    private float _currentForce;
    private bool _isHolding;

    void Update()
    {
        if (Input.GetKeyDown(input)) _isHolding = true;

        if (_isHolding)
        {
            _currentForce = Mathf.MoveTowards(_currentForce, maxForce, Time.deltaTime * 50f);
        }

        if (Input.GetKeyUp(input))
        {
            ballRb.AddForce(Vector3.forward * _currentForce, ForceMode.Impulse);
            _currentForce = 0;
            _isHolding = false;
        }
    }
}