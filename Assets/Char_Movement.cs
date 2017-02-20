using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Char_Movement : MonoBehaviour
{
    // How fast to move
    public float speed = 3.0F;
    // Should I move forward or not
    public bool moveForward, moveLeft, moveBack, moveRight, jump;
    // CharacterController script
    private CharacterController controller;
    // GvrViewer Script
    private GvrViewer gvrViewer;
    // VR Head
    private Transform vrHead;

    // Use this for initialization
    void Start()
    {
        // Find the CharacterController
        controller = GetComponent<CharacterController>();
        // Find the GvrViewer on child 0
        gvrViewer = transform.GetChild(0).GetComponent<GvrViewer>();
        // Fnd the VR Head
        vrHead = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {

        // In the Google VR button press
        if (GvrController.IsTouching)
        {
            Vector2 touchPos = GvrController.TouchPos;

            if (touchPos.x > 0.66)
            {
                //if (touchPos.y <= 0.33) {
                //moveRight = !moveRight;
                //moveForward = !moveForward;
                //} 
                if (touchPos.y > 0.33 && touchPos.y <= 0.66)
                {
                    moveRight = !moveRight;
                }
                //else {
                //    moveBack = !moveBack;
                //    moveRight = !moveRight;
                //}
            }
            else if (touchPos.x > 0.33 && touchPos.x < 0.66)
            {
                if (touchPos.y <= 0.33)
                {
                    moveForward = !moveForward;
                }
                else if (touchPos.y > 0.33 && touchPos.y <= 0.66)
                {
                    jump = !jump;
                }
                else {
                    moveBack = !moveBack;
                }
            }
            else {
                //if (touchPos.y <= 0.33) {
                //    moveLeft = !moveLeft;
                //    moveForward = !moveForward;
                //}
                if (touchPos.y > 0.33 && touchPos.y <= 0.66)
                {
                    moveLeft = !moveLeft;
                }
                //else {
                //    moveBack = !moveBack;
                //    moveLeft = !moveLeft;
                //}
            }
            // Check to see if I should move
            if (moveForward)
            {
                // Find the forward direction
                Vector3 forward = vrHead.TransformDirection(Vector3.forward);
                // Tell CharacterController to move forward
                controller.SimpleMove(forward * speed);

            }
            if (moveBack)
            {
                // Find the forward direction
                Vector3 forward = vrHead.TransformDirection(Vector3.forward);
                // Tell CharacterController to move forward
                controller.SimpleMove(forward * speed * (-1));

            }
            if(moveRight)
            {
                Vector3 right = vrHead.TransformDirection(Vector3.right);
                // Tell CharacterController to move forward
                controller.SimpleMove(right * speed);
            }
            if (moveLeft)
            {
                Vector3 right = vrHead.TransformDirection(Vector3.right);
                // Tell CharacterController to move forward
                controller.SimpleMove(right * speed * (-1));
            }
        }
    }
}