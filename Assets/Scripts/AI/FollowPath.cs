﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public bool doMove = true;
    public float moveSpeed = 5f;
    public float distanceToNodeTolerance = 0.2f;

    public GameObject Path;
    private CustomPath pathToFollow;
    public Vector2 target;
    Rigidbody2D body;
    public bool useTriggers = true;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        pathToFollow = Path.GetComponent<CustomPath>();

        target = pathToFollow.GetFirstNode();
    }

    void Update()
    {
        if (doMove)
        {
            body.MovePosition(Vector2.MoveTowards(
                transform.position, target, moveSpeed * Time.deltaTime));

            FaceDirection();

            if (!useTriggers)
            {
                if (Vector2.Distance(transform.position, target) <= distanceToNodeTolerance)
                {
                    target = pathToFollow.GetNextNodePosition();
                }
            }
        }
    }

    void FaceDirection()
    {
        Vector2 moveDirection = body.velocity;

        if (moveDirection != Vector2.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection, Vector3.forward);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;

        if (useTriggers)
        {
            if (tag == "PathNode")
            {
                target = pathToFollow.GetNextNodePosition();
            }
        }
    }
}
