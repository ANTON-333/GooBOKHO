using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandsController : MonoBehaviour
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
    public int c;
public int a;
public Text texthelp2;
    public Text texthelp3;
    public GameObject otherObgect;

    public GameObject myItem;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.player == "player")
        {
            if (myItem && Input.GetKeyDown(KeyCode.E))
            {

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
            else if ((a==1) && Input.GetKeyDown(KeyCode.F))
            {
jumpSpeed=5;
texthelp2.enabled=true;
            otherObgect.transform.Translate(new Vector3(0,jumpSpeed*Time.deltaTime,0));
 
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (GameController.instance.player == "player")
        {
              if (other.gameObject.CompareTag("Door") && (a==0))
            {
               print("hmm");
               a=1;
               otherObgect = other.gameObject;
               texthelp2.enabled=true;
               texthelp3.enabled=false;
            }
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
        if (GameController.instance.player == "player")
        {
            pickableObject = null;
            texthelp.enabled = false;
            
        }
    }
}
