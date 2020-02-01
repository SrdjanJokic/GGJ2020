using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public GameObject[] cubes;
    private Vector3[] startPos;
    private Vector3[] endPos;
    public int counter = 0;
    public bool isMoving;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && counter > 0 && isMoving == false)
        {
            StartCoroutine(MoveOverSeconds(cubes, Vector3.right, 4f, 2f));
            counter--;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && counter < cubes.Length - 1 && isMoving == false)
        {
            StartCoroutine(MoveOverSeconds(cubes, -Vector3.right, 4f, 2f));
            counter++;
        }
    }
    
    public IEnumerator MoveOverSpeed(GameObject objectToMove, Vector3 end, float speed)
    {
        // speed should be 1 unit per second
        while (objectToMove.transform.position != end)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    public int i;
    public IEnumerator MoveOverSeconds(GameObject[] cubes, Vector3 direction, float distance, float seconds)
    {
        isMoving = true;
        startPos = new Vector3[cubes.Length];
        endPos = new Vector3[cubes.Length];

        for (i = 0; i < cubes.Length; i++)
        {
            startPos[i] = cubes[i].transform.position;
        }
        
        
        for(i = 0; i < cubes.Length; i++)
        {
            endPos[i] = startPos[i] + direction * distance;
        }

        float elapsedTime = 0;
        while (elapsedTime < seconds)
        {
            for (i = 0; i < cubes.Length; i++)
            {
                cubes[i].transform.position = Vector3.Lerp(startPos[i], endPos[i], (elapsedTime / seconds));
            }


            elapsedTime += Time.deltaTime;
            yield return null;
        }

        for (i = 0; i < cubes.Length; i++)
        {
            cubes[i].transform.position = endPos[i];
        }
        isMoving = false;
    }

}
