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

                                        //Below, you can see the code used to create the unity events system
    private void Start()
    {                                                         
        if(blockAEntered == null) //checks if blockAEntered does not exist. if not, we instatiate a singleton of blockAEntered
        {
            blockAEntered = new UnityEvent(); //Declares blockAEntered as a new UnityEvent()
        }

        if (blockBEntered == null) //checks if blockBEntered does not exist. if not, we instatiate a singleton of blockBEntered
        {
            blockBEntered = new UnityEvent(); //Declares blockBEntered as a new UnityEvent()
        }

        blockAEntered.AddListener(BlockASelected); // BlockASelected is a subscriber to the event blockAEntered.AddListener()

        blockBEntered.AddListener(BlockBSelected); // BlockBSelected is a subscriber to the event blockBEntered.AddListener()
    }

    private void OnTriggerEnter(Collider col) //This is the collider detection function
    {
        if (col.gameObject.tag == "BlockA") //If we collide with the game object tagged 'BlockA'
        {
            blockAEntered.Invoke(); //We invoke all registered callbacks of the blockAEntered Unity Event

        }
        else if(col.gameObject.tag == "BlockB") //If we collide with the game object tagged 'BlockB'
        {
            blockBEntered.Invoke(); //We invoke all registered callbacks of the blockBEntered Unity Event

        }
    }

    private void BlockASelected() //Method passed as the subscriber in the blockAEntered event
    {

        Debug.Log("Block A Entered"); //Console log used to inform developer that block A has entered whiteboard trigger space

    }


    private void BlockBSelected() //Method passed as the subscriber in the blockBEntered event
    {

        Debug.Log("Block B Entered"); //Console log used to inform developer that block B has entered whiteboard trigger space

    }
}
