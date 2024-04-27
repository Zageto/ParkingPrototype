using UnityEngine;

public class CartLogic : MonoBehaviour
{
    public float speed = 15;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * 20, ForceMode.Impulse);
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " Entered Depot");
        Destroy(gameObject);
    }
}
