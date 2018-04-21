using UnityEngine;
using TMPro;

public class Player : MonoBehaviour {

    public Sprite equip, unequipped;
   
    

    void Start () {
		 
	}
	
	void Update () {

        
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
