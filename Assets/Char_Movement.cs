using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Char_Movement : MonoBehaviour
{

    //Vr main camera
    public Transform vrCamera;

    //Angle which the walk stop will be triggered
    public float toggleAngle = 30.0f;

    //Stop / move
    bool moveForward;

    // Speed
    float speed = 3.0f;

    //acces the character controller
    private CharacterController cc;



   

    // Use this for initialization
    void Start()
    {
        // Find the CharacterController
        cc= GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

        //Check if Vr Cameria is below 30 but not above 90 degrees

        if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f)
        {
            moveForward = true;
        }
        else
        {
            moveForward = false;
        }

        if (GvrController.IsTouching)
        {
            moveForward = true;
        }

        if (moveForward)
        {
            //Vector3 forward = vrCamera.TransformDirection(Vector3.forward);

            Vector3 forward2 = GvrController.Orientation * Vector3.forward;

            //cc.SimpleMove(forward * speed);

            cc.SimpleMove(forward2 * speed);
        }

    }    
}