using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector2 direction = Vector2.zero;
    List<Transform> segment = new List<Transform>();
    public GameObject snakeBodyPrefab;
   
    void Start()
    {
        segment.Add(this.transform);
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector2.up;
        }else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector2.down;
        }else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
        
    }
    private void FixedUpdate()
    {
        for(int i = segment.Count - 1; i > 0; i--)
        {
            if (segment[i] != null)
            {
                segment[i].position = segment[i-1].position;
            }
        }
        //Snake movement
        this.transform.position = new Vector2(Mathf.Round(this.transform.position.x) + direction.x,
        Mathf.Round(this.transform.position.y) + direction.y);
    }
    public void Grow()
    {
        Transform segmentPart = Instantiate(this.snakeBodyPrefab).transform;
        segmentPart.position = segment[segment.Count-1].position;
        segment.Add(segmentPart);
    }
}
