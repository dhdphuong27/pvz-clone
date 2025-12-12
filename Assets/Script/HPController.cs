using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HPController : MonoBehaviour
{
    public int HP;

    public void ReceiveDamage(int DMG)
    {
        if (HP - DMG <= 0)
        {
            this.gameObject.transform.parent.gameObject.GetComponent<ObjectContainer>().isFull = false;
            Destroy(this.gameObject); 
            AudioManager.Play("gulp");
        }
        else
        {
            HP = HP - DMG;
        }
    }
    public void Shoveled()
    {
        this.gameObject.transform.parent.gameObject.GetComponent<ObjectContainer>().isFull = false;
        Destroy(this.gameObject); 
    }
}
