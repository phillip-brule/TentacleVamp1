using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireControl : MonoBehaviour
{
    public List<GameObject> vampires = new List<GameObject>();
    public GameObject ground;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vampires[0].transform.position.x < ((ground.transform.localScale.x / 2) + ground.transform.position.x))
        {
            vampires[0].transform.Translate(Vector3.right * Time.deltaTime);
        }
        
    }
}
