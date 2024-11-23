using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class Sonar : MonoBehaviour

{
    public PlayerController player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other) 
    {
        if (other.tag != "Player" && !player.timerRunning) 
        {
            player.StartTimer();
        }
        
    }
}
