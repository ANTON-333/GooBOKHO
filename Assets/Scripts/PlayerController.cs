using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Item;


    public CharacterController ch;
    public float speed = 1.5f;

    public Camera cam;
    public float gravity = 10f;
    public float jumpSpeed;
    public GameObject pickableObject;
    public string player;
    static GameController instance;
    public int c;
    public bool b;
    public bool d;
    public int a;

    void Start()
    {
        ch = GetComponent<CharacterController>();

    }


    // Update is called once per framevoid Update()
    void Update()
    {

        if (GameController.instance.player == "player" && (c == 0))
        {
            gameObject.transform.position = (new Vector3(transform.position.x, transform.position.y, 0));
            c = 1;
        }
        else if (GameController.instance.player == "player" && (c == 1))
        {
            c = 0;
            float left = Input.GetAxis("Horizontal");


            if (ch.isGrounded)
            {
                jumpSpeed = 0;
                if (Input.GetAxis("Jump") > 0) jumpSpeed = 5;

            }

            jumpSpeed -= gravity * Time.deltaTime;
            if (left < 0) gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            if (left > 0) gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            ch.Move(new Vector3(left * speed * Time.deltaTime, jumpSpeed * Time.deltaTime, 0));

        }
        else if (GameController.instance.player == "dog")
            gameObject.transform.position = (new Vector3(transform.position.x, transform.position.y, 2));
  if (Input.GetKeyDown(KeyCode.D) && (d))
        {
            c = 0;


            jumpSpeed = 11;
            ch.Move(new Vector3(0, -jumpSpeed * Time.deltaTime, 0));
        }

       if (Input.GetKeyDown(KeyCode.D) && (b))
        {
            c = 0;
            Vector3 camPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            cam.transform.position = camPos;

            jumpSpeed = 11;
            ch.Move(new Vector3(0, jumpSpeed * Time.deltaTime, 0));
        }
      
        else if (gameObject.transform.position.y > 5)
        {
            Vector3 camPos = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
            cam.transform.position = camPos;
        }
        else if (gameObject.transform.position.y < 5)
        {

            Vector3 camPos = (new Vector3(-6, 4, -8));
            cam.transform.position = camPos;
        }
 


    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("LadderBot"))
            b = true;
        if (other.gameObject.CompareTag("LadderTop"))
            d = true;
    }
    void OnTriggerExit(Collider other)
    {
        b = false;
        d = false;
    }
}
