using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectZone : MonoBehaviour
{

    public bool selected = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (!selected)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            selected = true;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            selected = false;
        }
    }
}
