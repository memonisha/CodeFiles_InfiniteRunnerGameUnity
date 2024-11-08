
using System;
//using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;


public class PlayerScript : MonoBehaviour
{
    public float JumpForce;
   float score;
    

[SerializeField]
bool isGrounded=false;
bool isAlive=true;



Rigidbody2D RB;


public TMP_Text ScoreTxt;
public TMP_Text GameOverTxt;


public void Start(){
    RB=GetComponent<Rigidbody2D>();
    score=0;
    

}



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(isGrounded==true){
                RB.AddForce(Vector2.up*JumpForce);
                isGrounded=false;
            }
        }
        if(isAlive==true)
        {
            
            score+=Time.deltaTime*4;
           
            ScoreTxt.text="SCORE: " + ((int)score).ToString();
            Debug.Log(score);
        }
    }
   private void OnCollisionEnter2D(Collision2D collision){
    if(collision.gameObject.CompareTag("ground")){
        if(isGrounded==false){
            isGrounded=true;
        }
    }
    if(collision.gameObject.CompareTag("spike")){
        isAlive=false;
        Debug.Log("END");
        Time.timeScale=0;
        GameOverTxt.text="GAME OVER";
    }
   }
}
