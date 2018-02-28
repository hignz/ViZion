using UnityEngine;

public class Uzi : Weapon {

    public Transform LineRendererPrefab;

    public override void Fire()
    {
        Debug.Log("Uzi Pew Pew");

        Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePos = new Vector2(firePoint.position.x, firePoint.position.y);

        RaycastHit2D hit = Physics2D.Raycast(firePos, (mousePos-firePos) * 100, 100);

        // Show bullet trail
        Instantiate(LineRendererPrefab, firePoint.position, firePoint.rotation);

        Debug.DrawLine(firePos, (mousePos-firePos), Color.cyan);

        if (hit.collider != null)
        {
            Debug.DrawLine(firePos, hit.point, Color.red);
            Debug.Log("I hit " + hit.collider.name);
        }
    }
}
