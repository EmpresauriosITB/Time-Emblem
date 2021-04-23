using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPassiveCommon : MonoBehaviour
{
    public enum SpecialPassiveId {
        Example
    }

    public static SpecialPassive[] specialPassiveReference =  {
        new ExampleSpecialPassive()
    };
}
