using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Walls : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField]private GameObject Top, Bottom, Left, Right;
    private Bounds bounds;
    void Start()
    {
        
        OrthographicBound(cam);

    }
    public Bounds GetBounds()
    {
        return bounds;
    }
    public void SetBounds(Bounds bounds)
    {
        this.bounds = bounds;
    }
    public GameObject GetTop()
    {
        return Top;
    }
    public void SetTop(GameObject Top)
    {
        this.Top = Top;
    }
    public GameObject GetBottom()
    {
        return Bottom;
    }
    public void SetBottom(GameObject Bottom)
    {
        this.Bottom = Bottom;
    }
    public GameObject GetLeft()
    {
        return Left;
    }
    public void SetLeft(GameObject Left)
    {
        this.Left = Left;
    }
    public GameObject GetRight()
    {
        return Right;
    }
    public void SetRight(GameObject Right)
    {
        this.Right = Right;
    }
    void Update()
    {
        
    }
    public void OrthographicBound(Camera camera)
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        bounds = new Bounds(camera.transform.position, new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        SetBounds(bounds);
        Top.transform.position = new Vector3(0, bounds.max.y, 0);
        SetTop(Top);
        Bottom.transform.position = new Vector3(0, bounds.min.y, 0);
        SetBottom(Bottom);
        Left.transform.position = new Vector3(bounds.min.x, 0, 0);
        SetLeft(Left);
        Right.transform.position = new Vector3(bounds.max.x, 0, 0);
        SetRight(Right);


    }
}
