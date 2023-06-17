using UnityEngine;
using Cinemachine;
public class RotationPlayer : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook cinemachineCamera;
    private float _rotationX;
    private float _sensitivity = 150f;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        PlayerRotation();
    }

    private void PlayerRotation()
    {
        if (Input.GetMouseButton(1)) cinemachineCamera.m_XAxis.m_InputAxisName = "Mouse X";
        if (Input.GetMouseButtonUp(1)) cinemachineCamera.m_XAxis.m_InputAxisName = "";

        float mouseX = Input.GetAxis("Mouse X");
        _rotationX += mouseX * _sensitivity * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, _rotationX, 0);
    }
}
