using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    Vector3 velocity;

    private bool isLocked = false;
    private void Start()
    {
        CharacterDialogueManager.onBeginDialogue += ToggleLock; 
    }
    void ToggleLock()
    {
        isLocked = !isLocked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocked)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
        
    }
}
