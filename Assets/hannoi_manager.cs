using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class hannoi_manager : MonoBehaviour
{
    [SerializeField]
    rod_handler[] rods;

    [SerializeField]
    GameObject ringPrefab, rodPrefab;

    [SerializeField]
    int ammount;
    [SerializeField]
    float buffer = 1;
    [SerializeField]
    rod_handler selected = null;
    [SerializeField]
    UnityEngine.Events.UnityEvent onWin;

    private void Awake()
    {
        rods = new GameObject[] {
            Instantiate(rodPrefab,Vector3.left*(ammount+buffer+1),Quaternion.identity,transform),
            Instantiate(rodPrefab,Vector3.zero,Quaternion.identity,transform),
            Instantiate(rodPrefab,Vector3.right*(ammount+buffer+1),Quaternion.identity,transform)
        }.Select(g => g.GetComponent<rod_handler>().setHeight(ammount + 1)).ToArray();

        var start = rods.First();
        for (float i = ammount; i > 0; i--)
        {
            start.add(Instantiate(ringPrefab).GetComponent<ring_handler>().setSize(i + buffer));
        }

    }

    public void SelectRod(rod_handler rod)
    {
        if (selected == null)
        {
            selected = rod;
            selected.onSelect.Invoke();
        }
        else
        {
            if (selected.transform.childCount > 1)
                rod.add(selected.transform.GetChild(selected.transform.childCount - 1).GetComponent<ring_handler>());
            selected.onDeselect.Invoke();
            selected = null;
            CheckWin();
        }
    }

    private void CheckWin()
    {
        if (rods.Last().GetComponentsInChildren<ring_handler>().Count() >= ammount)
        {
            onWin.Invoke();
        }
    }
}
