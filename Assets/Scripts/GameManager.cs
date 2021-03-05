using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{ 
    public static GameManager instance = null;

    //Variables para la vida
    VidaPlayer playerVida;
    public int      cantidad;
    public float    damageTime;
    float           currentDamageTime;
    /////

    public Text Puntaje;
    private int points = 0;
    public int numItems = 1;
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
        highScore = PlayerPrefs.GetInt("Score",10);

        ///Vida player
        playerVida = GameObject.FindWithTag("Player").GetComponent<VidaPlayer>();
        ///
    }

    // Update is called once per frame
    void Update()
    {
        LevelCompleted();   

    }
    public bool PickItem() {
        soundItem.Play();
        points += 10;
        Puntaje.text="Puntaje: "+points.ToString();
        numItemsCollected += 1;
        print("La cantidad de puntos "+points);
        return true;
    }
    public void PickCoin(){
        points += 2;
        Puntaje.text="Puntaje: "+points.ToString();
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
          
        }
        
            if (points > highScore)
            {
                PlayerPrefs.SetInt("Score", points);
            }
        
        
        print("La puntuacion maxima es"+highScore);

    }
   
    private void OnCollisionEnter(Collision collision)
    {
        currentDamageTime += Time.deltaTime;
        if(currentDamageTime > damageTime){
            playerVida.vida += cantidad;
            currentDamageTime = 0.0f;
        }        
    }

  }
