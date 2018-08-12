using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airlockController : MonoBehaviour {


   // bool currentlyOperating = false;
    public GameObject interiorDoor;
    public GameObject exteriorDoor;
    public EjectionZone ejectZone;
    public Light[] lights;
    float openY, closeY;
    public float stageOffset = 25;
    bool doorOpening = false;
    bool lightsOn;

	// Use this for initialization
	void Start () {
        openY = interiorDoor.transform.position.y;
        closeY = exteriorDoor.transform.position.y;
        toggleLights();
        lightsOn = false;
	}
	

    IEnumerator doorControl()
    {
        toggleLights();
        lightsOn = true;

        while (interiorDoor.transform.position.y != closeY)
        {
            interiorDoor.transform.position = Vector3.MoveTowards(interiorDoor.transform.position, new Vector3(interiorDoor.transform.position.x, closeY, -24.9f), .05f);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(3);

        ejectZone.toggleEject();
        while (exteriorDoor.transform.position.y != openY)
        {
            exteriorDoor.transform.position = Vector3.MoveTowards(exteriorDoor.transform.position, new Vector3(exteriorDoor.transform.position.x, openY, -34.9f), .05f);
            yield return new WaitForEndOfFrame();
           
        }
        yield return new WaitForSeconds(3);

        while (exteriorDoor.transform.position.y != closeY)
        {
            exteriorDoor.transform.position = Vector3.MoveTowards(exteriorDoor.transform.position, new Vector3(exteriorDoor.transform.position.x, closeY, -34.9f), .05f);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(3);

        ejectZone.toggleEject();

        while (interiorDoor.transform.position.y != openY)
        {
            interiorDoor.transform.position = Vector3.MoveTowards(interiorDoor.transform.position, new Vector3(interiorDoor.transform.position.x, openY, -24.9f), .05f);
            yield return new WaitForEndOfFrame();
        }
        doorOpening = false;
        lightsOn = false;
        toggleLights();
        yield return new WaitForEndOfFrame();

    }



    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !doorOpening)
        {
            doorOpening = true;
            StartCoroutine(doorControl());
        }

        if (lightsOn)
        {
            foreach (var light in lights)
            {
                light.transform.RotateAround(light.transform.position, Vector3.right, 5f);
            }
        }

    }

    void toggleLights()
    {
        foreach (Light light in lights)
        {
            light.enabled = !light.enabled;
        }
    }
}
