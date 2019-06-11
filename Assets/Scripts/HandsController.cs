using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsController : MonoBehaviour
{
       public GameObject Item;
    public CharacterController ch;
    public float speed = 1.5f;
    public Camera cam;
    public float gravity = 10f;
    public float jumpSpeed;
    public GameObject pickableObject;

    public GameObject myItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          if (myItem && Input.GetKeyDown(KeyCode.E)) {
            
            myItem.transform.SetParent(null);
            myItem.GetComponent<Rigidbody>().isKinematic = false;
            myItem = null;
              
            
             } 
             else if (pickableObject && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(pickableObject);
            myItem = Instantiate(Item, transform.position, transform.rotation);
            myItem.transform.SetParent(gameObject.transform);
            myItem.GetComponent<Rigidbody>().isKinematic = true;
        }
    }


       void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickable"))
        {
            pickableObject = other.gameObject;
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        pickableObject = null;
    }
}
