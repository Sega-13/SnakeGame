using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public Vector2 direction = Vector2.zero;
    List<Transform> segment = new List<Transform>();
    [SerializeField]private GameObject snakeBodyPrefab;
    [SerializeField]private GameObject Top,Bottom,Left,Right;
    [SerializeField]private Camera cam;
    [SerializeField] private GameObject GameOverScreen;
    
   
    void Start()
    {
        segment.Add(this.transform);
        OrthographicBound(cam);
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
        StartCoroutine(changeTag(segmentPart.gameObject));
        segment.Add(segmentPart);
    }
    public void OrthographicBound(Camera camera)
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        Bounds bounds = new Bounds(camera.transform.position, new Vector2(cameraHeight * screenAspect, cameraHeight));
        Top.transform.position = new Vector2(0, bounds.max.y);
        Bottom.transform.position = new Vector2(0, bounds.min.y);
        Left.transform.position = new Vector2(bounds.min.x, 0);
        Right.transform.position = new Vector2(bounds.max.x, 0);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "walls")
        {
            ChangeDirection();
        }
        if(collision.gameObject.tag == "obs")
        {
            GameOverScreen.SetActive(true);
        }    
    }
    public void Restart()
    {
        GameOverScreen.SetActive(false);
        for (int i = 1; i < segment.Count; i++)
        {
            Destroy(segment[i].gameObject);
        }
        segment.Clear();
        segment.Add(this.transform);
        transform.position = Vector2.zero;
    }
    void ChangeDirection()
    {
        if (direction == Vector2.left)
        {
            this.transform.position = new Vector2(Mathf.Round(Right.transform.position.x) + direction.x,
      Mathf.Round(this.transform.position.y) + direction.y);
        }
        if (direction == Vector2.right)
        {
            this.transform.position = new Vector2(Mathf.Round(Left.transform.position.x) + direction.x,
      Mathf.Round(this.transform.position.y) + direction.y);
        }
        if (direction == Vector2.up)
        {
            this.transform.position = new Vector2(Mathf.Round(this.transform.position.x) + direction.x,
      Mathf.Round(Bottom.transform.position.y) + direction.y);
        }
        if (direction == Vector2.down)
        {
            this.transform.position = new Vector2(Mathf.Round(this.transform.position.x) + direction.x,
      Mathf.Round(Top.transform.position.y) + direction.y);
        }
    }
    public IEnumerator changeTag(GameObject segment)
    {
        yield return new WaitForSeconds(1);
        if(segment != null)
        {
            segment.tag = "obs";
        }
       
    }
}
