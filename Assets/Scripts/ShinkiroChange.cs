using UnityEngine;
using System;
using System.Collections;

public class ShinkiroChange : MonoBehaviour
{

    GameObject ButtonExe; //ButtonExeそのものが入る変数

    SinkiroManager script; //SinkiroManager Scriptが入る変数

    void Start()
    {
        ButtonExe = GameObject.Find("ButtonExe"); //ButtonExeをオブジェクトの名前から取得して変数に格納する
        //最初は見えない
        mat.SetColor("_Color", new Color(1, 1, 1, 0));

    }



    [SerializeField]
    Material mat;

    float Sin = 1f;
    float Alha = 0f;

    void Update()
    {


        script = ButtonExe.GetComponent<SinkiroManager>();
        Boolean pushflg = script.bpushFlg;

        if (pushflg == true)
        {
           
            if (Sin > 0.1f)
            {
                mat.EnableKeyword("_SinWave");
                mat.SetFloat("_SinWave", Sin) ;
                Sin = Sin - 0.005f;
                

            }


            if (Alha < 1f)
            {
                mat.EnableKeyword("_Color");
                mat.SetColor("_Color", new Color(1, 1, 1, Alha)); 
                Alha = Alha + 0.005f;
                

            }

            if (pushflg == true　&& Sin < 0.1f && Alha > 1f)
            {
                
                Debug.Log("終わり");
                script.bpushFlg = false;
                Sin = 1f;
                Alha = 0f;
            }

        }



    }






}