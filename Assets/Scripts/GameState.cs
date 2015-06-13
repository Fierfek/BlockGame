using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameState : MonoBehaviour {
	public int Game_Score = 0;
	public int Game_Money = 0;
	public float Enemy_Speed = 5;
	public float Player_Speed = 5;
	public float Player_Size = 5;
	public GameObject player;
	private int highScore = 0;

	public Text moneyPanel;
	public Text scorePanel;
	public Text wavePanel;
	public Text enemyPanel;

	public GameObject[] spawns;
	public int currentWave = 1;
	private int lastSpawn = 1, lastLastSpawn = 1;
	private int numEnemies = 1;
	public float spawnRate = 2;
	public float spawnTime = 1;
	private int range;

	public Button Upgrade_Size;
	public Button Upgrade_Time;
	public Button Upgrade_Double;
	public Button Upgrade_SpawnRate;


	private ArrayList currentEnemies = new ArrayList();

	void Start() {

	}

	public void UpdateMoney() {
		moneyPanel.text = "Money: " + Game_Money.ToString();
	}

	public void UpdateScore() {
		scorePanel.text = "Score: " + Game_Score.ToString();
	}

	public void UpdateWave() {
		wavePanel.text = "Wave: " + currentWave.ToString();
	}

	public void UpdateEnemies() {
		enemyPanel.text = "Enemies: " + numEnemies.ToString();
	}

	void Update() {
		spawnTime -= Time.deltaTime;
		if (numEnemies > 0) {
			if(spawnTime <= 0) {
				spawnTime = spawnRate;
				SpawnEnemy();
				UpdateEnemies();
			}
		} else {
			currentWave ++;
			UpdateWave();
			numEnemies = lastSpawn + lastLastSpawn;
			lastLastSpawn = lastSpawn;
			lastSpawn = numEnemies;
			UpdateEnemies();
		}
	}

	private void SpawnEnemy() {
		range = Random.Range (0, 35);
		spawns[range].GetComponent<SpawnPoint>().SpawnNew();
	}

	public void EnemyDeath() {
		Game_Score ++;
		Game_Money ++;
		numEnemies --;
		UpdateMoney();
		UpdateScore();
		UpdateEnemies();
	}

	public void ResetGame() {
		if (highScore < Game_Score)
			highScore = Game_Score;

		foreach(GameObject enemy in currentEnemies) {
			enemy.GetComponent<Enemy>().Die();
		}

		currentEnemies.Clear();


		Game_Score = 0;
		Game_Money = 0;
		Enemy_Speed = 5;
		Player_Speed = 5;
		Player_Size = 5;

		currentWave = 1;
		lastSpawn = 1; lastLastSpawn = 1;
		numEnemies = 1;
		spawnRate = 2;
		spawnTime = 1;

		UpdateMoney();
		UpdateScore();
		UpdateEnemies();
		UpdateWave();

		player.gameObject.transform.position = new Vector3(0,0,0);
	}

	public void AddEnemy(GameObject enemy) {
		currentEnemies.Add (enemy);
	}

	public void RemoveEnemy(GameObject enemy) {
		currentEnemies.Remove (enemy);
	}

	public void BuyUpgrade(string name) {
		switch (name) {
		case "Size": 
			if (Game_Money >= 25) {
				Game_Money -= 25;
				UpdateMoney();
				GameObject player = GameObject.Find("Player");
				Controls controls = player.GetComponent<Controls>();
				controls.UpdateSize();
			}
			break;
		}
	}
}