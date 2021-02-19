using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooter : MonoBehaviour
{
    public Gun gun;
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(FireBullets());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator FireBullets()
    {
        while (true)
        {
            Debug.Log("Haha shoot");

            yield return new WaitForSeconds(0.2f);
        }
    }

    private void buildGun()
    {

    }

    private void buildMagazine()
    {

    }

    private void buildBullet()
    {

    }
}
