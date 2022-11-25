using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [HideInInspector]
    Rigidbody2D rb;
    [HideInInspector]
    public Animator anim;


    public bool grounded;
    Touch theTouch;
    public bool gameOver;

    public static int pontos;

    private float nextActionTime = 0.0f;
    public float period = 0.5f;

    public string currentState;


    //HUD
    public GameObject gameOverCanvas;
    public Text pontosText;


    
    void Start()
    {
        pontos = 0;
        gameOver = false;
        grounded = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.time > nextActionTime ) {
            nextActionTime += period;
            pontos += 10;
            pontosText.text = pontos.ToString();
        }
        
        
        if (Input.touchCount > 0)
        {
            Debug.Log("touch");
            if(!gameOver)
            {
                if(grounded){
                    rb.velocity = new Vector3(0, 12, 0);
                }
            }
        }

        if(rb.velocity.y > 1){
            ChangeState("jumping");
        }else if(rb.velocity.y < 0){
            ChangeState("falling");
        }else if(gameOver){

        }
        else{
            ChangeState("walk");
        }
    }

    public void gameOverFunction(){
        Time.timeScale = 0;

        gameOverCanvas.SetActive(true);
    }

    public void respawnDino(){
        pontos = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene("game");

    }
    
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag=="Chao"){
            grounded = true;
        }

        if(col.gameObject.tag=="Cacto"){
            gameOver = true;
            gameOverFunction();
        }

    }

    void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.tag=="Chao"){
            grounded = false;
        }
    }

    //MAQUINA DE ESTADOS ANIMAÇÃO
    internal void ChangeState(string newState)
    {
        if (newState != currentState)
        {
            anim.Play(newState);
            currentState = newState;
        }
    }
}
