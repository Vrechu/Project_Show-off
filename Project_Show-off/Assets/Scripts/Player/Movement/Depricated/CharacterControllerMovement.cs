using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1;

    private CharacterController characterController;
    private enum PlayerNumber
    {
        Player1, Player2
    }

    [SerializeField] private PlayerNumber playerNumber = PlayerNumber.Player1;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        characterController.Move(new Vector3(direction().x, 0, direction().y) * moveSpeed * Time.deltaTime);
    }

    Vector2 direction()
    {
        float up = 0;
        float down = 0;
        float left = 0;
        float right = 0;

        switch (playerNumber)
        {
            case PlayerNumber.Player1:
                if (Input.GetKey(KeyCode.W))
                {
                    up = 1;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    down = -1;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    left = -1;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    right = 1;
                }
                break;

            case PlayerNumber.Player2:
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    up = 1;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    down = -1;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    left = -1;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    right = 1;
                }
                break;
        }
        return new Vector2(left + right, up + down).normalized;
    }
}
