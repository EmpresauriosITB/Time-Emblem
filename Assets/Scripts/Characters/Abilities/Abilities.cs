using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    
    public Stats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = ScriptableObject.CreateInstance<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    
}
