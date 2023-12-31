using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

public class EndingManager : MonoBehaviour {
    public Subject<Unit> FinishEndingSubject = new Subject<Unit>();

    //仮のディレイ用
    float currentTime;
    float time = 2.0f;

    private AudioSource audioSource;

    [SerializeField]
    private List<AudioClip> VoioceList;

    [SerializeField] 
    private Text MetanLinesText;

    [SerializeField] 
    private GameObject MetanLines;

    private void Start(){
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void InitObject(){
    }

    private IEnumerator DisplayEnding(){

        audioSource.clip = VoioceList[0];
        audioSource.Play();

        while(audioSource.isPlaying || currentTime < time){
            currentTime += Time.deltaTime;

            yield return null;
        }

        audioSource.clip = VoioceList[1];
        audioSource.Play();

        MetanLinesText.text = "第一回ずんだ小学校";

        currentTime = 0;
        while(audioSource.isPlaying || currentTime < time){
            currentTime += Time.deltaTime;
            yield return null;
        }

        audioSource.clip = VoioceList[2];
        audioSource.Play();

        MetanLinesText.text = "卒業式を終了します";
        
        while(audioSource.isPlaying){
            yield return null;
        }
        MetanLines.SetActive(false);

        FinishEndingSubject.OnNext(Unit.Default);
    }

    public void StartEnding(){
        currentTime = 0;
        MetanLinesText.text = "これにて";
        MetanLines.SetActive(true);
        StartCoroutine(DisplayEnding());
    }
}
