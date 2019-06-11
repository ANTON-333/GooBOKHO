using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{


    public static GameController instance;
    public int c;

    public string player = "player";
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if ((c == 0) && Input.GetKeyDown(KeyCode.V))
        {
            GameController.instance.player = "player";
            c = 1;
        } else
        if ((c == 1) && Input.GetKeyDown(KeyCode.V))
        {
            GameController.instance.player = "dog";
            c = 0;
        }
    }

}