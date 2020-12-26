using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class rod_handler : MonoBehaviour
{
    [SerializeField]
    GameObject repr;
    [SerializeField]
    public UnityEngine.Events.UnityEvent onSelect, onDeselect;
    public rod_handler setHeight(float h)
    {
        repr.transform.localScale = new Vector3(repr.transform.localScale.x, h + 1, repr.transform.localScale.z);
        repr.transform.localPosition = new Vector3(repr.transform.localPosition.x, ((h + 1) / 2) + 1, repr.transform.localPosition.z);
        return this;
    }
    public void add(ring_handler r)
    {
        var rings = transform.GetComponentsInChildren<ring_handler>();
        if (rings.Count() <= 0 || rings.All(ring => ring.size > r.size))
            r.transform.parent = transform;
        r.transform.localPosition = new Vector3(0, r.transform.parent.GetComponentsInChildren<ring_handler>().Select(rng => rng.transform.localScale.y).Sum() + r.transform.localScale.y / 2, 0);

    }
    public void Select()
    {
        transform.parent.GetComponent<hannoi_manager>().SelectRod(this);
    }
}
