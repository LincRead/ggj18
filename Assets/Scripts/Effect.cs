using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {

    GameObject parent = null;

    void Start()
    {

    }

    void Update()
    {

        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("done"))
        {
            Destroy(gameObject);
        }

        if (parent)
        {
            transform.position = parent.GetComponent<Transform>().position;
        }
    }

    public void FollowParent(GameObject parentCreator)
    {
        parent = parentCreator;
    }
}