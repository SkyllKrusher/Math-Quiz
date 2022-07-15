using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float rotSpeed;
    int seed = 0;
    // Update is called once per frame
    void Update()
    {
        RotateSelf();
    }

    private void RotateSelf()
    {
        Random.InitState(seed);
        Vector3 rot = new Vector3(Random.Range(0.8f, 1f), Random.Range(0.5f, 8f), Random.Range(0.3f, 0.7f)) * rotSpeed ;
        transform.Rotate(rot*Time.deltaTime);
        
    }
}
