using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.IO;
using System;
using UnityEngine.UI;


public class ItemLManager : MonoBehaviour {
    private string musicName; // 読み込む譜面の名前
    private string level; // 難易度
    private TextAsset csvFile; // CSVファイル
    public List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト
    private int height = 0; // CSVの行数
                            // Use this for initialization
    void Start() {
        //csv読み込み
        musicName = "Shinkiro"; // 曲名
        //level = "0"; // 難易度
        csvFile = Resources.Load("CSV/" + musicName) as TextAsset; /* Resouces/CSV下のCSV読み込み */
        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(',')); // リストに入れる
            height++; // 行数加算
        }

        //仮にPlayerPrefs設定 本来は海ステージでセッティングされている
        for (int i = 1; i <= csvDatas.Count-1; i++ )
        {
           PlayerPrefs.SetInt(csvDatas[i][5], 0);
           
           
        }
        //確認のため奇数の要素を＝1とする
        for (int i = 1; i <= csvDatas.Count - 1; i++)
        {
            
            if (i % 2 == 1)
            {
                PlayerPrefs.SetInt(csvDatas[i][5], 1);
            }
        }

        
        //表示のためPlayerPrefs付け合わせ

            for (int i = 1; i <= csvDatas.Count - 1; i++)
            {
            int version = PlayerPrefs.GetInt(csvDatas[i][5], 0);
            int j = i % 13;
            int a = 1;

            if ( j == 0 )
            {
                j = 13;
            }
            else if (i == 13)
            {
                j = 13;
            }

                if (i > 26)
            {
                a = 3;
            }
            else if (i <= 26 && i > 13 )
            {
                a = 2;
            }

            if (version == 1)
                {
                    //imageの配置
                    GameObject Button001 = GameObject.Find("ItemObject/Item" + a.ToString() + "/Button" + j.ToString());
                    Texture2D texture = Resources.Load("Shinkiro/" + csvDatas[i][4]) as Texture2D;
                    Image img = Button001.GetComponent<Image>();
                    img.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                    //テキスト「？」→「」に変更
                    Button001.GetComponentInChildren<Text>().text = "　";


            }
        }
    }


    //戻るボタン押下
    public void PushButtonEnd()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
