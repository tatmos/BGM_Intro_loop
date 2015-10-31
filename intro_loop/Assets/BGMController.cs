using UnityEngine;
using System.Collections;

public class BGMController : MonoBehaviour {

	public AudioClip intro;
	public AudioClip loop;

	AudioSource[] audioSource = new AudioSource[2];

	// Use this for initialization
	void Start () {
		audioSource[0] = this.gameObject.AddComponent<AudioSource>();
		audioSource[1] = this.gameObject.AddComponent<AudioSource>();
	
		if(intro != null){
			audioSource[0].playOnAwake = false;
			audioSource[0].clip = intro;
			audioSource[0].Play();
			if(loop != null){
				audioSource[1].playOnAwake = false;
				audioSource[1].clip = loop;
				audioSource[1].loop = true;
				audioSource[1].PlayScheduled(AudioSettings.dspTime + intro.length);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
