using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject gunObj;
    public Magazine LoadedMagazine;
    public Bullet ChamberedRound;
    public float lastShot;
    public float cycleTime;
    public float exitSpeedModifier = 1.0f;
    public Transform physicsFrame;
    public float Legth { get { return 0.5f; } }
    public Vector3 muzzleEnd { get { return transform.position + transform.forward.normalized * Legth; } }

    void Start()
    {
        // StartCoroutine(FireBullet());
    }

    // public IEnumerator FireBullet() 
    // {        
    //     while (true)
    //     {
    //         //Create a new bullet
    //         GameObject newBullet = Instantiate(bulletObj, transform.position, transform.rotation) as GameObject;

    //         //Parent it to get a less messy workspace
    //         newBullet.transform.parent = bulletParent;

    //         //Add velocity to the bullet with a rigidbody
    //         // newBullet.GetComponent<Rigidbody>().velocity = TutorialBallistics.bulletSpeed * transform.forward;

    //         yield return new WaitForSeconds(2f);
    //     }
    // }

    public void FireBullet()
    {
        if (canShoot())
        {
            Vector3 position = muzzleEnd;
            Vector3 direction = transform.forward.normalized;
            float speed = ChamberedRound.chargeSpeed * exitSpeedModifier;
            Transform parent = physicsFrame;
            ChamberedRound.Spawn(position, direction, speed, parent);

            lastShot = Time.time;
            chamberRound();
        }
    }

    public void reload(Magazine toReloadWith)
    {
        LoadedMagazine = toReloadWith;
        if (!hasChamberedRound())
        {
            chamberRound();
        }
    }

    public void chamberRound()
    {
        if (hasChamberedRound())
        {
            ChamberedRound = null;
        }

        if (!LoadedMagazine.empty())
        {
            ChamberedRound = LoadedMagazine.extractRound();
        }
    }

    public bool canShoot()
    {
        return hasCycled() && hasChamberedRound();
    }

    public bool hasChamberedRound()
    {
        return ChamberedRound != null;
    }

    public bool hasCycled()
    {
        float currentTime = Time.time;
        return lastShot + cycleTime >= currentTime;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(muzzleEnd, 0.1f);
    }
}
