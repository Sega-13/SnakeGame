using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassBuner : MonoBehaviour
{
    [SerializeField] private Walls walls;
    [SerializeField] private Snake snake;
    [SerializeField] private GameObject MassBurnerObj;
    [SerializeField] private GameObject parentObj;
    public Boolean massBurnerActivated;
    Transform MassBurnerVal;
    float burnerMaxTimer, burnerCurrentTimer;
    private Boolean isMassBurnerActivated = false;
    int count = 0;
    void Start()
    {
        InvokeRepeating("InstanciateMassBuerner", 3, 10);
        burnerMaxTimer = 10;
        burnerCurrentTimer = burnerMaxTimer;
        
    }
    public void SetMassBurnerVal(Transform MassBurnerVal)
    {
        this.MassBurnerVal = MassBurnerVal;
    }
    public Transform GetMassBurnerVal()
    {
        return MassBurnerVal;
    }
    void Update()
    {
      
        if(isMassBurnerActivated)
        {
            burnerCurrentTimer -= Time.deltaTime;
            if(burnerCurrentTimer < 0)
            {
                snake.isBurnerActivated = false;
                MassBurnerVal.gameObject.SetActive(false);
                burnerCurrentTimer = burnerMaxTimer;
                isMassBurnerActivated = false;
            }
        }
       
    }
    void InstanciateMassBuerner()
    {
        if(massBurnerActivated) 
        {
            massBurnerActivated = false;
             isMassBurnerActivated = true;
            if (MassBurnerVal == null)
            {
                MassBurnerVal = Instantiate(this.MassBurnerObj, parentObj.transform).transform;
                SetMassBurnerVal(MassBurnerVal);
            }
            MassBurnerVal.position = new Vector3(UnityEngine.Random.Range(walls.GetLeft().transform.position.x + 10, walls.GetRight().transform.position.x - 10),
                UnityEngine.Random.Range(walls.GetTop().transform.position.y - 10, walls.GetBottom().transform.position.y + 10), 0);
            MassBurnerVal.gameObject.SetActive(true);
        }
        
    }
}
