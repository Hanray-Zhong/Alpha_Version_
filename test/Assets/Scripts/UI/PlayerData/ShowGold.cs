using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowGold : MonoBehaviour {
	public GameObject player;

    private Text Gold_text;
    private Unit player_unit;

    private void Start()
    {
        Gold_text = gameObject.GetComponent<Text>();
        player_unit = player.GetComponent<Unit>();
    }

    private void Update()
    {
        if (player_unit != null)
        {
            Gold_text.text = player_unit.gold.ToString();
        }
    }
}
