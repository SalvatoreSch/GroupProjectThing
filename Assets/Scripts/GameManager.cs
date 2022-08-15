using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    #region Variables
  
    public bool playerDead;
    public Transform playerpos;

   [SerializeField] public static GameObject player;
   
    public GameObject circlePrefab;
    public GameObject squarePrefab;
    public GameObject diamondPrefab;
    public GameObject hexagonPrefab;
    public GameObject capsulePrefab;
    public static GameObject currentShape;
    public Vector3 PlayerSize;
    private static float xMaxPos = 8;
    private static float _xMinPos = -8;
    private static float _yMinPos = 4;
    private static float _yMaxPos = 7;
    public static SpriteRenderer[] coinSpriteSelect;
    public static SpriteRenderer coinSprite;
    public static int arrayID = 0;
    #endregion

    #region UI Variables

    public Text playerScore;
    public Text playerSpeed;
    public static int score = 0;
    public static int scoreDisplay = 0;
    public static int speedCounter = 0;
    public  static int coinCount;
    public int playerMaxHP;
    public int playerCurrentHP;

    public static Transform playerPos;

    public static bool coolDown = false;
   
    #endregion


    

    private void Start()
    {

        //0 square, 1 diamond, 2 hexagon, 3 circle, 4 Capsule

      //  coinSpriteSelect[0] = squarePrefab;


        //  coinSprite = currentShape.GetComponent<SpriteRenderer>();

        // currentShape.gameObject.GetComponent <SpriteRenderer> = PlayerMovement.spriteSelection;
        // player = PlayerMovement.FindObjectOfType();
        PlayerSize = new Vector3(0.1f, 0, 0);
        currentShape = circlePrefab;
        score++;
    }

    

    void Update()
    {
        
        playerScore.text = "Score: " + scoreDisplay;
        playerSpeed.text = "Current Speed: " + PlayerMovement.speed;
    }




   public static void CoinCollected()
    {
       
        GameManager.score++;
        scoreDisplay++;
        //player.transform.localScale = player.transform.localScale + PlayerSize;
        if (score == 3)
        {
            
            speedCounter++;
            PlayerMovement.speed += 0.5f;
            score = 0;
            coinCount++;
            
        }

        SpawnNewCoin();
    }




    public static void SpawnNewCoin()
    {
     //   coinSprite.sprite = coinSpriteSelect[arrayID].sprite;
        Instantiate(currentShape, new Vector3(Random.Range(_xMinPos, xMaxPos), Random.Range(_yMinPos, _yMaxPos), 0), Quaternion.Euler(0, 0, 0));
        if (coinCount==5)
        {
            coinCount = 0;
           // speed = 7;
            SpawnNewCoin();
            arrayID = Random.Range(0, 4);
        }
    }
     
   

        
       
}
