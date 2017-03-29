using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public GameObject[] stones = new GameObject[18];
    private Vector3 oldPos;
    private bool inMuehleCheck = false;
    private int platz;
    private int ring;
    private int platzInMuehle;
    public static bool steinZerstoertWss = false;
    public static bool steinZerstoertSwz = false;

    // Use this for initialization
    void Start()
    {
      
           
        }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("inMühle Check"+inMuehleCheck );
   

        RaycastHit vHit = new RaycastHit();
        Ray vRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(vRay, out vHit, 1000) && Input.GetMouseButtonDown(1) && vHit.collider.gameObject.transform.tag == "Weiß" && Positions.foundMuehleSwz && Gameplay.player1Turn)
        {
            Debug.Log("Weiß Step1: "+ vHit.collider.gameObject.transform.tag);
            oldPos = vHit.collider.gameObject.transform.position;
            steinPosition();
            Positions.findMuehleWss();

            if (Positions.inMuehle[ring, platz] == false )
            {
                Debug.Log("Weiß Step2:"+ vHit.collider.gameObject.transform.position);
                vHit.collider.gameObject.transform.position = new Vector3(0,-10,0);
                Debug.Log("Weißer Stein zerstört");
                Gameplay.StonesleftWss--;

                GetComponent<AudioSource>().Play();
              
                Positions.colourArray2dim[ring,platz] = 'n';
                inMuehleCheck = false;
                Positions.foundMuehleSwz = false;
                Drag.oldMuehleSwz = false;
                Gameplay.Player2Turn();
                       
             }
            Debug.Log("Weiß Step3");
           // Gameplay.player1TurnOver = true;

               
        }

        if (Physics.Raycast(vRay, out vHit, 1000) && Input.GetMouseButtonDown(1) && vHit.collider.gameObject.transform.tag == "Schwarz" && Positions.foundMuehleWss && Gameplay.player2Turn)
        {
            Debug.Log("Schwarz Step1: "+ vHit.collider.gameObject.transform.tag);
            oldPos = vHit.collider.gameObject.transform.position;
            steinPosition();
            Positions.findMuehleSwz();

            if (Positions.inMuehle[ring, platz] == false)
            {
                Debug.Log("Schwarz Step2: "+ vHit.collider.gameObject.transform.position);
                vHit.collider.gameObject.transform.position = new Vector3(0, -10, 0);
                Debug.Log("Schwarzer Stein zerstört");
                Gameplay.StonesleftSwz--;

                GetComponent<AudioSource>().Play();

                Positions.colourArray2dim[ring, platz] = 'n';
                inMuehleCheck = false;
                Positions.foundMuehleWss = false;
                Gameplay.Player1Turn();
               
            }
            Debug.Log("Schwarz Step3");
            //Gameplay.player2TurnOver = true;
            
        }

       

      
    }

    void steinPosition()
    {
        ring = 0;
        platz = 0;
        for (int m = 0; m < 3; m++)
        {
            for (int n = 0; n < 8; n++) {

              
                if (Positions.positionArray2dim[m,n] == oldPos)
                {
                    inMuehleCheck = true;
                    ring =  m;
                    platz = n;

                }
            }
            
        }
       
    }
   /* private void OnMouseDown()
    {
        RaycastHit vHit = new RaycastHit();
        Ray vRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(vRay, out vHit, 1000))
        {
            Destroy(vHit.collider.gameObject);
        }
        */
        /* if (Positions.foundMuehleSwz == true && gameObject.transform.tag == "Weiß")
          {
          Destroy(gameObject);
              Debug.Log("Weißer Stein zerstört");
          }

          if (Positions.foundMuehleWss == true && gameObject.transform.tag == "Schwarz")
          {

              Destroy(gameObject);
              Debug.Log("Schwarzer Stein zerstört");
          }
      }

      public static void ZerstoereSwzStein(GameObject gameObject)
      {

          if (Positions.foundMuehleSwz == true && gameObject.transform.tag == "Weiß")
          {
              Destroy(gameObject);
              Debug.Log("Weißer Stein zerstört");
          }
      }*/
    }


