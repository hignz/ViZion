﻿using UnityEngine;

public class BulletTrail : MonoBehaviour {

    public int speed = 200;
    
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        Destroy(gameObject, 1);
	}
}
