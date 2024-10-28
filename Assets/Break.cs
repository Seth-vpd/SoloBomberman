using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject parts;
    [SerializeField] private float _breakForce = 2;
    [SerializeField] private float force = 10f;
    [SerializeField] private float _collisionMultiplier = 100;
    [SerializeField] private bool _broken;

    public void BreakBox() {
            GameObject obj = Instantiate(parts, transform.position, transform.rotation); 
            var rbs = obj.GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rbs) {
                rb.AddExplosionForce(300f, gameObject.GetComponent<Collider>().bounds.center, 4);
            }
            /*var childs = obj.GetComponentsInChildren<GameObject>();
            foreach (var ch in childs) {
                if (ch)
                    Destroy(ch, 1.5f);
            }*/
            Destroy(gameObject);
            Destroy(obj, 2f);
        }
}
