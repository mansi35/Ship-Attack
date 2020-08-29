using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mirror;

public class QuesLevel : NetworkBehaviour
{
    // [SyncVar]
    // public Color color;
    // [SyncVar]
    // private Color myColor;
    public Button Easy;
    public Button Hard;
    public Button Medium;
    // [SyncVar]
    // private GameObject Sphere;

    public int myText;
   // public GameManager ItsObject;


    private void start()
    {
        if (transform.parent.GetComponent<NetworkIdentity>().hasAuthority)
        {
       // Button btn =myButton.GetComponent<Button>();
            Debug.Log("I am here");
            Easy.onClick.AddListener(EasyType);
            Hard.onClick.AddListener(HardType);
            Medium.onClick.AddListener(MediumType);
        }
    }
    public void EasyType(){
        // myText = Easy.GetComponentInChildren<Text>().text;
        // Debug.Log(myText);
        // myColor = new Color(0, 0, 1, 1);
        // Sphere.GetComponent<Renderer>().sharedMaterial.color = myColor;
        myText = 0;
        Debug.Log(myText);
        // RpcColorMe();
         //GameObject.Find("Managers").GetComponent<GameManager>().color = "blue";
       //ItsObject.color = "blue";


    }
    public void HardType(){
        // myText = Hard.GetComponentInChildren<Text>().text;
        // Debug.Log(myText);
        // myColor = new Color(1, 0, 0, 1);
        // Sphere.GetComponent<Renderer>().sharedMaterial.color = myColor;
        myText = 2;
        Debug.Log(myText);
        // RpcColorMe();
      // ItsObject.color = "red";
               // GameObject.Find("Managers").GetComponent<GameManager>().color = "red";
    }
    public void MediumType(){
        // myText =Medium.GetComponentInChildren<Text>().text;
        // Debug.Log(myText);
        // myColor = new Color(0, 1, 0, 1);
        // Sphere.GetComponent<Renderer>().sharedMaterial.color = myColor;
        myText = 1;
        Debug.Log(myText);
        // RpcColorMe();
       //ItsObject.color = "green";
             // GameObject.Find("Managers").GetComponent<GameManager>().color = "green";
    }

    // [ClientRpc]
    // void RpcColorMe() {
    //     Sphere.GetComponent<Renderer>().sharedMaterial.color = myColor;
    // }
    
    // public override void OnStartServer()
    // {
    //     color = myColor;
    //     RpcColorMe(color);

    // }

    // [ClientRpc]
    // void RpcColorMe( Color value )
    // {
    //     //set the color on the renderer (or however you do it)
    //     color = value;
    // }

    
}