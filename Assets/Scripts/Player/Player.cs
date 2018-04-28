using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class Player : MonoBehaviour {

    public Sprite equip, unequipped;

    public bool godMode = false;

    public bool hasSlowTime = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ToggleGodMode();
        }

        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            Debug.Log("yooo");
            Time.timeScale = 0.5f;

            hasSlowTime = false;

            StartCoroutine(RemoveSlowMo());
        }
    }

    IEnumerator RemoveSlowMo()
    {
        yield return new WaitForSeconds(1f);

        Time.timeScale = 1f;
    }

    public void ToggleGodMode()
    {
        godMode = !godMode;

        if (godMode)
        {
            gameObject.tag = "Untagged";
            Debug.Log("GodMode Enabled");
        }
        else
        {
            gameObject.tag = "Player";
            Debug.Log("GodMode Disabled");
        }
    }

    public void Die()
    {
        GameObject deadBody = GameObject.Instantiate(FindObjectOfType<SpriteManager>().GetPlayerDead(), transform.position, transform.rotation);
        FindObjectOfType<SpriteManager>().SpawnBloodSplatter(transform);
       // gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public void SwapToEquipSprite()
    {
        GetComponent<SpriteRenderer>().sprite = equip;
    }

    public void SwapToUnequippedSprite()
    {
        GetComponent<SpriteRenderer>().sprite = unequipped;
    }
}
