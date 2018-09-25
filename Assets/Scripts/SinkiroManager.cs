using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SinkiroManager : MonoBehaviour {

    //private GameObject btnPref;  //ボタンプレハブ
    //private GameObject content;
    //private RectTransform content;
    //private GameObject textPrefab;
    //private Button getSkillButton;
    //private List<string> skillList = new List<string>();
    public Dropdown dropdownDace;    //うつわドロップダウン
    public Boolean bpushFlg;
    //void Awake()
    //{
    //    skillList.Add("不思議な踊り");
    //    skillList.Add("スーパースター");
    //skillList.Add("鑑定");
    //skillList.Add("園芸");
    //skillList.Add("裁縫");
    //skillList.Add("調合");
    //skillList.Add("整頓");
    //skillList.Add("彫金");
    //skillList.Add("木工");
    //skillList.Add("鍛治");
    //skillList.Add("採掘");
    //skillList.Add("精製");
    //skillList.Add("水泳");
    //skillList.Add("錬金");
    //skillList.Add("合成");
    //skillList.Add("分解");
    //skillList.Add("演奏");
    //skillList.Add("作曲");
    //skillList.Add("歌唱");
    //skillList.Add("休憩");
    //Debug.Log(skillList.Count);
    //Content取得(ボタンを並べる場所)
    //content = GameObject.Find("Canvas/ImageBack/Scroll View/Viewport/Content").GetComponent<RectTransform>();

    //textPrefab = (GameObject)Resources.Load("Prefabs/ButtonDance");
    //(ボタンの高さ+ボタン同士の間隔)*ボタン数

    //float btnSpace = content.GetComponent<VerticalLayoutGroup>().spacing;

    //float btnHeight = textPrefab.GetComponent<LayoutElement>().preferredHeight;

    //content.sizeDelta = new Vector2(0, (btnHeight + btnSpace) * 3);


    //content = GameObject.Find("Content");
    //textPrefab = (GameObject)Resources.Load("Prefabs/Text");
    //getSkillButton = transform.GetComponent<Button>();
    //}

    // Use this for initialization
    void Start () {
        bpushFlg = false;
        //うつわ設定
        if (dropdownDace)
        {
            dropdownDace.ClearOptions();    //現在の要素をクリアする
            List<string> listDance = new List<string>();
            listDance.Add("不思議な踊り");
            listDance.Add("スーパースター");
            dropdownDace.AddOptions(listDance);  //新しく要素のリストを設定する
            dropdownDace.value = 0;         //デフォルトを設定(0～n-1)
        }

        //int max = Random.Range(1, skillList.Count - 5);
        //int max = skillList.Count;
        //Debug.Log(max);
        //		for(int i = 0; i < Random.Range(1,(skillList.Count - 5)); i++){
        //for (int i = 0; i < max; i++)
        //{
        //    Debug.Log(i);
        //    GameObject _text = Instantiate(textPrefab, content.transform);
        //    int index = Random.Range(0, skillList.Count);
        //    Debug.Log(index);
        //    _text.GetComponent<Button>().text = skillList[index];
        //    skillList.RemoveAt(index);
        //}


        //for (int i = 0; i < skillList.Count; i++)
        //{
        //    //ボタン生成
        //    GameObject btn = (GameObject)Instantiate(textPrefab);

        //    //ボタンをContentの子に設定
        //    btn.transform.SetParent(content, false);

        //    //ボタンのテキスト変更
        //    btn.transform.GetComponentInChildren<Text>().text = skillList[i];

        //    //ボタンのクリックイベント登録
        //    btn.transform.GetComponent<Button>().onClick.AddListener(() => OnClick(i));
        //}

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick(int no)
    {

        Debug.Log(no);

    }

    public void OnValueChanged(int value)
    {
        //Debug.Log("value = " + value);  //値を取得（先頭から連番(0～n-1)）
        //Debug.Log("text(options) = " + dropdownDace.options[value].text);  //リストからテキストを取得
        //Debug.Log("text(captionText) = " + dropdownDace.captionText.text); //Labelからテキストを取得
    }

    public void PushButtonExe()
    {
        bpushFlg = true ;
        Debug.Log(bpushFlg);
        //Debug.Log("value = " + dropdownDace.value);  //値を取得（先頭から連番(0～n-1)）
        //Debug.Log("text(options) = " + dropdownDace.options[dropdownDace.value].text);  //リストからテキストを取得
        //Debug.Log("text(captionText) = " + dropdownDace.captionText.text); //Labelからテキストを取得

        //if (skillList.Count > 0)
        //{
        //    GameObject _text = Instantiate(textPrefab, content.transform);
        //    int index = Random.Range(0, skillList.Count);
        //    _text.GetComponent<Text>().text = skillList[index];
        //    skillList.RemoveAt(index);
        //    Debug.Log(skillList.Count);
        //}
        //else
        //{
        //    getSkillButton.interactable = false;
        //    getSkillButton.GetComponentInChildren<Text>().text = "GetAllSkill!";
        //    Debug.Log("GetALLSkill!");
        //}
    }
}
