using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class Sonar : MonoBehaviour
   
{
    public PlayerController player;
    public float speed;
    public bool detect = false;

    void Update() 
    {
        transform.position = player.transform.position;
    }

    void OnTriggerStay2D(Collider2D other) 
    {        
        if (other.tag == "Objective") 
        {
            detect = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Objective") 
        {
            detect = false;
        }
    }
}
