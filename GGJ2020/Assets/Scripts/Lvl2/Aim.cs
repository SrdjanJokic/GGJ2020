using UnityEngine;
using System.Linq;
using System.Collections;

public class Aim : MonoBehaviour
{
    public bool isBlue;
    private GameObject[] goArray;
    private RaycastHit hitInfo;
    private string layer;
    private Transform upperPart;
    private GameObject goToLookAt = null;
    private Shoot shoot;

    private void Awake()
    {
        shoot = GetComponent<Shoot>();
        upperPart = transform.Find("Aimer");
        Debug.LogError(shoot);
    }

    private void Start()
    {
        StartCoroutine(RepeatSearches());
    }

    private void Update()
    {
        if(goToLookAt != null)
        {
            upperPart.LookAt(goToLookAt.transform);
        }
    }

    private IEnumerator RepeatSearches()
    {
        while(true)
        {
            GetClosest();
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void GetClosest()
    {
        layer = GetLayer();
        goArray = GameObject.FindGameObjectsWithTag(layer);
        goArray = goArray.OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).ToArray();

        for (int i = 0; i < goArray.Length; i++)
        {
            if (Physics.Raycast(transform.position, (goArray[i].transform.position- transform.position).normalized, 
                out hitInfo, Mathf.Infinity))
            {
                if(hitInfo.collider.tag == layer)
                {
                    // Shoot
                    upperPart.LookAt(hitInfo.transform);
                    goToLookAt = hitInfo.transform.gameObject;
                    shoot.ShootFromCannon();
                    return;
                }
                else
                {
                    goToLookAt = null;
                }
            }
        }
    }

    private string GetLayer()
    {
        return isBlue ? "Red" : "Blue";
    }
}
