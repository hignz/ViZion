using UnityEngine;
using TMPro;

public class Player : MonoBehaviour {

    public Sprite equip, unequipped;

    public bool godMode = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ToggleGodMode();
        }
    }

    public void ToggleGodMode()
    {
        godMode = !godMode;

        if (godMode)
        {
            gameObject.tag = "Untagged";
        }
        else
        {
            gameObject.tag = "Player";
        }
    }

    public void Die()
    {
        GameObject deadBody = GameObject.Instantiate(FindObjectOfType<SpriteManager>().GetPlayerDead(), transform.position, transform.rotation);
        FindObjectOfType<SpriteManager>().SpawnBloodSplatter(transform);
        //gameObject.SetActive(false);
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
