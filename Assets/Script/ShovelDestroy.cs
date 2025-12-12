using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelDestroy : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            collision.gameObject.GetComponent<HPController>().Shoveled();
        }
        Destroy(this.gameObject);
    }
}
