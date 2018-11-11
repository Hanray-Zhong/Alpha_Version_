using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHealth : MonoBehaviour {
    public GameObject player;

    private Slider Health = null;
    private Unit player_unit = null;
    private Text health_text = null;

    private void Start()
    {
        Health = gameObject.GetComponent<Slider>();
        health_text = gameObject.GetComponent<Text>();
        player_unit = player.GetComponent<Unit>();
    }

    private void Update()
    {
        if (player_unit != null && Health != null)
        {
            Health.value = player_unit.health / 100;
        }
        if (health_text != null && player_unit != null)
        {
            health_text.text = player_unit.health.ToString() + "/100";
        }
    }
}
