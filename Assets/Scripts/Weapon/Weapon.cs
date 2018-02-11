using UnityEngine;

public class Weapon : MonoBehaviour {

    public Sprite sprite;
    public GameObject bullet;
    public int ammo, damage, fireRate, range;

	void Start () {
		
	}

    public void Fire()
    {
        Debug.Log("Pew Pew");
    }

}
