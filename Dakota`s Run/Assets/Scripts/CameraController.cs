using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private float xMax;


    [SerializeField]
    private float xMin;
    [SerializeField]
    private float yMin;

    [SerializeField]
    private float speed = 2.0f;
    [SerializeField]
    private Transform target;

    private void Awake()
    {
        if (!target) target = FindObjectOfType<Character>().transform;
    }

    private void Update()
    {
        Vector3 position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), 
                                        Mathf.Clamp(target.position.y + 1f, yMin-4, float.MaxValue), -10.0f);
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
    }
}
