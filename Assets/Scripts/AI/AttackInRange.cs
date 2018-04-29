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

        Vector2 firePos = new Vector2(firePoint.position.x, firePoint.position.y);

        GameObject bullet = Instantiate(BulletLine, firePos, firePoint.transform.rotation);
        bullet.transform.Rotate(0, 0, UnityEngine.Random.Range(-10, 10));

        PlaySoundEffect();
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
