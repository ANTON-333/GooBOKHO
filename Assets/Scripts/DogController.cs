using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour

{
    
    public CharacterController ch;
    public float speed = 1.5f;
    public Camera cam;
    public float gravity = 10f;
    public float jumpSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.player == "dog")
        {
          float left = Input.GetAxis("Horizontal");
  

        if (ch.isGrounded)
        {
            jumpSpeed = 0;
            if (Input.GetAxis("Jump") > 0) jumpSpeed = 5;

        }

        jumpSpeed -= gravity * Time.deltaTime;
        if (left<0)  gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        if (left>0)  gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
}
