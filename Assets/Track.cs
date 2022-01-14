using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public Transform path;
    private bool pathAssigned = false;

    // Start is called before the first frame update
    private void Start() 
    {
        
        //path = transform.Find("Path"); 
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (pathAssigned)
        //     return;
        
        // path = transform.Find("Path"); 
        // pathAssigned = true;
    }

    public Vector3 GetEntryPoint()
    {
        return path.GetChild(0).position;
    }

    public Vector3 GetExitPoint()
    {
        return path.GetChild(1).position;
    }
}
