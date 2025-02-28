﻿/* ***************************************************************
 * 프로그램 명 : LivingConver.cs
 * 작성자 : 이송이 (류서현, 신은지, 최세화, 최은정, 홍예지)
 * 최조 작성일 : 2019년 12월 04일
 * 최종 작성일 : 2019년 12월 06일
 * 프로그램 설명 : 파일 입출력으로 Livingroom Scene에 맞는 대화를 불러온 뒤
 *                      게임 화면에 대화 형식으로 보여준다.
 * *************************************************************** */

using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LivingConver : MonoBehaviour
{
    // 게임 오브젝트를 불러온다.
    public GameObject ConversationBox;
    public GameObject ConversationMark;
    public GameObject ConversationText;
    public GameObject CharacterText;
    public Text ConverText;
    public Text CharText;

    Container situ;
    // initialize text file's path
    private string sceneData;

    private bool isPrint = false;
    private TextAsset data;
    private StringReader reader;
    private string buff = "";

    private void Awake()
    {
        // 어느 상황인지 고양이에 저장된 컴포넌트에서 SceneData불러오기.
        situ = GameObject.Find("Situation").GetComponent<Container>();
        sceneData = situ.situation;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    public void start_livingcon(string selectCharac)
    {
        // 선택에 따른 파일 오픈
        data = Resources.Load(selectCharac, typeof(TextAsset)) as TextAsset;
        reader = new StringReader(data.text);
        // buff에 한 줄 받아오기
        buff = reader.ReadLine();
        Debug.Log(buff); // 현재 상황을 Console에 표시
        
        // 2초마다 DoConversation함수 호출
        InvokeRepeating("DoConversation", 0, 2);
    }

    void DoConversation()
    {
        buff = reader.ReadLine();
        string[] values;

        if (buff != null)
        {
            values = buff.Split(',');
            if(values.Length == 0)
            {
                reader.Close();
                isPrint = true;
                return;
            }
            // 대화창을 활성화한다.
            ConversationBox.SetActive(true);
            ConversationMark.SetActive(true);
            // 화자를 표시한다.
            CharText.text = values[0];
            CharacterText.SetActive(true);
            // 대화를 표시한다.
            ConverText.text = values[1];
            ConversationText.SetActive(true);
        }
        else // 파일이 끝나면
        {
            ConversationSkip();
        }
    }

    void ConversationSkip() // skip동작시 호출
    {
        // 대화에 필요한 모든 컴포넌트들을 비활성화 한다.
        CancelInvoke("DoConversation");
        ConversationBox.SetActive(false);
        ConversationMark.SetActive(false);
        ConversationText.SetActive(false);
        CharacterText.SetActive(false);
    }
}
