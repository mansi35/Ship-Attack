using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class submitOnclick : MonoBehaviour
{
  int layerCol = 0;
  public Button btnClick;
  public Material Sails_01;
  public Material Sails_02;

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
    SceneManager.UnloadSceneAsync("button");

  }   

  public void checkAns( string myans , string correctAns)
  {
    if( myans == correctAns)
    {
      Debug.Log("true");
    }
    else
    {
      Debug.Log("False");
    }
  }
}
