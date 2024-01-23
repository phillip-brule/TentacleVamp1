using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireControl : MonoBehaviour
{
    public List<GameObject> vampires = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vampires[0].transform.Translate(Vector3.right * Time.deltaTime);
    }
}
