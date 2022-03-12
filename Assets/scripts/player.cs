using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player : MonoBehaviour
{

    [SerializeField] GameObject pl;
    [SerializeField] CharacterController controller;
    public Vector3 direction; 
    public int player_speed = 5;
    public float gravity = 900;

    void Start()
    {
        
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        direction = new Vector3(moveHorizontal, 0, moveVertical);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            player_speed += player_speed % 4;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            player_speed -= player_speed % 4;
        }

        direction = transform.TransformDirection(direction) * player_speed;
        direction.y -= gravity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);

    }
}
