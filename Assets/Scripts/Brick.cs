using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int hits = 1;
    public int points = 10;
    public Vector3 rotator;
    public Material hitMaterial;

    Material _orgMaterial;
    Renderer _renderer;

    void Start()
    {
        //transform.Rotate(rotator * (transform.position.x + transform.position.y)* 0.1f);
        _renderer = GetComponent<Renderer>();
        _orgMaterial = _renderer.sharedMaterial;
    }

    
    void Update()
    {
        //transform.Rotate(rotator * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        hits--;
        GameManager.Instance.Score += points;
        if (hits <= 0) {
            //Destroy() is a predefined variable that you can access to this game object to destroy the object
            Destroy(gameObject);
        }
        _renderer.sharedMaterial = hitMaterial;
        Invoke("RestoreMaterial", 0.05f);
    }
    void RestoreMaterial()
    {
        _renderer.sharedMaterial = _orgMaterial;
    }
}
