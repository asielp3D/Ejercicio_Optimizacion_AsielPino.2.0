using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Transform gunPosition;

    [SerializeField] GameObject bulletPrefab;

    [SerializeField] int bulletType = 0;

    public float playerSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = PoolManager.Instance.GetPooledObjects(bulletType, gunPosition.position, gunPosition.rotation);

            if(bullet != null)
            {
                bullet.SetActive(true);
            }
            else
            {
                Debug.LogError("Pool demasiado pequeño");
            }
            
        }

        float horizontalInput = Input.GetAxis("Horizontal");

        float movementX = horizontalInput * playerSpeed * Time.deltaTime;

        transform.Translate(new Vector3(movementX, 0f, 0f));

        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
