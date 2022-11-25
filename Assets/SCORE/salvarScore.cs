using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class salvarScore : MonoBehaviour
{
    public Text myScore;
    public string myName;
    public Button botaoEnviarScore;
    public InputField inputName;
    
    void Start(){
        botaoEnviarScore.interactable = false;
    }
    public void setName(){
        myName = inputName.text;
        if(myName == ""){
            botaoEnviarScore.interactable = false;
        }else{
            botaoEnviarScore.interactable = true;
        }
    }
    public void sendScore()
    {
        HighScores.UploadScore(myName, Player.pontos);
    }
}
