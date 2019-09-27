using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{	[SerializeField] private float healthBarWidth;
	private float healthBarWidthSmooth;
	[SerializeField] private float healthBarWidthEase;
        public GameObject healthBar;
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
    }
}
