using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 5f;
    public bool travarMouse = true;
    public float sensibilidade = 2;

    private float mouseX, mouseY;
    public bool LookAtPlayer = false;
    public CharacterController CharacterController;
    Vector3 lookTarget, newPosition;
    private Quaternion playerRot;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        // float horizontal = Input.GetAxis("Horizontal")*Time.deltaTime*speed;
        // float vertical = Input.GetAxis("Vertical")*Time.deltaTime*speed;
        //
        // Vector3 mov = new Vector3(horizontal, 0, vertical);
        // CharacterController.Move(mov);

        //
        //
        // mouseX += Input.GetAxis("Mouse X")*sensibilidade;
        // mouseY -= Input.GetAxis("Mouse Y")*sensibilidade;
        //
        // transform.eulerAngles = new Vector3(mouseY, mouseX,0);
        // transform.position = new Vector3(mouseY, mouseX, 0);

        // Quaternion cam = Quaternion.AngleAxis(mouseX, Vector3.up);

    }

 

}
