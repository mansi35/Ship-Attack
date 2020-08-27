using UnityEngine;
using Mirror;

public class PlayerControl : NetworkBehaviour
{
    [SyncVar]
    public Vector3 Control; //This is a sync var, mirror automatically shares and syncs this variable across all of the scripts on objects with the same network identity, but it can only be set by the server.
     public float speed = 40f;
    public float speedrate = 40f;
    public Color c;//color to change to if we are controlling this one
   
    void Awake() {
        Application.targetFrameRate = 10;    
    }
    void Update()
    {
        if (GetComponent<NetworkIdentity>().hasAuthority)//make sure this is an object that we ae controlling
        {
            // GetComponent<Renderer>().material.color = c;//change color
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Control = new Vector3(moveHorizontal, 0.0f, moveVertical);//update our control varible
            GetComponent<PhysicsLink>().ApplyForce(Control, speed, speedrate);//Use our custom force function
            GetComponent<PhysicsLink>().ApplyTorque(moveHorizontal, speed);
            if (Input.GetAxis("Cancel") == 1)//if we press the esc button
            {
                GetComponent<PhysicsLink>().CmdResetPose();//reset our position
            }
        }
    }
}