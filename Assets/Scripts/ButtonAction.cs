using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Button MenuButton = GetComponent<Button>();    // 対象のボタン
        MenuButton.animator.SetTrigger("Highlighted");
    }


	
	// Update is called once per frame
	void Update () {
		
	}
}
