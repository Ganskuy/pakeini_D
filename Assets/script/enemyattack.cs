using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform firepoint;
    public GameObject batuprefab;
    public bool isAttacking1 = false;
    public musuhtb playercontroller;

    public void Attack()
    {
        Instantiate(batuprefab, firepoint.position, firepoint.rotation);
        isAttacking1 = true;

        if(playercontroller != null){
            playercontroller.EAttackanim();
        }
        else{
            Debug.LogError("gaada");
        }
        StartCoroutine(EEndAttack());
    }

    private IEnumerator EEndAttack(){
        yield return new WaitForSeconds(0.1f);
        isAttacking1 = false;
        if(playercontroller != null){
            playercontroller.EEndAttackanim();
        }
    }
}