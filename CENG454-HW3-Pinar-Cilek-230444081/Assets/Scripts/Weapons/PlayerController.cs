using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public Transform firePoint;
    public ObjectPool poolManager;
    private IWeapon currentWeapon;

    public float moveSpeed = 8f;
    public float mouseSensitivity = 2f;

    private float verticalRotation = 0f;
    private Camera playerCamera;

    private CharacterController characterController;
    private float velocityY = 0f;
    private float gravity = -9.81f;

    void Start()
    {
        currentWeapon = new BaseWeapon();
        playerCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        LookAround();
        Move();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            currentWeapon = new DamageUpgradeDecorator(currentWeapon);
            Debug.Log("<color=green>WEAPON UPGRADED (Decorator Used!)</color>");
        }
    }

    void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        if (characterController.isGrounded)
        {
            velocityY = 0f;
        }
        else
        {
            velocityY += gravity * Time.deltaTime;
        }

        move.y = velocityY;
        characterController.Move(move * moveSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        if (currentWeapon != null && poolManager != null && firePoint != null)
        {
            currentWeapon.Fire(firePoint, playerCamera.transform, poolManager);
        }
    }
}