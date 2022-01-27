using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEngine : MonoBehaviour
{
    [Header("Movment & Look Around & Gravity")]
    // left and right
    float mouseX;
    float speed;
    //up and down 
    public Transform cameraTrm;
    float mouseY;
    float cameraX;
    //movement
    float movementSpeed;
    float horizontal;
    float vertical;
    Vector3 V;
    public CharacterController controller;
    //gravity
    public bool isGround;
    public Transform checkground;
    float radius;
    public LayerMask Ground;
    float gravity;
    Vector3 velocity;

    [Header("Health")]
    //health
    public int life = 5;

    // Start is called before the first frame update
    void Start()
    {
        speed = 100;
        cameraX = 0;
        movementSpeed = 8;
        controller = GetComponent<CharacterController>();
        radius = 1;
        gravity = -9.81f;
        
    }

    // Update is called once per frame
    void Update()
    {
        //left and right
        mouseX = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        transform.Rotate(new Vector3(0, mouseX, 0));

        //up and right
        mouseY = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
        cameraX -= mouseY;
        cameraX = Mathf.Clamp(cameraX, -90, 90);
        cameraTrm.localRotation = Quaternion.Euler(cameraX, 0, 0);
        //movement
        horizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        V = transform.forward * vertical + transform.right * horizontal;

        //Sprint
        if (Input.GetKey(KeyCode.Q))
        {
            movementSpeed = 16;
        }
        else
        {
            movementSpeed = 8;
        }
        controller.Move(V);

        //gravity
        if (Physics.CheckSphere(checkground.position, radius, Ground) == true)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }

        if (isGround == false)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else velocity.y = 0;
        //jump
        if (isGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y += 10;
        }
        controller.Move(velocity * Time.deltaTime);

        //Health
        if(life == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
