using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanupTanks : MonoBehaviour
{
    private Transform[] blueTanks;
    private Transform[] redTanks;

    // vectors
    private Vector3 blueSpawn1 = new Vector3(-45f, 2.09f, -16.6f);
    private Vector3 redSpawn1 = new Vector3(31.9f, 2.09f, -16.6f);


    private void Start()
    {
        SpawnBlues();
        SpawnReds();
    }

    private void SpawnBlues()
    {
        GameObject blueHolder = GameObject.Find("BlueTanks");
        blueTanks = new Transform[blueHolder.transform.childCount];

        // Reference children
        for (int i = 0; i < blueHolder.transform.childCount; i++)
        {
            blueTanks[i] = blueHolder.transform.GetChild(i);
        }

        // Set them on their spawns
        for (int i = 0; i < blueTanks.Length; i++)
        {
            blueTanks[i].gameObject.SetActive(true);
            blueTanks[i].position = blueSpawn1;
            blueSpawn1.x += 7f;

            blueTanks[i].localRotation = Quaternion.Euler(0f, 0f, 0f);
            blueTanks[i].GetComponent<Rigidbody>().isKinematic = false;
            blueTanks[i].gameObject.AddComponent<Aim>();
            blueTanks[i].gameObject.GetComponent<Aim>().isBlue = true;
        }

        blueTanks[0].GetComponent<Movement>().isControlled = true;
    }

    private void SpawnReds()
    {
        GameObject redHolder = GameObject.Find("RedTanks");
        redTanks = new Transform[redHolder.transform.childCount];

        // Reference children
        for (int i = 0; i < redHolder.transform.childCount; i++)
        {
            redTanks[i] = redHolder.transform.GetChild(i);
        }

        // Set them on their spawns
        for (int i = 0; i < redTanks.Length; i++)
        {
            redTanks[i].gameObject.SetActive(true);
            redTanks[i].position = redSpawn1;
            redSpawn1.x += 7f;

            redTanks[i].localRotation = Quaternion.Euler(0f, 0f, 0f);
            redTanks[i].GetComponent<Rigidbody>().isKinematic = false;
            redTanks[i].gameObject.AddComponent<Aim>();
        }

        redTanks[0].GetComponent<Movement>().isControlled = true;
    }


}
