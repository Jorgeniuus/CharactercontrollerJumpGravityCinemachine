using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlayer : MonoBehaviour
{
    [SerializeField] private CharacterController characterPlayer;
    [SerializeField] private Animator jumpAnimation;

    [SerializeField] private LayerMask layerGround;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private float radiusChecker;
    [SerializeField] private float maxHeight;
    [SerializeField] private float timeToMaxHeight;

    private Vector3 _yJumpForce;

    private float jumpSpeed;
    private float _gravity;

    private void Start()
    {
        SetGravity();
    }

    private void Update()
    {
        JumpForce();
        GravityForce();
    }

    private void JumpForce()
    {
        if (IsGrounded() == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yJumpForce = jumpSpeed * Vector3.up;
                characterPlayer.Move(_yJumpForce);

                jumpAnimation.SetBool("jump", true);
            }
        }
        else jumpAnimation.SetBool("jump", false);
    }

    private void SetGravity()
    {
        _gravity = (2 * maxHeight) / Mathf.Pow(timeToMaxHeight, 2);
        jumpSpeed = _gravity * timeToMaxHeight;
    }

    private void GravityForce()
    {
        _yJumpForce += _gravity * Time.deltaTime * Vector3.down;
        characterPlayer.Move(_yJumpForce);

        if (IsGrounded() == true) //zera gravidade
        {
            _yJumpForce = Vector3.zero;
        }
    }

    private bool IsGrounded()
    {
        bool isGrounded = Physics.CheckSphere(groundChecker.position, radiusChecker, layerGround);
        return isGrounded;
    }

    private void OnDrawGizmos() => Gizmos.DrawWireSphere(groundChecker.position, radiusChecker);
}
