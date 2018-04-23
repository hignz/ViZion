using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInRange : MonoBehaviour
{
    public GameObject ObjectToTrack;
    public float TrackingRange = 5;
    private bool isTracking = false;
    public GameObject BulletLine;
    public FollowPath fp;
    public LayerMask whatEnemyCantSeeThrough;
    public LayerMask whatToHit;

    private void Start()
    {
        fp = GetComponent<FollowPath>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, ObjectToTrack.transform.position) <= TrackingRange && !Physics2D.Linecast(transform.position, ObjectToTrack.transform.position, whatToHit))
        {
            isTracking = true;
            fp.doMove = false;
            Shoot(ObjectToTrack.transform);
        }
        else
        {
            fp.doMove = true;
            isTracking = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (isTracking)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
      
        Gizmos.DrawWireSphere(transform.position, TrackingRange);
        Gizmos.DrawLine(transform.position, ObjectToTrack.transform.position);
    }

    private void Shoot(Transform target)
    {
        Vector3 diff = new Vector3(target.position.x, target.position.y) - transform.position;
        float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Vector2 dest = new Vector2(target.position.x + 1f, target.position.y + 1f);
        Vector2 firePos = new Vector2(transform.position.x, transform.position.y);

        RaycastHit2D hit = Physics2D.Raycast(firePos, dest - firePos, 100, whatToHit);
        Debug.DrawLine(firePos, (dest - firePos) * 100, Color.cyan, 4);

        //// Show bullet trail
        Instantiate(BulletLine, transform.position, transform.rotation);

        if (hit.collider != null)
        {
            Debug.DrawLine(firePos, hit.point, Color.red, 6);
            Debug.Log("I hit " + hit.collider.name);

        }

    }
}
