using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

 
public class GameManager : MonoBehaviour
{
   Question[] _questions = null;
   public Question[] Questions { get { return _questions;} }

   [SerializeField] GameEvents events = null;

  // public QuesLevel mylevel;

   private List<int> FinishedQuestions = new List<int>();
   private int currentQuestion = 0;
   
  //private string color = mylevel.myText;
  // public string color  = GameObject.Find("Mylevel").GetComponent<QuesLevel>().myText;


 //  public submitOnclick click;
   public int color;
   public string  correctAns;

   
   
    
    void Start() {
        // string levelColor;
        foreach (GameObject ship in GameObject.FindGameObjectsWithTag("Ship"))
        {
            if (ship.transform.parent.GetComponent<NetworkIdentity>().hasAuthority) {
                color = ship.GetComponent<pop_up>().myColor;
            }
        }
        // color = GameObject.Find("Colonial Ship 1").GetComponent<pop_up>().myColor;
        LoadQuestions();
        foreach (var question in Questions) {
            Debug.Log(question.Info);
           //Debug.Log(question.Ans);
        }
        
        Display();

    }
     public void Display() {
        var question = GetRandomQuestion();
        correctAns = question.Ans;
       // checkAns(correctAns);

        
        


        //Debug.Log(index);
        if(events.UpdateQuestionUI != null) {
           events.UpdateQuestionUI(question);
        }
        else {
           Debug.LogWarning("oops something went wrong.try again");
        }

       
    }

   Question GetRandomQuestion () {
       var randomIndex  = GetRandomQuestionIndex();
       currentQuestion = randomIndex;
       return Questions[currentQuestion];
   }
    public int GetRandomQuestionIndex() {
       var random = 0;
        if (FinishedQuestions.Count < Questions.Length) {
           do{
               random = UnityEngine.Random.Range(0, Questions.Length);

           }while (FinishedQuestions.Contains(random) );
           
        }
       return random;
   }
    void LoadQuestions() {
    if(color == 0) {
           Object[] objs = Resources.LoadAll("hard", typeof(Question));
          _questions = new Question[objs.Length];
          for(int i  = 0; i < objs.Length; i++) {
           _questions[i]  = (Question)objs[i];
          }
    }
    else if (color == 2) {
         
       Object[] objs = Resources.LoadAll("easy", typeof(Question));
       _questions = new Question[objs.Length];
      
       
       for(int i  = 0; i < objs.Length; i++) {
           _questions[i]  = (Question)objs[i];
           
       }
    }
    else if (color == 1) {
         
       Object[] objs = Resources.LoadAll("medium", typeof(Question));
       _questions = new Question[objs.Length];
      
       
       for(int i  = 0; i < objs.Length; i++) {
           _questions[i]  = (Question)objs[i];
           
       }
    }
    else {
        Debug.LogWarning("opps something went wrong.try again");

    }
    }

    
}
// void checkAns(string correctAns, string testAns) {
//     if(correctAns == testAns) {
//         Debug.Log("answer matched");
        
//     }
//     else{
//         Debug.Log("answer not matched");
//     }
// }



 




