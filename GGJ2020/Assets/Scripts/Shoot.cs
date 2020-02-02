using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private bool isReloading;

    public void ShootFromCannon()
    {
        if(!isReloading)
        {
            StartCoroutine(BeginShot());
        }
    }

    private IEnumerator BeginShot()
    {
        isReloading = true;

        Vector3 spawnLocation = transform.Find("Aimer").Find("UpperBody").Find("ShootingLocation").position;
        GameObject bullet = Instantiate(GameObject.Find("Bullet"), spawnLocation, Quaternion.identity);
        bullet.transform.rotation = transform.Find("Aimer").rotation;
        bullet.AddComponent<BulletFlight>();

        yield return new WaitForSeconds(3f);
        isReloading = false;
    }
}
