using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float queueTime = 1.5f;
    private float time = 0;
    public GameObject obstacle;
    public GameObject coins;

    public float height;
    private bool newCoin = false;

    // Update is called once per frame
    void Update()
    {
        if(time > queueTime)
        {
            GameObject go = Instantiate(obstacle);
            go.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            //coins
            newCoin = (Random.value < 0.3f);
            if(newCoin)
            {
                GameObject coin1 = Instantiate(coins);
                coin1.transform.position =  go.transform.position + new Vector3(-0.25f, Random.Range(-height/2, height/2), 0);
            }
            
            time = 0;

            Destroy(go, 10);
        }

        time += Time.deltaTime;
    }
}