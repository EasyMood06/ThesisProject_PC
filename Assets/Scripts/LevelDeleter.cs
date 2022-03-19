using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDeleter : MonoBehaviour
{
    Controller controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        float controllerZ = controller.GetComponent<Transform>().position.z;
        float transformZ = gameObject.transform.position.z;
        float distance = controllerZ - transformZ;

        if(distance >  1500)
        {
            Destroy(gameObject);
        }
    }
}
