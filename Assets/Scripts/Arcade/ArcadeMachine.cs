﻿using UnityEngine;

public class ArcadeMachine : MonoBehaviour {

    private Sprite turnedOff;
    public Sprite turnedOn;

    SpriteRenderer spr;

    public bool isOn = false;

	void Start () {
        spr = GetComponent<SpriteRenderer>();
        turnedOff = spr.sprite;
	}

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isOn = !isOn;

                if (isOn)
                {
                    spr.sprite = turnedOn;
                }
                else
                {
                    spr.sprite = turnedOff;
                } 
            }
        }
    }
}
