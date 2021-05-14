using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCommon : MonoBehaviour
{
    public enum AbiltiesId {
        Example
    }

    public static Abilities[] abilitiesReference =
    {
        new AbilityExample()
    };
}
