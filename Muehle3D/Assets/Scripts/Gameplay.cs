using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{

    
    public static bool player1Turn = true;
    public static bool player2Turn = false;
    public static bool player1TurnOver = false;
    public static bool player2TurnOver = false;
    public static bool player1PhaseOne = true;
    public static bool player2PhaseOne = true;
    public static bool player1PhaseTwo = false;
    public static bool player2PhaseTwo = false;
    public static bool player1PhaseThree = false;
    public static bool player2PhaseThree = false;
    public static int countTurn = 0;
    public static int WinTurn;
    public static bool GameOver = false;

    private Text Weiß_wins;
    private Text Schwarz_wins;

    public static int Stonesleft = 18;
    public static int StonesleftWss = 9;
    public static int StonesleftSwz = 9;
    // Use this for initialization

    void Start()
    {
        Weiß_wins = GameObject.Find("Weiß_wins").GetComponent<Text>();
        Schwarz_wins = GameObject.Find("Schwarz_wins").GetComponent<Text>();
    }

    private void Update()
    {
        //Debug.Log("Player 2 Phase 2" + player2PhaseTwo);
        //Debug.Log("Player 1 Phase 2" + player1PhaseTwo);

        //Debug.Log("StonesleftSwz:" + StonesleftSwz);
        //Debug.Log("StonesleftWss:" + StonesleftWss);
        if (Input.GetMouseButtonDown(2) && player1TurnOver && player1Turn )
        {
            player2TurnOver = false;
            Player2Turn();
        }

        if (Input.GetMouseButtonDown(2) && player2TurnOver && player2Turn )
        {
            player1TurnOver = false;
            Player1Turn();
        }

        // Player1Turn();
        if (Stonesleft == 0)
        {
            player1PhaseOne = false;
            player2PhaseOne = false;
            player1PhaseTwo = true;
            player2PhaseTwo = true;


        }


        if (StonesleftSwz <= 4)
        {
            player1PhaseThree = true;
            player1PhaseTwo = false;
   
            if (StonesleftSwz < 3)
            {
                Debug.Log("######################Schwarz hat verloren###############################");
               Weiß_wins.enabled = true;
                GameOver = true;
                WinTurn = countTurn;

            }
        }

        if(StonesleftWss <= 4)
        {

            player2PhaseThree = true;
            player2PhaseTwo = false;

            if (StonesleftWss < 3)
            {
                Debug.Log("######################Weiß hat verloren######################");
                Schwarz_wins.enabled = true;
                GameOver = true;
                WinTurn = countTurn;
            }
        }
        
        //Debug.Log("Runden: "+countTurn);  //Player2Turn();

    }



   public static void Player1Turn()
    {
        
       
       
            Camera.main.transform.localPosition = new Vector3(0, 8, -10);
            Camera.main.transform.localRotation = Quaternion.Euler(30, 0, 0);


            countTurn += 1;

        Positions.foundMuehleSwz = false;
        Positions.foundMuehleWss = false;
        player1Turn = true;
        player2Turn = false;
        player2TurnOver = false;
        //Positions.foundMuehleSwz = false;
        //Positions.foundMuehleWss = false;

    }

   public static void Player2Turn()
    {
            
        

            Camera.main.transform.localPosition = new Vector3(0, 8, 10);
            Camera.main.transform.localRotation = Quaternion.Euler(30, 180, 0);

            countTurn += 1;

        Positions.foundMuehleSwz = false;
        Positions.foundMuehleWss = false;
        player1Turn = false;
        player2Turn = true;
        player1TurnOver = false;
            //Positions.foundMuehleSwz = false;
            //Positions.foundMuehleWss = false;
       

    }

  

    
}

