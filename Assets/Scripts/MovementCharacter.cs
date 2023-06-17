using UnityEngine;

public class MovementCharacter : MonoBehaviour
{
    [SerializeField] private CharacterController characterPlayer;
    [SerializeField] private Animator animationPlayer;
    [SerializeField] private float speedPlayer;
    private Vector3 _movementPlayer; 

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _movementPlayer = (transform.right * horizontal) + (transform.forward * vertical);
        characterPlayer.Move(_movementPlayer.normalized * speedPlayer * Time.deltaTime);

        PlayerAnimations(horizontal, vertical);
    }

    private void PlayerAnimations(float x, float z)
    {
        animationPlayer.SetFloat("inputX", x);
        animationPlayer.SetFloat("inputZ", z);
    }
}
