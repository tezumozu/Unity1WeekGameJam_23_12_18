using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandQuestionSet : QuestionSet{
    public RandQuestionSet(){

        int maxCount_first = Enum.GetNames(typeof(E_FirstQuestion)).Length;
        int maxCount_latter = Enum.GetNames(typeof(E_LatterQuestion)).Length;

        //ランダムな整数を取得
        int firstNum = UnityEngine.Random.Range(0, maxCount_first);
        int LatterNum = UnityEngine.Random.Range(0, maxCount_latter);

        //int型からenum型へ変換
        var firstType = (E_FirstQuestion)Enum.ToObject(typeof(E_FirstQuestion), firstNum);
        var latterType = (E_LatterQuestion)Enum.ToObject(typeof(E_LatterQuestion), LatterNum);

        //enumからstringに変化
        string firstName = firstType.ToString();
        string latterName = latterType.ToString();;

        Questions[E_QuestionState.FIRST] = Resources.Load<Question> ("Questions/FirstQuestion/" + firstName);
        Questions[E_QuestionState.FIRST] = Resources.Load<Question> ("Questions/LatterQuestion/" + latterName);
    }
}
