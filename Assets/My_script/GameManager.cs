using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

	public static GameManager gm;
	public GameObject Camera;
	public GameObject ani; 
	//public GameObject player;
	public GameObject player1turnCanvas;
	public GameObject player2turnCanvas;


	public enum gameStates {Playing, Player1Win, GameOver, Player2Win};
	public gameStates gameState = gameStates.Playing;

	public GameObject mainCanvas;
	public Text mainScoreDisplay;
	public GameObject Player1WinCanvas;
	public Text gameOverScoreDisplay;

	[Tooltip("Only need to set if canBeatLevel is set to true.")]
	public GameObject Player2WinCanvas;

	public AudioSource backgroundMusic;
	public AudioClip gameOverSFX;

	[Tooltip("Only need to set if canBeatLevel is set to true.")]
	public AudioClip beatLevelSFX;


	//attache the one has highest character number
	public GameObject player1;
	public GameObject Player2; 
	private float time = 5.0f;
	void Start () {
		if (gm == null)
			gm = gameObject.GetComponent<GameManager> ();




		// setup score display
		//Collect (0);

		// make other UI inactive
		Player1WinCanvas.SetActive (false);
		Player2WinCanvas.SetActive (false);
	}

	void Update () {
		switch (gameState)
		{
			case gameStates.Playing:
			if (player1.GetComponent<Team>().MemberPower == 3)
				{
					// update gameState
				gameState = gameStates.Player1Win;

					// set the end game score
					//gameOverScoreDisplay.text = mainScoreDisplay.text;

					// switch which GUI is showing		
					mainCanvas.SetActive (false);
				Player1WinCanvas.SetActive (true);
				Destroy(Player1WinCanvas, time);
				Destroy (player1turnCanvas);
				Destroy (player2turnCanvas);
				Camera.GetComponent<Animator> ().enabled = true; 

			} else if (Player2.GetComponent<Team>().MemberPower == 3) {
					// update gameState
				gameState = gameStates.Player2Win;

					// hide the player so game doesn't continue playing

					// switch which GUI is showing			
					mainCanvas.SetActive (false);
				Player2WinCanvas.SetActive (true);
				Destroy(Player2WinCanvas, time);
				Destroy (player1turnCanvas);
				Destroy (player2turnCanvas);

				Camera.GetComponent<Animator> ().enabled = true; 

				}
				break;
		case gameStates.Player1Win:
				backgroundMusic.volume -= 0.04f;
				if (backgroundMusic.volume<=0.0f) {
					AudioSource.PlayClipAtPoint (gameOverSFX,gameObject.transform.position);

					gameState = gameStates.GameOver;
				}
				break;
		case gameStates.Player2Win:
				backgroundMusic.volume -= 0.04f;
				if (backgroundMusic.volume<=0.0f) {
					AudioSource.PlayClipAtPoint (beatLevelSFX,gameObject.transform.position);
					
					gameState = gameStates.GameOver;
				}
				break;
			case gameStates.GameOver:
				// nothing
				break;
		}

	}

	/*
	public void Collect(int amount) {
		score += amount;
		if (canBeatLevel) {
			mainScoreDisplay.text = score.ToString () + " of "+beatLevelScore.ToString ();
		} else {
			mainScoreDisplay.text = score.ToString ();
		}

	}
	*/
}
