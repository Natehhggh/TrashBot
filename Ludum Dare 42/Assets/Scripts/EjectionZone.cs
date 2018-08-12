using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjectionZone : MonoBehaviour {

	// Use this for initialization
    
    public bool ejecting = false;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider col){
        if (col.attachedRigidbody && ejecting)
        {
            col.attachedRigidbody.AddForce(Vector3.back * 100);
        }
    }

    public void toggleEject()
    {
        ejecting = !ejecting;
    }

}
