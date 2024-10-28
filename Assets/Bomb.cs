using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject explosion;
    int i = 0;
    public float explodeDelay;
    void Start()
    {
        StartCoroutine(explode());
    }

    // Update is called once per frame
    IEnumerator explode() {
        while (i < explodeDelay) {
            i++;
            yield return new WaitForSeconds(1f);
        }
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void Update()
    {
    }
}
