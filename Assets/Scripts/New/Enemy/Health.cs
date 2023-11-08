using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;
    //public GameObject healthObject;
    //public Material objectMaterial;
    private GameObject healthObject;
    // Start is called before the first frame update
    void Start()
    {
        //objectMaterial = gameObject.GetComponent<MeshRenderer>().material;
        healthObject = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Enemy") {
            if (health == 0)
			{
				GameObject healthObject = gameObject;
				Destroy(healthObject);
			}
		}

    }
}
