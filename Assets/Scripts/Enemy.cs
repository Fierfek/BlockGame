using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private float speed;
	private Vector3 direction;	
	private GameState state;
	private float death = 1;

	void Start () {
		reset();
	}

	public void reset() {
		GameObject stats = GameObject.Find("Stats");
		state = stats.GetComponent<GameState>();
		state.AddEnemy(gameObject);
		direction = new Vector3(0,0,0);
		death = 1;
		switch(name) {
		case "up": direction.y = 1; break;
		case "down": direction.y = -1; break;
		case "left": direction.x = -1; break;
		case "right": direction.x = 1; break;
		}

		speed = state.Enemy_Speed;
	}
	
	// Update is called once per frame
	void Update () {
		death -= Time.deltaTime;
		transform.Translate(direction * Time.deltaTime * speed);
		if (!renderer.isVisible && death <= 0) {
			state.RemoveEnemy(gameObject);
			Die();
		}
	}

	public void Die() {
		name = "Enemy";
		state.EnemyDeath();
		ObjectPool.instance.PoolObject(gameObject);
	}

	public void reduceSize() {

	}

	public void increaseSpeed() {

	}
}