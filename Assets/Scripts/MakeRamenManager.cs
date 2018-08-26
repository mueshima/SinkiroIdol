using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MakeRamenManager : MonoBehaviour {

    public Dropdown dropdownCup;    //うつわドロップダウン
    public Dropdown dropdownSoup;    //スープドロップダウン
    public Dropdown dropdownMen;    //麺ドロップダウン

    public GameObject messageObj;   //メッセージオブジェクト
    public GameObject messageText;  //メッセージエリア

    public GameObject buttonYes;    //はいボタン
    public GameObject buttonNo;     //いいえボタン
    public GameObject buttonOk;     //Okボタン

    ////トッピングリスト
    //[SerializeField]
    //RectTransform prefab = null;

    [SerializeField]

    private GameObject btnPref;  //ボタンプレハブ

    //ボタン表示数
    const int BUTTON_COUNT = 2;


    //アイテム定数
    public const int RAMEN_FUTU = 0;
    public const int RAMEN_MIRA = 1;

    public const int TOPPING_EGG = 0;
    public const int TOPPING_MIRA = 1;

    //ラーメン完成品
    public GameObject ramenList;

    //ラーメン名
    public GameObject ramenNm;

    //ステータスレア度値
    public GameObject statusReaVal;

    //ラーメン画像リスト
    public Sprite[] ramenPicture = new Sprite[2];

    //topping画像リスト
    public Sprite[] toppingPicture = new Sprite[2];
    private int[] toppingList = new int[2];

    private string musicName; // 読み込む譜面の名前
    private string level; // 難易
    private TextAsset csvFile; // CSVファイル
    private List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト
    private int height = 0; // CSVの行数

    public Text text;

    // Use this for initialization
    void Start () {

        buttonOk.SetActive(false);
        messageObj.SetActive(false);

        //うつわ設定
        if (dropdownCup)
        {
            dropdownCup.ClearOptions();    //現在の要素をクリアする
            List<string> listcup = new List<string>();
            listcup.Add("普通");           //CSVファイルよりリストを取得する。
            listcup.Add("黒");
            listcup.Add("ミラたん");
            dropdownCup.AddOptions(listcup);  //新しく要素のリストを設定する
            dropdownCup.value = 0;         //デフォルトを設定(0～n-1)
        }

        //スープ設定
        if (dropdownSoup)
        {
            dropdownSoup.ClearOptions();    //現在の要素をクリアする
            List<string> listSoup = new List<string>();
            listSoup.Add("しょうゆ");           //CSVファイルよりリストを取得する。
            listSoup.Add("しお");
            listSoup.Add("みそ");
            listSoup.Add("ブルー");
            dropdownSoup.AddOptions(listSoup);  //新しく要素のリストを設定する
            dropdownSoup.value = 0;         //デフォルトを設定(0～n-1)
        }

        //麺設定
        if (dropdownMen)
        {
            dropdownMen.ClearOptions();    //現在の要素をクリアする
            List<string> listMen = new List<string>();
            listMen.Add("細い");           //CSVファイルよりリストを取得する。
            listMen.Add("太い");
            listMen.Add("ちじれ");
            dropdownMen.AddOptions(listMen);  //新しく要素のリストを設定する
            dropdownMen.value = 0;         //デフォルトを設定(0～n-1)
        }


        //Content取得(ボタンを並べる場所)
        RectTransform content = GameObject.Find("CanvasGame/PanelWalls/Scroll View/Viewport/Content").GetComponent<RectTransform>();

        //Contentの高さ決定

        //(ボタンの高さ+ボタン同士の間隔)*ボタン数

        //float btnSpace = content.GetComponent<VerticalLayoutGroup>().spacing;

        //float btnHeight = btnPref.GetComponent<LayoutElement>().preferredHeight;

        //content.sizeDelta = new Vector2(0, (btnHeight + btnSpace) * BUTTON_COUNT);
        toppingList[0] = TOPPING_EGG;
        toppingList[1] = TOPPING_MIRA;

        for (int i = 0; i < BUTTON_COUNT; i++)

        {

            int no = i;

            //オブジェクト作成
            GameObject ItemCheck = (GameObject)Instantiate(btnPref);

            //オブジェクトをContentの子に設定
            ItemCheck.transform.SetParent(content, false);

            //オブジェクトのテキスト変更
            //ItemCheck.transform.GetComponentInChildren<Image>().sprite = toppingPicture[toppingList[i]];

            //オブジェクトのテキスト変更
            ItemCheck.transform.GetComponentInChildren<Text>().text = (no + 1).ToString()+". " + "Topping名"+" ×5";

            //オブジェクトのテキスト変更
            ItemCheck.transform.GetComponentInChildren<Toggle>().isOn = false;

            //ボタンのクリックイベント登録
            //btn.transform.GetComponent<Button>().onClick.AddListener(() => OnClick(no));

        }
        //for (int i = 0; i < 10; i++)
        //{
        //    // Itemを生成  
        //    var item = GameObject.Instantiate(prefab) as RectTransform;
        //    // Contentの子として登録 
        //    item.SetParent(transform, false);

        //    var text = item.GetComponentInChildren<Text>();
        //    text.text = "item:" + i.ToString();
        //}


        //*** csv読み込みテスト ***
        musicName = "sample"; // 曲名
        level = "0"; // 難易度
        csvFile = Resources.Load("CSV/" + musicName + level) as TextAsset; /* Resouces/CSV下のCSV読み込み */
        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(',')); // リストに入れる
            height++; // 行数加算
        }
        Debug.Log("csv:"+csvDatas[0][0]);

        //********** 保存機能検証 **********//
        //保存キーで入力文字を保存
        PlayerPrefs.SetInt("KeyTestInt", 1);
        PlayerPrefs.Save();

        Debug.Log("IntSave:"+PlayerPrefs.GetInt("KeyTest"));

        ////てきとうにリストとディクショナリー作成
        //List<string> saveList = new List<string>() { "key1-1Key2-1", "key1-2key2-2", "key1-3key2-3" };
        //Dictionary<string, string> saveDict = new Dictionary<string, string>(){
        //    {"key1", "1"}, {"key2", "2"}, {"key3", "3"}
        //};

        //保存
        //PlayerPrefsUtility.SaveList<string>("ListSaveKey", saveList);
        //PlayerPrefsUtility.SaveDict<string, string>("DictSaveKey", saveDict);

        //読み込み
        //List<string> loadList = PlayerPrefsUtility.LoadList<string>("ListSaveKey");
        //Dictionary<string, string> loadDict = PlayerPrefsUtility.LoadDict<string, string>("DictSaveKey");
        //for (int i = 0; i < loadList.Count; i++)
        //{
        //    Debug.Log("ListSave:"+loadList[i]);
        //}

        //var list = new List<KeyValuePair<string, string>>(loadDict);
        // ループ変数にKeyValuePairを使う
        //foreach (KeyValuePair<string, string> kvp in loadDict)
        //{
        //    string id = kvp.Key;
        //    string name = kvp.Value;
        //    Debug.Log(id+":"+name);
        //}

        //var kList = new List<string>(loadDict.Keys);
        //var vList = new List<string>(loadDict.Values);

        //for (int i = 0; i < kList.Count; i++)
        //{
        //    Debug.Log("DictionaryKey:" + kList[i]);
        //    Debug.Log("DictionaryKey2:" + vList[i]);
        //}
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnClick(int no)
    {

        Debug.Log(no);

    }


    //実行ボタン押下
    public void PushButtonExe()
    {
        messageObj.SetActive(true);
    }

    //作成-はい押下
    public void PushButtonYes()
    {

        //ラーメンの絵を更新。可変にする
        ramenList.GetComponent<Image>().sprite = ramenPicture[RAMEN_MIRA];

        //statusを更新 CSVより取得するようにする

        ramenNm.GetComponent<Text>().text = "ミラたんラーメン";
        statusReaVal.GetComponent<Text>().text = "100";


        messageText.GetComponent<Text>().text = "できました！！";

        buttonYes.SetActive(false);
        buttonNo.SetActive(false);
        buttonOk.SetActive(true);
    }

    //作成-いいえ押下
    public void PushButtonNo()
    {
        messageObj.SetActive(false);
    }

    //作成後-OK押下
    public void PushButtonOk()
    {
        messageObj.SetActive(false);
    }

    //戻るボタン押下
    public void PushButtonEnd()
    {
        SceneManager.LoadScene("MenuScene");
    }

    //テスト
    public void OnValueChanged(int value)
    {
        Debug.Log("value = " + value);  //値を取得（先頭から連番(0～n-1)）
        Debug.Log("text(options) = " + dropdownCup.options[value].text);  //リストからテキストを取得
        Debug.Log("text(captionText) = " + dropdownCup.captionText.text); //Labelからテキストを取得
    }
}
