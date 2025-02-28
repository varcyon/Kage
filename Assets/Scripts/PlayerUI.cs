﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{	[SerializeField] private float healthBarWidth;
	private float healthBarWidthSmooth;
	[SerializeField] private float healthBarWidthEase;
    [SerializeField] GameObject healthBar;

   [SerializeField] TextMeshProUGUI purgatoryWater;
    [SerializeField] TextMeshProUGUI hellFire;
    [SerializeField] TextMeshProUGUI heavenMetal;
    void Start()
    {
        healthBarWidth = 1;
		healthBarWidthSmooth = healthBarWidth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBarWidth = (float)Player.Instance.GetComponent<Damageable>().health / (float)Player.Instance.GetComponent<Damageable>().maxHealth;
		healthBarWidthSmooth += (healthBarWidth - healthBarWidthSmooth) * Time.deltaTime * healthBarWidthEase;
		healthBar.transform.localScale = new Vector2 (healthBarWidthSmooth, transform.localScale.y);
        
        purgatoryWater.text = Magic.Instance.PurgatoryWater.ToString();
        hellFire.text = Magic.Instance.HellFire.ToString();
        heavenMetal.text = Magic.Instance. HeavenMetal.ToString();
    }
}
