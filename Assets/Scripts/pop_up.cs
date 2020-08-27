using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;


public class pop_up : NetworkBehaviour
{
    int layerCol = 2;
    public Material myMaterial;
    // public GameObject Ship;
    public GameObject Cube;
    public int myColor;
    Color red = new Color(1, 0, 0, 1);
    Color blue = new Color(0, 0, 1, 1);
    Color green = new Color(0, 1, 0, 1);
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (transform.parent.GetComponent<NetworkIdentity>().hasAuthority)
        {
            bool loadScene = false;
            Debug.Log("cannon");
            if (collisionInfo.gameObject.tag == "cannon" && !loadScene)
            {
                if (collisionInfo.gameObject.GetComponent<Renderer>().sharedMaterial.color == blue) {
                    myColor = 2;
                }
                else if (collisionInfo.gameObject.GetComponent<Renderer>().sharedMaterial.color == green) {
                    myColor = 1;
                }
                else if (collisionInfo.gameObject.GetComponent<Renderer>().sharedMaterial.color == red) {
                    myColor = 0;
                }
                Debug.Log("cannon");
                GameObject.Find("Sail_01").GetComponent<MeshRenderer>().material = myMaterial;
                GameObject.Find("Sail_02").GetComponent<MeshRenderer>().material = myMaterial;
                // GameObject.Find("Colonial Ship 1").layer = layerCol;
                // Ship.layer = 2;
                Cube.layer = 2;
                SceneManager.LoadScene("button", LoadSceneMode.Additive);
                loadScene = true;
            }
        }
    }
}
