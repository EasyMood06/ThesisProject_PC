using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject generator;
    public List<GameObject> levels;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GeneratingNewLevel();
        }
    }

    void GeneratingNewLevel()
    {
        GameObject level;
        int index = Random.Range(0,6);
        level = levels[index];

        Vector3 offset_level = new Vector3(0,0,700);
        Instantiate(level, gameObject.transform.position + offset_level, Quaternion.identity);

        Vector3 offset_generator = new Vector3(0,0,900);
        Instantiate(gameObject, gameObject.transform.position + offset_generator, Quaternion.identity);

    }

    
    
}
