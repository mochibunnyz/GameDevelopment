using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpStep : MonoBehaviour
{
    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            rend.material.color = Color.yellow;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
