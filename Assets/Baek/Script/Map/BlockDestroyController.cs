using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockDestroyController : MonoBehaviour
{

    // Start is called before the first frame update


    void Start()
    {
        Destroy(gameObject, 2f);
    }

}
