using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowSpriteEffect : MonoBehaviour {

    public float Speed = 1f;
    private SpriteRenderer sRend;

    void Start()
    {
        sRend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        sRend.material.SetColor("_Color", HSBColor.ToColor(new HSBColor(Mathf.PingPong(Time.time * Speed, 1), 1, 1)));
    }

}
