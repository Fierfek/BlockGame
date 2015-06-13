using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour {
	
	public Text moneyPanel;
	private int money;
	
	void UpdateMoney(int mod) {
		money += mod;
		moneyPanel.text = "Money: " + money.ToString();
	}
}