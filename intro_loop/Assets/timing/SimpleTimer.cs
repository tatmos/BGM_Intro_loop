using UnityEngine;
using System.Collections;

public class SimpleTimer : MonoBehaviour {
	public AudioClip clip;	//	再生する音
	AudioSource audioSource = new AudioSource();    //    2個用意
	int playerIndex = 0;		//	再生インデックス
	public float delay = 0.1f;    //    初回遅延量
	public float interval = 0.25f;    //    再生間隔
	public float bpm = 120;
	double nextScheduledTime;    //    次にスケジュールした時刻
	public ParticleSystem ps;
	
	void Start () {
		audioSource = this.gameObject.AddComponent<AudioSource>();
		audioSource.playOnAwake = false;
		audioSource.clip = clip;    
		nextScheduledTime = AudioSettings.dspTime + delay + interval;

	}
	int pitch = 0;
	void Update()
	{
		interval = 60/bpm;	//	bpm
		//    dspTimeが一定量進んだら
		if(AudioSettings.dspTime > nextScheduledTime){    
			//    次の再生をスケジュール
			audioSource.pitch = Mathf.Pow(2,(pitch%12)/12.0f);
			audioSource.PlayScheduled(nextScheduledTime);
			nextScheduledTime = AudioSettings.dspTime + interval;
			if( interval < Time.deltaTime){
				Debug.LogError("NG!! ");	//	精度が保てない
			}
			
			pitch++;
			ps.Play();
		}
	}
}