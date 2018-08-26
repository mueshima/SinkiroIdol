using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemListManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Toppingボタン押下
    public void PushButtonTopping()
    {
        SceneManager.LoadScene("ItemListToppingScene");
    }

    //器ボタン押下
    public void PushButtonUtuwa()
    {
        SceneManager.LoadScene("ItemListUtuwaScene");
    }

    //スープボタン押下
    public void PushButtonSoup()
    {
        SceneManager.LoadScene("ItemListSoupScene");
    }

    //麺ボタン押下
    public void PushButtonMen()
    {
        SceneManager.LoadScene("ItemListMenScene");
    }

    //戻るボタン押下
    public void PushButtonEnd()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
