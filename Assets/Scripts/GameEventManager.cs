public static class GameEventManager {

	public delegate void GameEvent();

	public static event GameEvent GameStart;
	public static event GameEvent GameOver;
	public static event GameEvent TitleScreen;

	public static void TriggerGameStart() {
		if (GameStart != null) {
			GameStart ();
		}
	}

	public static void TriggerGameOver() {
		if (GameOver != null) {
			GameOver ();
		}
	}

	public static void TriggerTitleScreen() {
		if (TitleScreen != null) {
			TitleScreen ();
		}
	}
}
