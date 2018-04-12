using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Sprite[] deathSprites;
    public GameObject[] bloodSprites;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DoDeath()
    {
        SwapToDeadSprite();

        if (GetComponent<FollowPath>() != null)
        {
            GetComponent<FollowPath>().enabled = false;
        }

        GetComponent<SpriteRenderer>().sortingOrder = 1;
        GetComponent<BoxCollider2D>().enabled = false;

        if (GetComponent<Animator>() != null)
        {
            GetComponent<Animator>().enabled = false;
        }
    }

    public void SwapToDeadSprite()
    {
        var spriteNumber = Random.Range(0, deathSprites.Length - 1);
        GetComponent<SpriteRenderer>().sprite = deathSprites[spriteNumber];

        SpawnBloodSplatter();
    }

    public void SpawnBloodSplatter()
    {
        GameObject bloodPool = Instantiate(bloodSprites[0], transform.position, transform.rotation);
        bloodPool.GetComponent<SpriteRenderer>().material = transform.GetComponent<SpriteRenderer>().material;

        for (int i = 0; i < 4; i++)
        {
            var spriteNumber = Random.Range(1, bloodSprites.Length - 1);
            var randX = Random.Range(transform.position.x - 1f, transform.position.x + 1f);
            var randY = Random.Range(transform.position.y - 1f, transform.position.y + 1f);

            GameObject blood = Instantiate(bloodSprites[spriteNumber], new Vector3(randX, randY, transform.position.z), transform.rotation);
            blood.GetComponent<SpriteRenderer>().material = transform.GetComponent<SpriteRenderer>().material;
        }
    }
}
