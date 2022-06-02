using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private PlayerProfile playerProfile;

    [SerializeField] private float topSpeed = 5;
    [SerializeField] private float groundedAcceleration = 2000;
    [SerializeField] private float inAirAcceleration = 1000;
    [SerializeField] private float currentSpeed = 0;
    [SerializeField] private float groundedDrag = 0.02f;
    [SerializeField] private float inAirDrag = 0.05f;
    public Transform cameraTransform;

    private void Awake()
    {
        LevelSettings.OnSettingsReady += SetCamera;
    }

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerProfile = GetComponent<PlayerProfileAccess>().PlayerProfile;
        cameraTransform = LevelSettings.Instance.CameraManager.MyCamera(playerProfile.PlayerNumber).transform;
    }

    private void OnDestroy()
    {
        LevelSettings.OnSettingsReady -= SetCamera;       
    }

    private void SetCamera()
    {
        cameraTransform = LevelSettings.Instance.CameraManager.MyCamera(playerProfile.ControllerNumber).transform;
    }

    void Update()
    {
        Accelerate();
    }

    private void Accelerate()
    {
        if (!OverTopSpeed())
        {
            playerRigidbody.AddForce(new Vector3(Direction().x, 0, Direction().y) * Acceleration(), ForceMode.Acceleration);
        }
        playerRigidbody.AddForce(Drag(), ForceMode.Acceleration);
    }

    private bool OverTopSpeed()
    {
        currentSpeed = new Vector2(playerRigidbody.velocity.x, playerRigidbody.velocity.z).magnitude;
        if (currentSpeed <= topSpeed) return false;
        else return true;
    }

    private float Acceleration()
    {
        if (GetComponent<CheckIfGrounded>().IsGrounded())
        {
            return groundedAcceleration * Time.deltaTime;
        }
        else return inAirAcceleration * Time.deltaTime;
    }

    private Vector3 Drag()
    {
        if (GetComponent<CheckIfGrounded>().IsGrounded())
        {
            return playerRigidbody.velocity * groundedDrag * -1 * Time.deltaTime;
        }
        else return playerRigidbody.velocity * inAirDrag * -1 * Time.deltaTime;
    }

    public Vector2 Direction()
    {
        if (cameraTransform != null)
        {
            Vector3 cameraVector = (cameraTransform.right * playerProfile.PlayerInputs.Direction().x)
            + (cameraTransform.forward * playerProfile.PlayerInputs.Direction().y).normalized;
            return new Vector2(cameraVector.x, cameraVector.z);
        }
        else
        {
            return playerProfile.PlayerInputs.Direction().normalized;
        }
    }
}
