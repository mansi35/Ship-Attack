using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class switchMode : NetworkBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject ColonialShip;
    public GameObject Camera;
    public move Move ;
    public PlayerControl Sail;
    public GameObject playerCamera;
    public GameObject PlayerPosition;

    void Update()
    {
        if (transform.parent.parent.GetComponent<NetworkIdentity>().hasAuthority)
        {
            if(Input.GetKey("1"))
            {
                GameObject.Find("Ocean").GetComponent<Crest.OceanRenderer>().Viewpoint = Camera.transform;
                ColonialShip.GetComponent<Rigidbody>().isKinematic = false;
                PlayerPrefab.GetComponent<PlayerControl>().enabled = true;
                // Sail.enabled = true;
                Camera.SetActive(true);
                playerCamera.SetActive(false);

                Move.enabled=false;
            }
            if (Input.GetKey("2"))
            {
                GameObject.Find("Ocean").GetComponent<Crest.OceanRenderer>().Viewpoint = playerCamera.transform;
                ColonialShip.GetComponent<Rigidbody>().isKinematic = true;
                PlayerPrefab.GetComponent<PlayerControl>().enabled = false;
                Camera.SetActive(false);
                playerCamera.SetActive(true);
                // Sail.enabled = false;

                Move.enabled=true;
                Move.transform.position = PlayerPosition.transform.position;
            }
        }
    }
}
