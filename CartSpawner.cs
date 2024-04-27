using System.Collections;
using UnityEngine;

public class CartSpawner : MonoBehaviour
{
    public GameObject shoppingCart;
    private int cartRefresh;

    public float spawnTime;


    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnCart", 1, Timer());
        StartCoroutine(SpawnCart(spawnTime));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnCart(float spawnTime)
    {
        yield return new WaitForSeconds(spawnTime);
        Instantiate(shoppingCart, transform.position, shoppingCart.transform.rotation);

        StartCoroutine(SpawnCart(spawnTime));
    }

    private void SpawnCart()
    {
        Instantiate(shoppingCart, transform.position, shoppingCart.transform.rotation);
    }

    int Timer()
    {
        cartRefresh = Random.Range(5, 7);
        return cartRefresh;
    }


}
