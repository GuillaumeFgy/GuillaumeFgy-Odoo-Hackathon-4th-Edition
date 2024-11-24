using System;
using System.Diagnostics;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioSource sourceCarpet;
    public AudioSource sourceStone;
    public AudioSource sourceWood;
    public AudioSource sourceHit;
    public AudioSource sourceBathroom;

    private AudioSource currentStep;

    public float stepInterval = 0.3f; // Time interval between steps
    private float stepTimer = 0f; // Timer to track steps
    public float pitchVariation = 0.2f; // How much to vary the pitch
    public PlayerController characterController;


    void Start()
    {
        characterController = GetComponent<PlayerController>(); // Get movement controller
        currentStep = sourceCarpet;
    }

    void Update()
    {
        // Check if the player is moving
        if (characterController != null && (characterController.posx != 0 ||characterController.posy != 0))
        {
            stepTimer += Time.deltaTime;

            if (stepTimer >= stepInterval)
            {
                PlayFootstep();
                stepTimer = 0f; // Reset timer
            }
        }
        else
        {
            stepTimer = 0f; // Reset timer if not moving
        }
    }

    void PlayFootstep()
    {

        // Apply a slight random pitch variation
        currentStep.pitch = 1f + UnityEngine.Random.Range(-pitchVariation, pitchVariation);

        // Play the clip
        currentStep.Play();

    }

    void OnTriggerEnter2D(Collider2D other) 
    {

        if (tag == "Player" && tag != "Sonar" && other.tag == "door")
        {
            UnityEngine.Debug.Log(other.transform.name);
            switch (other.transform.name)
            {
                

                case "1":
                    currentStep = sourceStone; break;
                case "2":
                    currentStep = sourceStone; break;
                case "3":
                    currentStep = sourceStone; break;
                case "4":
                    currentStep = sourceCarpet; break;
                case "5":
                    currentStep = sourceCarpet; break;
                case "6":
                    currentStep = sourceCarpet; break;
                case "7":
                    currentStep = sourceWood; break;
                case "8":
                    currentStep = sourceWood; break;
                case "9":
                    currentStep = sourceStone; break;
                case "10":
                    currentStep = sourceBathroom; break;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (tag == "Player" && tag != "Sonar" && (other.transform.name == "walls" || other.transform.name == "decors" || other.transform.name == "decors 2"))
        {
            sourceHit.pitch = 1f + UnityEngine.Random.Range(-pitchVariation, pitchVariation);
            sourceHit.Play();
        }
    }
    

}
