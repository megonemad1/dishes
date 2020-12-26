using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ring_handler : MonoBehaviour
{
    [SerializeField]
    public float size = 1;
    [SerializeField]
    GameObject repr;

    private void Awake()
    {
        
    repr.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(Random.value, 0.4f + Random.value / 2f, 0.5f + Random.value / 4f);
    }
    public ring_handler setSize(float s)
    {
        size = s;
        repr.transform.localScale = new Vector3(size, repr.transform.localScale.y, repr.transform.localScale.z);
        return this;
    }
    public void AlertParent()
    {
        transform.parent.GetComponent<rod_handler>().Select();
    }

}
