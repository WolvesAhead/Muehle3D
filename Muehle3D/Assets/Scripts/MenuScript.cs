using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Highscore()//Lädt Highscore Szene
    {
        Application.LoadLevel(3);
    }
    public void OnClick() //Lädt SPiele Szene
    {
        Application.LoadLevel(2);
    }

    public void Rules()//Lädt Regeln
    {
        Application.LoadLevel(1);
    }


    public void Back() // Geht ins Menü zurück
    {
        Application.LoadLevel(0);
    }
}
