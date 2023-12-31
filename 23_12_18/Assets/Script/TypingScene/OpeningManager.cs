using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

public class OpeningManager : MonoBehaviour {
    public Subject<Unit> FinishOpningSubject = new Subject<Unit>();

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

    [SerializeField] 
    private Text ZundaLinesText;

    [SerializeField] 
    private GameObject ZundaLines;

    private void Start(){
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void InitObject(){
        currentTime = 0.0f;
    }

    private IEnumerator DisplayOpening(){
        audioSource.clip = VoioceList[0];
        audioSource.Play();

        while(audioSource.isPlaying || time > currentTime){
            currentTime += Time.deltaTime;
            yield return null;
        }


        audioSource.clip = VoioceList[1];
        audioSource.Play();
        MetanLinesText.text = "ずんだもんの皆さん";

        currentTime = 0;

        while(audioSource.isPlaying || time > currentTime ){
            currentTime += Time.deltaTime;
            yield return null;
        }


        audioSource.clip = VoioceList[2];
        audioSource.Play();
        MetanLinesText.text = "おねがいします";

        currentTime = 0;

        while(audioSource.isPlaying || time > currentTime){
            currentTime += Time.deltaTime;
            yield return null;
        }



        MetanLines.SetActive(false);
        ZundaLines.SetActive(true);

        audioSource.clip = VoioceList[3];
        audioSource.Play();
        ZundaLinesText.text = "はいなのだ！";

        currentTime = 0;
        
        while(audioSource.isPlaying){
            currentTime += Time.deltaTime;
            yield return null;
        }
        ZundaLines.SetActive(false);

        FinishOpningSubject.OnNext(Unit.Default);
    }

    public void StartOpening(){
        currentTime = 0;
        MetanLinesText.text = "おくることば";
        MetanLines.SetActive(true);
        StartCoroutine(DisplayOpening());
    }

}
