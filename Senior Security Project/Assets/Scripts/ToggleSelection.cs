using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSelection : MonoBehaviour {

    public Material[] materials = new Material[2]; // Material color for when selected and non-selected
    public Renderer rend; // Rendering the grid square

    private bool selected;

	// Use this for initialization
	void Start () {
        selected = false;
        rend = gameObject.GetComponent<Renderer>();

	}
    private void OnMouseDown()
    { 
        if (!selected)
        {
            print(gameObject.name);
            rend.material = materials[1]; //1 will be index for selected color
            selected = true;
        }
            
        else {
            rend.material = materials[0];
            selected = false;
        }
            
    }

}
