using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField]
    float speed = 12f;
    float gravity = -9.81f;

    public Transform groundCheck;
    public LayerMask groundMask;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MovePlayer();
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        characterController.Move(Vector3.up * gravity * Time.deltaTime);
    }

    private void MovePlayer()
    {
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * x+ transform.forward * z;
        CheckTerrain();
        characterController.Move(move * speed * Time.deltaTime);
    }

    private void CheckTerrain()
    {
        RaycastHit hitResult;
        bool isHit = Physics.Raycast(
            groundCheck.position,
            transform.TransformDirection(Vector3.down),
            out hitResult,
            0.4f,
            groundMask);
        if (isHit)
        {
            string terrainType = hitResult.collider.gameObject.tag;
            switch(terrainType)
            {
                case "Slow":
                    speed = 3f;
                        break;

                    case "Fast":
                    speed = 20f;
                        break;
                default:
                    speed = 12f;
                    break;
            }
        }
    }

}
