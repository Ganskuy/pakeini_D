using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    private MeshRenderer mr;
    public float animationspeed;

    private void Awake(){
        mr = GetComponent<MeshRenderer>();
    }
    
    private void Update(){
        mr.material.mainTextureOffset += new Vector2(animationspeed*Time.deltaTime, 0);
    }
}
