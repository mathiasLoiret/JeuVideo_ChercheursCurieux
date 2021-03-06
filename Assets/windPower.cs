﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windPower : MonoBehaviour {

    private Transform tr;
    private CircleCollider2D cc;
    private float windPowerTimer;

    public Sprite[] envole1_sprite;

    private Transform target_tr;
    private SpriteRenderer target_sr;

    public Transform player;

    public float powerDuration;
    public float power;

	// Use this for initialization
	void Start ()
    {
        tr = GetComponent<Transform>();
        cc = GetComponent<CircleCollider2D>();
        cc.enabled = false;
        target_sr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (windPowerTimer < 0)
        {
            cc.enabled = false;
            tr.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            windPowerTimer--;
            if (windPowerTimer > powerDuration / 2)
                target_sr.sprite = envole1_sprite[0];
            else
                target_sr.sprite = envole1_sprite[1];

            tr.GetComponent<Renderer>().enabled = true;
        }
            
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Collider2D other = collision.collider;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        //Debug.Log("windPower-OnCollisionEnter2D-" + other.tag);
        if (other.tag == "enemy")
        {
            other.GetComponent<Rigidbody2D>().velocity =
                new Vector2(1/(other.transform.position.x - this.transform.position.x) *5 * power,
                            (other.transform.position.y - this.transform.position.y) * power);
        }

    }

    internal void go()
    {
        cc.enabled = true;
        windPowerTimer = powerDuration;
        target_sr.transform.position = player.position + new Vector3(0,1,0);
    }
}
