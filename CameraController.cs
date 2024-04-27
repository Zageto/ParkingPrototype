using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject car;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = car.transform.position + new Vector3(0, 16, -8);
    }
}
