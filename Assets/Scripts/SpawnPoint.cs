using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {
	public GameObject spawnEnemy;
	private GameObject spawnedObject;
	private Vector2 sPosition; // Spawn position
	private int enemiesToSpawn = 0;
	
	void Start () {
		renderer.enabled = false;
		sPosition = new Vector2(transform.position.x, transform.position.y);
	}
	//call once per frame
	void Update() {
		if (enemiesToSpawn > 0) {
			SpawnEnemy();
		}

	}
	//For initial spawn
	void SpawnEnemy() {
		spawnedObject = ObjectPool.instance.GetObjectForType (spawnEnemy.name, true);
		spawnedObject.transform.position = transform.position;
		enemiesToSpawn --;

		switch (name) {
		case "DownSpawn": spawnedObject.name = "down"; break;
		case "UpSpawn": spawnedObject.name = "up"; break;
		case "LeftSpawn": spawnedObject.name = "left"; break;
		case "RightSpawn": spawnedObject.name = "right"; break;
		}

		spawnedObject.GetComponent<Enemy> ().reset ();
	}

	public void SpawnNew() {
		enemiesToSpawn ++;
	}
}