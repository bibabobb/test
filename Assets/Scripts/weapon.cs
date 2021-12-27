using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    // Start is called before the first frame update

    public string weaponName;
    public enum weaponType { Invalid, Axe, Sword, Hammer, Dagger, MagicProjectile, Touch, Bow };

    public weaponType weaponT;
    public int attackPower;
    public float attackRange;
    public string description;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
