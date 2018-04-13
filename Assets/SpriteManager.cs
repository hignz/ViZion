using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour {

    public GameObject[] deathSprites;
    public GameObject[] bloodSprites;

    public GameObject GetEnemyDead()
    {
        var spriteNumber = Random.Range(0, deathSprites.Length - 1);
        return deathSprites[spriteNumber];     
    }

    public void SpawnBloodSplatter(Transform player)
    {
        GameObject bloodPool = Instantiate(bloodSprites[0], player.position, player.rotation);
        bloodPool.GetComponent<SpriteRenderer>().material = player.GetComponent<SpriteRenderer>().material;

        for (int i = 0; i < 4; i++)
        {
            var spriteNumber = Random.Range(1, bloodSprites.Length - 1);
            var randX = Random.Range(player.position.x - 1f, player.position.x + 1f);
            var randY = Random.Range(player.position.y - 1f, player.position.y + 1f);

            GameObject blood = Instantiate(bloodSprites[spriteNumber], new Vector3(randX, randY, player.position.z), player.rotation);
            blood.GetComponent<SpriteRenderer>().material = player.GetComponent<SpriteRenderer>().material;
        }
    }
}
