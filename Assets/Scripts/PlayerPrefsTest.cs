using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsTest: MonoBehaviour {

	// Use this for initialization
	void Start () {

        PlayerPrefs.GetInt("VERSION", 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
