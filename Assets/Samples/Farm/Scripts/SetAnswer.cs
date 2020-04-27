using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SetAnswer : MonoBehaviour {

    [SerializeField]
    private MeshRenderer boardRend;
    [SerializeField]
    private Material[] materials;

    public UnityEvent blockAEntered;
    public UnityEvent blockBEntered;

    private void Start()
    {
        if(blockAEntered == null)
        {
            blockAEntered = new UnityEvent();
        }

        if (blockBEntered == null)
        {
            blockBEntered = new UnityEvent();
        }

        blockAEntered.AddListener(BlockASelected); // answer selected is a subscriber to the event

        blockBEntered.AddListener(BlockBSelected); 
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "BlockA")
        {
            blockAEntered.Invoke();

        }
        else if(col.gameObject.tag == "BlockB")
        {
            blockBEntered.Invoke();

        }
    }

    private void BlockASelected()
    {

        Debug.Log("Block A Entered");

    }


    private void BlockBSelected()
    {

        Debug.Log("Block B Entered");

    }
}
