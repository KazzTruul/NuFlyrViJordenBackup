using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class guard : MonoBehaviour
{
    [YarnCommand("Guard")]
    public void Guard()
    {
        gameObject.transform.Translate(Vector3.forward * 0.3f + Vector3.right);
    }

}
