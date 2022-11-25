using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nuvem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(6f * Time.deltaTime, 0, 0);

        if(transform.position.x <= -12){
            Destroy(this.gameObject);
        }
    }
}
