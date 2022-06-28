using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpwardItems : MonoBehaviour
{
    public float speed = 5.0F;
    private float limitZ = 10.0f;
    private Rigidbody rgItems;
    // Start is called before the first frame update
    void Start()
    {
        rgItems = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rgItems.AddForce(Vector3.forward * -speed);

        if (transform.position.z < -limitZ)
        {
            Destroy(gameObject);
        }
    }
}
