using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInRange : MonoBehaviour
{
    public GameObject ObjectToTrack;
    public float TrackingRange = 5;
    private bool isTracking = false;
    public GameObject BulletLine;
    private FollowPath pathScript;
    //public LayerMask whatEnemyCantSeeThrough;
    public LayerMask whatToHit;

    private Transform firePoint;

    private float lastShotTime;
    private int ammo = 24;

    private void Start()
    {
        pathScript = GetComponent<FollowPath>();
        firePoint = GetComponentInChildren<FirePoint>().transform;
    }

    void Update()
    {
        if (ObjectToTrack == null)
        {
            pathScript.doMove = true;
            isTracking = false;
        }

        lastShotTime += Time.deltaTime;

        if (Vector2.Distance(transform.position, ObjectToTrack.transform.position) <= TrackingRange && !Physics2D.Linecast(transform.position, ObjectToTrack.transform.position, whatToHit))
        {
            isTracking = true;
            pathScript.doMove = false;

            if (lastShotTime > 0.05 && ammo > 0)
            {
                ammo--;

                Shoot(ObjectToTrack.transform);

                lastShotTime = 0;
            }
        }
        else
        {
            pathScript.doMove = true;
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
        FaceDirectionOf(target);

        //Vector2 dest = new Vector2(target.position.x + 1f, target.position.y + 1f);
        Vector2 firePos = new Vector2(firePoint.position.x, firePoint.position.y);

        //RaycastHit2D hit = Physics2D.Raycast(firePos, dest - firePos, 100, whatToHit);
        //Debug.DrawLine(firePos, (dest - firePos) * 100, Color.cyan, 4);

        //// Show bullet trail
        Instantiate(BulletLine, firePos, firePoint.transform.rotation);

        PlaySoundEffect();

        //if (hit.collider != null)
        //{
        //    Debug.DrawLine(firePos, hit.point, Color.red, 6);
        //    Debug.Log("I hit " + hit.collider.name);
        //}

    }

    private void FaceDirectionOf(Transform target)
    {
        Vector3 diff = new Vector3(target.position.x, target.position.y) - transform.position;
        float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void PlaySoundEffect()
    {
        GetComponent<AudioSource>().Play();
    }
}
