using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{ 
    public static GameManager instance = null;

    private int points = 0;
    public int numItems = 1;

    public int life = 4;
    private bool stopMovement = false;
    private int highScore;
    public AudioSource soundItem;
    public AudioSource soundCoin;
    public AudioSource soundExplosion;
    public Text textScore;
    public Text textWin;
    public Text textItems;
    private GameState gameState;
    void Awake()
    {

        if(instance == null){
            instance = this;
        }else if(instance != null){
            Destroy(gameObject);
        }
        
       
    }
    public GameState getGameState()
    {
        return gameState;
    }
    public bool StopMovement{
        get{ return stopMovement;}
    }
    // Start is called before the first frame update
    void Start()
    {
       
        textScore.gameObject.SetActive(false);
        textWin.gameObject.SetActive(false);
        highScore = PlayerPrefs.GetInt("Score",0);
        gameState = new GameState(0,life,life,numItems,points);
        textItems.text = gameState.numItemsCollected + " / " + gameState.numItems;
    }
    
    // Update is called once per frame
    void Update()
    {
        LevelCompleted();   
    }
    public bool PickItem() {
        soundItem.Play();
        gameState.points += 10;

        gameState.numItemsCollected += 1;
        textScore.gameObject.SetActive(true);
        textItems.text = gameState.numItemsCollected + " / " + gameState.numItems;
        textScore.text = "+ " + 10;
        ActivationTextScoreRoutine();
        //print("La cantidad de puntos "+points);
        return true;
    }
    public void PickCoin(){
        gameState.points += 2;
        soundCoin.Play();
        textScore.gameObject.SetActive(true);
        textScore.text = "+ " + 2;
        
        //print("La cantidad de puntos "+points);
    }

    public void PickBarrel(){
        gameState.points += 5;
        soundCoin.Play();
        textScore.gameObject.SetActive(true);
        textScore.text = "+ " + 5;
        ActivationTextScoreRoutine();
        //print("La cantidad de puntos "+points);
    }
    public void loseLife()
    {
       
        if (gameState.lifes >0)
        {
            gameState.lifes--;
           
        }
        

    }
    public void loseLifeLaser()
    {

        if (gameState.lifes > 0)
        {
            gameState.lifes--;

        }
        soundExplosion.Play();


    }
    public void LevelCompleted() { 
        if (gameState.numItemsCollected == gameState.numItems)
        {

            string str = "";
            if (points > highScore)
            {
                str += "New High ";
            }
            str += "Score " + points;
            textWin.text = "You Win!";
            textScore.text = str;
            textScore.gameObject.SetActive(true);
            textWin.gameObject.SetActive(true);
          
        }
        
            if (points > highScore)
            {
                PlayerPrefs.SetInt("Score", gameState.points);
            }
        
        
        //print("La puntuacion maxima es"+highScore);

    }

    private IEnumerator ActivationTextScoreRoutine()
    {
        //Wait for 2 secs.
        yield return new WaitForSeconds(14);

        //Turn My game object that is set to false(off) to True(on).       
        textScore.gameObject.SetActive(false);
    }


  }
