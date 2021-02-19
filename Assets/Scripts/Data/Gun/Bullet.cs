using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletObj;
    public Rigidbody bulletBody;
    public Transform bulletParent;
    public float chargeSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn(Vector3 position, Vector3 direction, float Speed, Transform parent)
    {
        // Create a new bullet
        GameObject bulletObj = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;

        //Parent it to get a less messy workspace
        bulletObj.transform.parent = bulletParent;

        //Add velocity to the bullet with a rigidbody
        bulletBody.velocity = Speed * direction;

        // bulletBody.e
    }
}
