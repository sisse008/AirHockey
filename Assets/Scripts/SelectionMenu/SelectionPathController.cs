using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionPathController : MonoBehaviour
{
    public Camera selectionCamera;
    [SerializeField]
    private float radius;

    [SerializeField]
    private SelectionData selectionItemsData;

    [SerializeField] 
    float switchTimeInSeconds;


    private List<Vector3> positions;
    
    private float DegreeDelta => 360f/(float)selectionItemsData.NumberOfItems;

    bool rotating = false;

    // Start is called before the first frame update
    void Start()
    {
        InitItemsPath();
        ResetPosition();
    }

    void ResetPosition()
    {
        Vector3 camPos = selectionCamera.transform.position;
        transform.position = new Vector3(camPos.x, camPos.y- 45f, camPos.z + radius + 90f);
    }
    private void InitItemsPath()
    {
        int numOfItems = selectionItemsData.NumberOfItems;
        positions = GetItemsPositionsOnCyclicPath(numOfItems);
        
        for(int i = 0; i< numOfItems; i++)
        {
            Instantiate(selectionItemsData.GetItem(i), positions[i], selectionItemsData.GetItem(i).transform.rotation, transform);
        }
    }

    public void NextItem(bool clockwise)
    {
        StartCoroutine(Rotate(clockwise));
    }

    IEnumerator Rotate(bool clockwise)
    {
        if (rotating)
            yield break;
        rotating = true;
        float time = 0;
        Vector3 current = transform.eulerAngles;
        Vector3 newRotation = new Vector3(current.x, clockwise? current.y+DegreeDelta : current.y - DegreeDelta, current.z);
        while (time < switchTimeInSeconds)
        {
            time += Time.deltaTime;
            transform.eulerAngles = Vector3.Lerp(current, newRotation, time/switchTimeInSeconds);
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
        rotating = false;
    }

    private List<Vector3> GetItemsPositionsOnCyclicPath(int numOfItems)
    {
        List<Vector3> _positions = new List<Vector3>();
      
        for (int i = 0; i < numOfItems; i++)
        {
            float angle = DegreeDelta * (float)i;
            /*float radians = angle/ Mathf.PI ;
            float x = Mathf.Cos(radians) * radius + transform.position.x;
            float y = Mathf.Sin(radians) * radius + transform.position.y;
            */
            var direction = Quaternion.Euler(0, angle, 0) * Vector3.back;
            _positions.Add(transform.position + direction * radius);
        }

        return _positions;
    }
 
}
