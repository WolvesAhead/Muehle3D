using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour {

    public static bool colTrue = false;
    public static bool colTrue2 = false;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

   
	}

  private void OnTriggerEnter(Collider other)
    {
        if (Gameplay.player1Turn == true) // Wenn der Stein mit einem Collider der Punkte in Berührung kommt wird das die nächste Position
        {
            colTrue = true;
           // Debug.Log("Neue NextPos"+Drag.nextPos);
            Drag.nextPos = transform.position;
        }

        if (Gameplay.player2Turn == true)
        {
            colTrue2 = true;
            Drag2.nextPos = transform.position;
        }

    }

}
