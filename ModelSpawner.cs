using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSpawner : MonoBehaviour
{
    public GameObject house;
    public GameObject SolarPanelBasic;
    public Transform spawnpos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void SpawnHouse() 
    {
        GameObject houseobj;
        houseobj = Instantiate(house, spawnpos);
    }

    public void SpawnSolarPanelBasic() 
    {
        GameObject solarpanelbasicobj;
        solarpanelbasicobj = Instantiate(SolarPanelBasic, spawnpos);
    }
}
