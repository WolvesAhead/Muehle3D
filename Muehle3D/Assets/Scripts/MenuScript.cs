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

    public void Highscore()
    {
        Application.LoadLevel(3);
    }
    public void OnClick()
    {
        Application.LoadLevel(2);
    }

    public void Rules()
    {
        Application.LoadLevel(1);
    }


    public void Back()
    {
        Application.LoadLevel(0);
    }
}
