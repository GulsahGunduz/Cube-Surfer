using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStackController : MonoBehaviour
{
    public List<GameObject> cubeList = new List<GameObject>();

    GameObject lastCube;

    bool isStack = false;
    Vector3 direction = Vector3.back;


    void Start()
    {
        UpdateLastCube();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {
            if (!isStack)
            {
                isStack = !isStack;
                IncreaseCubes(gameObject);

                SetDirection();
            }
        }
        if (other.gameObject.tag == "Obstacle")
        {
            DecreaseCubes(gameObject);
        }
    }

    public void IncreaseCubes(GameObject _gameObject)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        _gameObject.transform.position = new Vector3(transform.position.x, lastCube.transform.position.y - 2f, transform.position.z);
        _gameObject.transform.SetParent(transform);

        cubeList.Add(_gameObject);
        UpdateLastCube();
    }

    public void DecreaseCubes(GameObject _gameObject)
    {
        _gameObject.transform.parent = null;
        cubeList.Remove(_gameObject);

        UpdateLastCube();
        Destroy(_gameObject, 1.5f);
    }

    void SetDirection()
    {
        direction = Vector3.forward;
    }

    public void UpdateLastCube()
    {
        lastCube = cubeList[cubeList.Count - 1];
    }
}
