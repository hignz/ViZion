using UnityEngine;

public class Shotgun : Weapon {

    public override void Fire()
    {
        Debug.Log("Shotgun Pew Pew");

        Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePos = new Vector2(firePoint.position.x, firePoint.position.y);

        RaycastHit2D hit = Physics2D.Raycast(firePos, (mousePos - firePos) * 100, 100);

        Debug.DrawLine(firePos, (mousePos - firePos) * 100, Color.cyan);

        if (hit.collider != null)
        {
            Debug.DrawLine(firePos, hit.point, Color.red);
            Debug.Log("We hit " + hit.collider.name);
        }
    }
}
