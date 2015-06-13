using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	public Text scorePanel;
	private int score;

	void UpdateScore(int mod) {
		score += mod;
		scorePanel.text = score.ToString();
	}
}