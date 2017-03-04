
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Char_Movement : MonoBehaviour
{
    // How fast to move
    public float speed = 3.0F;
    
    // Should I move forward or not
    public bool moveForward, 
                moveRight, 
                jump;
    
    // CharacterController script
    private CharacterController controller;
    
    // GvrViewer Script
   public GvrViewer gvrViewer;
    
    // VR Head
    private Transform vrHead;
    
    //Forward and Right Direction
    Vector3 mForward;
    Vector3 mRight;
    Vector2 touchPos;
    
    // Use this for initialization
    void Start()
    {
        // Find the CharacterController
        controller = GetComponent<CharacterController>();
        
        // Find the GvrViewer on child 0
        gvrViewer = transform.GetChild(0).GetComponent<GvrViewer>();  //TODO: CHECK TO SEE IF GETCHILD9 0 ) IS RETURNING gvrVIEWER
        
        // Fnd the VR Head
        vrHead = Camera.main.transform;
        
        //Get the GVR controller touch pad touch position
        touchPos = GvrController.TouchPos;
        
    }


    // Update is called once per frame
    void Update()
    {
        // Find the forward direction
        mForward = vrHead.TransformDirection(Vector3.forward);
        
        // Fomd the right direction
        mRight = vrHead.TransformDirection(Vector3.right);
        
        
        
        
        // In the Google VR button press
        if (GvrController.IsTouching)
        {
        
            // Get our current touch position
            touchPos = GvrController.TouchPos;

/* ------------------------------------------------------------------------------- */
/* _______________________________________________________________________________ */
/*                            Check to see which Direction I should Move           */
/* _______________________________________________________________________________ */
/* ------------------------------------------------------------------------------- */
            
            
/*RIGHT*/   if (touchPos.x > 0.66)
            {

                if (touchPos.y > 0.33 && touchPos.y <= 0.66)
                {
                    moveRight = true;
                }

            }
/*FRONT*/    else if (touchPos.x > 0.33 && touchPos.x < 0.66)
            {
                if (touchPos.y <= 0.33)                                 /* MOVE FORWARD */
                {
                    moveForward = true; 
                }
                else if (touchPos.y > 0.33 && touchPos.y <= 0.66)       /* MOVE JUMP ?? */
                {
                    jump = true;
                }
                else {
                    moveForward = false;                               /* MOVE BACKWARD*/
                }
            }
/*LEFT */   else {
               
                if (touchPos.y > 0.33 && touchPos.y <= 0.66)
                {
                    moveRight = false;
                }
               
            }
            

            
            if (moveForward)
            {
              
                // Tell CharacterController to move forward
                controller.SimpleMove(mForward * speed);

            }
            if (!moveForward)
            {
                
                // Tell CharacterController to move forward
                controller.SimpleMove(mForward * speed * (-1));
            }
            
            
            if(moveRight)
            {

                // Tell CharacterController to move forward
                controller.SimpleMove(mRight * speed);
            }
            if (!moveRight)
            {          
                // Tell CharacterController to move forward
                controller.SimpleMove(mRight * speed * (-1));
            }
        }
    }
}
