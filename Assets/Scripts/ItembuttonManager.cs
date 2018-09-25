using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class ItembuttonManager : MonoBehaviour {
    GameObject ItemListManager; //ItemListManagerそのものが入る変数
    ItemLManager script; //ItemLManagerScriptが入る変数
    GameObject SetumeiT;
    GameObject SetumeiB;
    GameObject ImageItem;

    private Text txt;

    // Use this for initialization
    void Start () {
        ItemListManager = GameObject.Find("ItemListManager"); 
        script = ItemListManager.GetComponent<ItemLManager>();
        SetumeiT = GameObject.Find("SetumeiObject/TextItemName");
        SetumeiB = GameObject.Find("SetumeiObject/TextItemSetumei");
        ImageItem = GameObject.Find("ImageItem");
    }

    //リストをItemLManager
    public void Itemhave()
    {
        List<string[]> unitychanHP = script.csvDatas; //新しく変数を宣言してその中にItemLManagerの変数csvDatasを代入する
        Debug.Log("CSVの内容は" + unitychanHP[0][1]);
        GameObject Button001 = this.gameObject;
        Texture2D texture;

    //テキストが？なら未発見を表示する
        string Naiyou = Button001.GetComponentInChildren<Text>().text;
        if (Naiyou != "　") {
            Debug.Log("未発見だよ");
            txt = SetumeiT.GetComponent<Text>();
            txt.text = "未発見";
            txt = SetumeiB.GetComponent<Text>();
            txt.text = "「？？？？？？？」";
            texture = Resources.Load("Shinkiro/Noimage") as Texture2D;
            Image img = ImageItem.GetComponent<Image>();
            img.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

        }
        else
        {
            Debug.Log("発見されているよ");

            
            GameObject parent = Button001.transform.parent.gameObject;
            string IdNo;

            int Butttonno01= int.Parse(Regex.Replace(Button001.name, @"[^0-9]", ""));
            int Itemno01 = int.Parse(Regex.Replace(parent.name, @"[^0-9]", ""));
            if (Itemno01 >= 2)
            {
                IdNo = (Butttonno01 + (13 * Itemno01)-13).ToString("000");
                Debug.Log(IdNo);
            }
            else
            {
                IdNo = Butttonno01.ToString("000");
            }
            //int i = unitychanHP.FindIndex(IdNo);
            for (int i = 1; i <= unitychanHP.Count - 1; i++)
            {

                if (unitychanHP[i][0] == IdNo)
                {
                    txt = SetumeiT.GetComponent<Text>();
                    txt.text = unitychanHP[i][1];
                    txt = SetumeiB.GetComponent<Text>();
                    txt.text = "蜃気楼：ランク" + unitychanHP[i][6]+ "\r\n"+ "地　域：" + unitychanHP[i][2] + "\r\n" + "\r\n" + unitychanHP[i][3];
                    texture = Resources.Load("Shinkiro/" + unitychanHP[i][4]) as Texture2D;
                    Image img = ImageItem.GetComponent<Image>();
                    img.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                    break;
                }
            }

        }


    }



    // Update is called once per frame
    void Update () {
		
	}
}
