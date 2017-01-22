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
	private List<string> titleScreenComments;

	private List<string> commentsToShow;

	void Awake() {
		GameEventManager.TitleScreen += ActivateComments;
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += DeactivateComments;
	}

	void Start () {
		tm = GetComponent<TextMesh> ();
		titleScreenComments = new List<string> ();
		titleScreenComments.Add ("No\nI'm not");
		titleScreenComments.Add ("Hold my beer.");
		commentsToShow = titleScreenComments;
	}

	void Update () {
		if (activateComments) {
			if (showCommentTimer > showCommentEveryXSeconds) {
				tm.text = commentsToShow [Random.Range (0, commentsToShow.Count)];
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
		commentsToShow = titleScreenComments;
		showCommentTimer = 0f;
		commentStayTimer = 0f;
	}

	private void DeactivateComments() {
		activateComments = false;
	}

	private void GameStart() {
		commentsToShow = comments;
	}
}
