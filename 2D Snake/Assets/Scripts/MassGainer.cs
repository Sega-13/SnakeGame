using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassGainer : MonoBehaviour
{
    [SerializeField] private Walls walls;
    [SerializeField] private Snake snake;
    [SerializeField] private GameObject MassGainerObj;
    [SerializeField] private GameObject parentObj;
    private Transform MassGainerVal;
    float gainerCurrentTimer, gainerMaxTimer;
    public Boolean isMassGainerActivated;


    void Start()
    {
        gainerMaxTimer = 10;
        gainerCurrentTimer = gainerMaxTimer;
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }
    public void SetMassGainerVal(Transform MassGainerVal)
    {
        this.MassGainerVal = MassGainerVal;
    }
    public Transform GetMassGainerVal()
    {
        return this.MassGainerVal;
    }
    private void Update()
    {
       
        if(isMassGainerActivated)
        {
            gainerCurrentTimer -= Time.deltaTime;
            if (gainerCurrentTimer <= 0 || snake.isGameOver)
            {
                snake.isGainerActivated = false;
                MassGainerVal.gameObject.SetActive(false);
                gainerCurrentTimer = gainerMaxTimer;
                isMassGainerActivated = false;
            }
        }
       
    }
    public void InstanciateMassGainer()
    {
        isMassGainerActivated = true;
        if (MassGainerVal == null)
        {
            MassGainerVal = Instantiate(this.MassGainerObj,parentObj.transform).transform;
            SetMassGainerVal(MassGainerVal);
        }

        MassGainerVal.position = new Vector3(UnityEngine.Random.Range(walls.GetLeft().transform.position.x + 10, walls.GetRight().transform.position.x - 10),
             UnityEngine.Random.Range(walls.GetTop().transform.position.y - 10, walls.GetBottom().transform.position.y + 10), 0);
        MassGainerVal.gameObject.SetActive(true);
    }



}
