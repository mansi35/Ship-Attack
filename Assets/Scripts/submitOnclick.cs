using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;

public class submitOnclick : MonoBehaviour
{
  int layerCol = 0;
  public Button btnClick;
  public Material Sails_01;
  public Material Sails_02;
  public GameObject Question;
  public InputField inputUser;



  public GameManager game;

  private void Start()
  {
    btnClick.onClick.AddListener(GetInputOnClickHandler);   
  }

  public void GetInputOnClickHandler()
  {
    //Debug.Log(GetType(inputUser.text.ToString()));

    string myans =inputUser.text.ToString();

    string correctAns =  game.correctAns;
    checkAns( myans, correctAns);
    GameObject.Find("Sail_01").GetComponent<Renderer>().material = Sails_01;
    GameObject.Find("Sail_02").GetComponent<Renderer>().material = Sails_02;
    GameObject.Find("Colonial Ship 1").layer = layerCol;
    Question.SetActive(false);

  }   

  public void checkAns( string myans , string correctAns)
  {
    if( myans != correctAns)
    {
      Debug.Log("False");
      if (transform.parent.GetComponent<NetworkIdentity>().hasAuthority) {
        Debug.Log("I am still here!");
        health Health = transform.parent.GetComponent<health>();

        if (Health != null)
        {
            Health.TakeDamage(10);
        }
      }


    }
    else
    {
      Debug.Log("True");
    }
  }
}
