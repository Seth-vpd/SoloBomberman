using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float radius = 10f;
    [SerializeField] private float force = 5f;
    [SerializeField] private GameObject particle;
    [SerializeField] private GameObject parts;
    [SerializeField] private GameObject[] newPos;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Player")) {
                GameObject blood = Instantiate(particle, collider.gameObject.transform.position, Quaternion.identity);
                Destroy(blood, 1f);
                collider.gameObject.GetComponent<PlayerController>().IsDead = true;
                collider.gameObject.GetComponent<PlayerController>().resetPos = newPos[Random.Range(0, newPos.Length)].transform.position;
            }
            if (collider.gameObject.CompareTag("Block") || collider.gameObject.CompareTag("Box")) {
                collider.gameObject.GetComponent<Break>().BreakBox();
            }
        }
        Destroy(gameObject, 0.275f);
    }
}
