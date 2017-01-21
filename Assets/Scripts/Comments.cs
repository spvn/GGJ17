using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comments : MonoBehaviour {

	public float showCommentEveryXSeconds;
	public float commentStays;
	public List<string> comments;

	private bool activateComments = true;
	private TextMesh tm;
	private bool isShowingComment = false;
	private float showCommentTimer = 0f;
	private float commentStayTimer = 0f;

	void Awake() {
		GameEventManager.TitleScreen += ActivateComments;
		GameEventManager.GameOver += DeactivateComments;
	}

	void Start () {
		tm = GetComponent<TextMesh> ();
	}

	void Update () {
		if (activateComments) {
			if (showCommentTimer > showCommentEveryXSeconds) {
				tm.text = comments [Random.Range (0, comments.Count)];
				isShowingComment = true;
				showCommentTimer = 0f;
				commentStayTimer = 0f;
			}

			if (isShowingComment) {
				commentStayTimer += Time.deltaTime;

				if (commentStayTimer > commentStays) {
					tm.text = "";
					isShowingComment = false;
				}
			} else {
				showCommentTimer += Time.deltaTime;
			}
		}
	}

	private void ActivateComments() {
		activateComments = true;

		isShowingComment = false;
		showCommentTimer = 0f;
		commentStayTimer = 0f;
	}

	private void DeactivateComments() {
		activateComments = false;
	}
}
