using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionPathController : MonoBehaviour
{
    [SerializeField]
    private float radius;

    [SerializeField]
    private SelectionData selectionItemsData;

    [SerializeField] 
    float rotationSpeed;


    private List<Vector3> positions;
    

    private float DegreeDelta => 360f/(float)selectionItemsData.NumberOfItems;


    // Start is called before the first frame update
    void Start()
    {
        SetItemPath();
        SetPosition();
    }

    void SetPosition()
    {
        
    }
    private void SetItemPath()
    {
        int numOfItems = selectionItemsData.NumberOfItems;
        positions = GetItemsPositionsOnCyclicPath(numOfItems);
        
        for(int i = 0; i< numOfItems; i++)
        {
            Instantiate(selectionItemsData.GetItem(i), positions[i], Quaternion.identity, transform);
        }
    }

    public void NextItem(bool clockwise)
    {
        //TODO: rotate transform by DegreeDelta
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
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
