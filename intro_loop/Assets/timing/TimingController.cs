using UnityEngine;
using System.Collections;

public class TimingController : MonoBehaviour {
	public AudioClip click;
	public float delay = 0.1f;
	public float interval = 0.25f;
	
	AudioSource[] audioSource = new AudioSource[2];

	int playerIndex = 0;
	double lastSetupTime;
	double nextScheduledTime;

	// Use this for initialization
	void Start () {
		audioSource[0] = this.gameObject.AddComponent<AudioSource>();
		audioSource[1] = this.gameObject.AddComponent<AudioSource>();
		
		if(click != null){
			audioSource[playerIndex%2].playOnAwake = false;
			audioSource[playerIndex%2].clip = click;
			audioSource[playerIndex%2].PlayScheduled(AudioSettings.dspTime + delay);
			playerIndex++;
			if(click != null){

				audioSource[playerIndex%2].playOnAwake = false;
				audioSource[playerIndex%2].clip = click;
				audioSource[playerIndex%2].PlayScheduled(AudioSettings.dspTime + delay + interval);
				playerIndex++;
				lastSetupTime = AudioSettings.dspTime;
				nextScheduledTime = AudioSettings.dspTime + delay + interval + interval;
			}
		}
	}
	void Update()
	{
		if(click != null && AudioSettings.dspTime > nextScheduledTime-(interval/2)){
			audioSource[playerIndex%2].playOnAwake = false;
			//audioSource[playerIndex%2].clip = click;
			audioSource[playerIndex%2].PlayScheduled(nextScheduledTime);
			double tmpTime = nextScheduledTime;
			playerIndex++;
			lastSetupTime = AudioSettings.dspTime;
			nextScheduledTime = AudioSettings.dspTime + interval + interval;
			Debug.Log(string.Format("[count] {0} dspTime : {1,4:F3} [delay] {2,4:F3} [next] {3,4:F3} [deltaTime] {4,4:F4} [difference] {5,4:f4} [interval] {6,4:f4} ", 
			                        playerIndex,	AudioSettings.dspTime , delay , nextScheduledTime ,Time.deltaTime,AudioSettings.dspTime - tmpTime,interval));
		}
	}
}
