using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoom : MonoBehaviour
{
    public int power = 1;
    public float explosionRadius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) //boom！
        {
            TryBoom();
        }
    }

    void TryBoom()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 10);

        foreach(Collider col in colliders)
        {
            if(col.GetComponent<Rigidbody>() && col.CompareTag("Box"))
                col.GetComponent<Rigidbody>().AddExplosionForce(power, transform.position, explosionRadius, 5, ForceMode.Impulse);  
        }
    }
}
