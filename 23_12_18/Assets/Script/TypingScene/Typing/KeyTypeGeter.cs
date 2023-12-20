using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;



//キーボードの入力を取得し、I_TypeCheckableに渡す
public class KeyTypeGeter {
    private Dictionary <KeyCode,Char> keyMap; 

    private I_SpelCheckable questioner;


    public KeyTypeGeter (I_SpelCheckable questioner){
        this.questioner = questioner;
    }


    public void InitObject(){
        keyMap = new Dictionary<KeyCode, Char>();
        var keyList = Enum.GetValues(typeof(KeyCode));

        //一度初期化
        foreach (KeyCode value in keyList){
            // 絶対に答えに含まれない文字を入れる
            keyMap[value] = '/';
        }

        //アルファベットのキーに各文字を対応付ける
        keyMap[KeyCode.A] = 'a';
        keyMap[KeyCode.B] = 'b';
        keyMap[KeyCode.C] = 'c';
        keyMap[KeyCode.D] = 'd';
        keyMap[KeyCode.E] = 'e';
        keyMap[KeyCode.F] = 'f';
        keyMap[KeyCode.G] = 'g';
        keyMap[KeyCode.H] = 'h';
        keyMap[KeyCode.I] = 'i';
        keyMap[KeyCode.J] = 'j';
        keyMap[KeyCode.K] = 'k';
        keyMap[KeyCode.L] = 'l';
        keyMap[KeyCode.M] = 'm';
        keyMap[KeyCode.N] = 'n';
        keyMap[KeyCode.O] = 'o';
        keyMap[KeyCode.P] = 'p';
        keyMap[KeyCode.Q] = 'q';
        keyMap[KeyCode.R] = 'r';
        keyMap[KeyCode.S] = 's';
        keyMap[KeyCode.T] = 't';
        keyMap[KeyCode.U] = 'u';
        keyMap[KeyCode.V] = 'v';
        keyMap[KeyCode.W] = 'w';
        keyMap[KeyCode.X] = 'x';
        keyMap[KeyCode.Y] = 'y';
        keyMap[KeyCode.Z] = 'z';
        keyMap[KeyCode.Minus] = '-';
    }

    public void UpdateObject(){
        if (Input.anyKeyDown){
            foreach(KeyCode code in Enum.GetValues(typeof(KeyCode))) { // 検索
                checkInput(code);
            }
        }
    }

    private void checkInput(KeyCode code){
        // 入力されたキーの名前と一致した場合
        if (Input.GetKeyDown(code)) {
            Debug.Log(code);
            //入力を通知
            questioner.checkSpel(keyMap[code]);
        }
    }
}
