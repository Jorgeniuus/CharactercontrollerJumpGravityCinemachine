using UnityEngine;
using Cinemachine;
using System.Collections;

public class MovementCharacter : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook cinemmachineCamera;

    [SerializeField] private CharacterController characterPlayer;
    [SerializeField] private Animator animationPlayer;
    [SerializeField] private float speedPlayer;

    private Vector3 _movementPlayer;

    private float _rotationX;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        PlayerMovement();
        PlayerRotation();
    }

    private void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _movementPlayer = (transform.right * horizontal) + (transform.forward * vertical);
        characterPlayer.Move(_movementPlayer.normalized * speedPlayer * Time.deltaTime);

        PlayerAnimation(horizontal, vertical);
    }

    private void PlayerAnimation(float x, float y)
    {
        animationPlayer.SetFloat("inputX", x);
        animationPlayer.SetFloat("inputY", y);
    }

    public void PlayerRotation()
    {
        if (Input.GetMouseButton(1)) cinemmachineCamera.m_XAxis.m_InputAxisName = "Mouse X";
        if (Input.GetMouseButtonUp(1)) cinemmachineCamera.m_XAxis.m_InputAxisName = "";

        float mouseX = Input.GetAxis("Mouse X");
        _rotationX += mouseX * 150f * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, _rotationX, 0f);
    }
}    