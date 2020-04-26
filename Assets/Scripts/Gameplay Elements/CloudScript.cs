using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CloudScript : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-15,-10),0,0); 
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < player.transform.position.z)
            gameObject.SetActive(false);
    }
}
