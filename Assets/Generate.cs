using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    public GameObject spawn;
    public GameObject cacto;
    public GameObject nuvem;
    public GameObject moon;
    Vector3 nuvemVector;
    Vector3 moonVector;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("cacRespawn", 1.5f, 1.3f);
        InvokeRepeating("nuvemRespawn", 0.5f, 1f);
        InvokeRepeating("moonRespawn", 0.1f, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void cacRespawn(){
        spawn = Instantiate(cacto, transform.position, Quaternion.identity) as GameObject;
    }

    void nuvemRespawn(){
        nuvemVector = new Vector3(transform.position.x, Random.Range(1f, 4f), 2);
        spawn = Instantiate(nuvem, nuvemVector, Quaternion.identity) as GameObject;
    }

    void moonRespawn(){
        moonVector = new Vector3(transform.position.x, Random.Range(2f, 4f), 2);
        spawn = Instantiate(nuvem, transform.position, Quaternion.identity) as GameObject;
    }
}
