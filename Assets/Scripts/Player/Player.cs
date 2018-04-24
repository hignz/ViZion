using UnityEngine;
using TMPro;

public class Player : MonoBehaviour {

    public Sprite equip, unequipped;

    public void Die()
    {
        GameObject deadBody = GameObject.Instantiate(FindObjectOfType<SpriteManager>().GetPlayerDead(), transform.position, transform.rotation);
        FindObjectOfType<SpriteManager>().SpawnBloodSplatter(transform);
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

    public void SwapToEquipSprite()
    {
        GetComponent<SpriteRenderer>().sprite = equip;
    }

    public void SwapToUnequippedSprite()
    {
        GetComponent<SpriteRenderer>().sprite = unequipped;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("dialogueTrigger"))
        {
            collision.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Creates issues when lots of dialogue triggers are close together

        if (collision.gameObject.CompareTag("dialogueTrigger"))
        {
            collision.gameObject.GetComponent<DialogueTrigger>().EndDialogue();
        }
    }
}
