using UnityEngine;
using System.Collections;

public class BGMManager : MonoBehaviour {

	/// BGM indexes:
	/// 0: Title screen
	/// 1: Start game
	/// 2: End game

	public float fadeRate = 0.8f;
	public float[] maxVolume;

	private AudioSource[] bgm;

	private int previousBGM = 0;
	private int currentBGM = 0;

	private bool coroutineIsRunning = false;

	void Start () {
		GameEventManager.GameStart += PlaySecondOne;
		GameEventManager.TitleScreen += PlayFirstOne;
		GameEventManager.GameOver += PlayFirstOne;
		GameEventManager.GameWin += PlayFirstOne;

		bgm = GetComponents<AudioSource> ();
		for (int i = 0; i < bgm.Length; i++) {
			bgm [i].spatialBlend = 1f;
		}

		// Play title screen music first
		if (0 < bgm.Length) {
			bgm [0].Play ();
			bgm [0].loop = true;
		}
	}

	void Update () {
		if (previousBGM != currentBGM) {
			if (!coroutineIsRunning) {
				StartCoroutine(CrossFade (currentBGM, previousBGM));
				previousBGM = currentBGM;
			}
		} else {
			coroutineIsRunning = false;
		}
	}

	IEnumerator CrossFade (int bgmFadeInIndex, int bgmFadeOutIndex) {
		coroutineIsRunning = true;

		bgm [bgmFadeInIndex].volume = 0f;
		bgm [bgmFadeInIndex].Play ();
		bgm [bgmFadeInIndex].loop = true;

		while (bgm [bgmFadeInIndex].volume < maxVolume[bgmFadeInIndex] && bgm [bgmFadeOutIndex].volume > 0.05) {
			bgm [bgmFadeInIndex].volume = Mathf.Lerp (bgm[bgmFadeInIndex].volume, maxVolume[bgmFadeInIndex], fadeRate * Time.deltaTime);
			bgm [bgmFadeOutIndex].volume = Mathf.Lerp (bgm[bgmFadeOutIndex].volume, 0f, fadeRate * Time.deltaTime);
			yield return null;
		}

		bgm [bgmFadeInIndex].volume = maxVolume[bgmFadeInIndex];
		bgm [bgmFadeOutIndex].volume = 0f;
		bgm [bgmFadeOutIndex].Stop ();

	}

	private void PlayFirstOne(){
		currentBGM = 0;
	}

	private void PlaySecondOne(){
		currentBGM = 1;
	}
}
