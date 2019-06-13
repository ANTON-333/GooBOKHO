using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouthController : MonoBehaviour
{
       public GameObject Item;
       public Text texthelp;
       public Text texthelp1;
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
    {  if (GameController.instance.player == "dog")
    {
          if (myItem && Input.GetKeyDown(KeyCode.E)) {
            
            myItem.transform.SetParent(null);
            myItem.GetComponent<Rigidbody>().isKinematic = false;
            myItem = null;
            texthelp1.enabled = false; 
            
             } 
             else if (pickableObject && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(pickableObject);
            myItem = Instantiate(Item, transform.position, transform.rotation);
            myItem.transform.SetParent(gameObject.transform);
            myItem.GetComponent<Rigidbody>().isKinematic = true;
            texthelp.enabled = false;
            texthelp1.enabled = true;
        }
    }

    }
       void OnTriggerEnter(Collider other)
    {
         if (GameController.instance.player == "dog")
         {
        if (other.gameObject.CompareTag("Pickable") && myItem)
        {
            pickableObject = other.gameObject;
           texthelp.enabled = false;
           texthelp1.enabled = true;
        }
        else if (other.gameObject.CompareTag("Pickable"))
        {
            pickableObject = other.gameObject;
           texthelp.enabled = true;
           texthelp1.enabled = false;
        }
         }
    }

    void OnTriggerExit(Collider other)
    {
         if (GameController.instance.player == "dog")
         {
        pickableObject = null;
        texthelp.enabled = false;
    }
    }
}
