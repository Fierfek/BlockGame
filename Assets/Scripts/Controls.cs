using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controls : MonoBehaviour {
	private float size, speed;
	private Vector3 bottomLeft, topRight;
	private float newX, newY;
	GameState state;
	public GameObject UpgradePanel;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		GameObject stats = GameObject.Find("Stats");
		state = stats.GetComponent<GameState>();
		speed = state.Player_Speed;
		speed = state.Player_Size;

		bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
		topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
		transform.localScale.Set(size, size, 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed, Input.GetAxisRaw ("Vertical") * Time.deltaTime * speed, 0);
		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, bottomLeft.x, topRight.x), Mathf.Clamp(transform.position.y, bottomLeft.y, topRight.y), 0);

		if (Input.GetKeyDown(KeyCode.Space)) {
			if(Time.timeScale == 1) {
				Time.timeScale = 0;
				UpgradePanel.SetActive(true);
			}else if(Time.timeScale == 0) {
				Time.timeScale = 1;
				UpgradePanel.SetActive(false);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Time.timeScale = 0;
		UpgradePanel.SetActive(true);
		state.ResetGame();
	}

	public void UpdateSize() {
		transform.localScale = new Vector3 (2.5f, 2.5f, 1f);
	}
}
