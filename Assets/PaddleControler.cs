using UnityEngine;
using UnityEngine.InputSystem; 

[RequireComponent(typeof(HingeJoint))]
public class PaddleController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private InputActionProperty paddleAction;
    [SerializeField] private float springPower = 10000f;

    private HingeJoint _hinge;

    private void Awake()
    {
        _hinge = GetComponent<HingeJoint>();
    }

    private void OnEnable() => paddleAction.action.Enable();
    private void OnDisable() => paddleAction.action.Disable();

    private void FixedUpdate()
    {
        ApplySpringForce(paddleAction.action.IsPressed());
    }

    private void ApplySpringForce(bool isPressed)
    {
        JointSpring jointSpring = _hinge.spring;
        jointSpring.spring = isPressed ? springPower : 0f;
        _hinge.spring = jointSpring;
        _hinge.useSpring = true;
    }
}