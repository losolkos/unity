using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{
    public float acceleration = 10;
    public GameObject bulletPrefab;
    private Rigidbody rb;
    private Vector2 controls;
    private Transform gunl;
    private bool fireButtonDown = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gunl = transform.Find("gunl");
    }

    // Update is called once per frame
    void Update()
    {
        float v, h;
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        controls = new Vector2(h, v);
        if (Mathf.Abs(transform.position.x) > 20)
        {
            Vector3 newPosition = new Vector3(transform.position.x * -1, 0, transform.position.z);

            transform.position = newPosition;

        }
        if (Mathf.Abs(transform.position.z) > 11)
        {
            Vector3 newPosition = new Vector3(transform.position.x, 0, transform.position.z * -1);

            transform.position = newPosition;

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            fireButtonDown = true;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * controls.y * acceleration, ForceMode.Acceleration);
        rb.AddTorque(transform.up * controls.x * acceleration, ForceMode.Acceleration);
        if (fireButtonDown)
        {
            GameObject bullet1 = Instantiate(bulletPrefab, gunl.position, Quaternion.identity);
            bullet1.transform.parent = null;
            bullet1.GetComponent<Rigidbody>().AddForce(transform.forward * 20,
                ForceMode.VelocityChange);
            Destroy(bullet1, 5);
            fireButtonDown = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other = collision.gameObject) {
            Time.timeScale = 0;
            GameObject gameoverscreen = GameObject.Find("Canvas").transform.Find("gameOverScreen").gameObject;
            gameoverscreen.SetActive(true);
            Destroy(other);
            Destroy(gameObject);
        }
    }
}