using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoerManager {
    int scoer;
    Dictionary <E_Evaluation,int> evaluationCountDic;
    Dictionary <E_Evaluation,int> scoerDic;

    public ScoerManager(){
        evaluationCountDic = new Dictionary<E_Evaluation, int>();
        evaluationCountDic.Add(E_Evaluation.GREAT,0);
        evaluationCountDic.Add(E_Evaluation.GOOD,0);
        evaluationCountDic.Add(E_Evaluation.NICE,0);
        evaluationCountDic.Add(E_Evaluation.BAD,0);
    }

    public void InitObject(){
        scoer = 0;
        scoerDic = ScoerDataManager.GetDic;
    }

    public void UpdateScoer(Answer answer){
        scoer += scoerDic[answer.Evaluation];
        evaluationCountDic[answer.Evaluation] += 1;
    }

    public void DisplayScoer(){
        Debug.Log("Scoer : " + scoer);
        Debug.Log("GREAT : " + evaluationCountDic[E_Evaluation.GREAT]);
        Debug.Log("GOOD : " + evaluationCountDic[E_Evaluation.GOOD]);
        Debug.Log("NICE : " + evaluationCountDic[E_Evaluation.NICE]);
        Debug.Log("BAD : " + evaluationCountDic[E_Evaluation.BAD]);
    }
}
