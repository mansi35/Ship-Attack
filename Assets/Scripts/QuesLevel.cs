using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mirror;

public class QuesLevel : NetworkBehaviour
{
    public Button Easy;
    public Button Hard;
    public Button Medium;
    public GameObject Sphere;

    public string myText;
   // public GameManager ItsObject;


    private void start()
    {
        if (transform.parent.GetComponent<NetworkIdentity>().hasAuthority)
        {
       // Button btn =myButton.GetComponent<Button>();
            Easy.onClick.AddListener(EasyType);
            Hard.onClick.AddListener(HardType);
            Medium.onClick.AddListener(MediumType);
        }
    }
    public void EasyType(){
        // myText = Easy.GetComponentInChildren<Text>().text;
        // Debug.Log(myText);
        Sphere.GetComponent<Renderer>().sharedMaterial.color = new Color(0, 0, 1, 1);
        myText = "blue";
        Debug.Log(myText);
         //GameObject.Find("Managers").GetComponent<GameManager>().color = "blue";
       //ItsObject.color = "blue";


    }
    public void HardType(){
        // myText = Hard.GetComponentInChildren<Text>().text;
        // Debug.Log(myText);
        Sphere.GetComponent<Renderer>().sharedMaterial.color = new Color(1, 0, 0, 1);
       myText = "red";
      // ItsObject.color = "red";
               // GameObject.Find("Managers").GetComponent<GameManager>().color = "red";
    }
    public void MediumType(){
        // myText =Medium.GetComponentInChildren<Text>().text;
        // Debug.Log(myText);
        Sphere.GetComponent<Renderer>().sharedMaterial.color = new Color(0, 1, 0, 1);
        myText = "green";
       //ItsObject.color = "green";
             // GameObject.Find("Managers").GetComponent<GameManager>().color = "green";
    }
    
}