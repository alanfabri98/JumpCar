using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{ 
    public static GameManager instance = null;

    private int points = 0;
    private int numItems = 1;
    private int numItemsCollected = 0;
    private bool stopMovement = false;
    private int highScore;
    public AudioSource soundItem;
    public AudioSource soundCoin;
    public Text textScore;
    public Text textWin;
    void Awake()
    {

        if(instance == null){
            instance = this;
        }else if(instance != null){
            Destroy(gameObject);
        }
       
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
    }

    // Update is called once per frame
    void Update()
    {
        LevelCompleted();   
    }
    public bool PickItem() {
        soundItem.Play();
        points += 10;
        numItemsCollected += 1;
        print("La cantidad de puntos "+points);
        return true;
    }
    public void PickCoin(){
        points += 2;
        soundCoin.Play();
        print("La cantidad de puntos "+points);
    }
  
 
    public void LevelCompleted() { 
        if (numItemsCollected == numItems)
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
            //SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
        
            if (points > highScore)
            {
                PlayerPrefs.SetInt("Score", points);
            }
        
        
        print("La puntuacion maxima es"+highScore);

    }
   


  }
