using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BurnDebuff")]
public class BurnDebuff : BuffAndDebuff {

    public int burnDamage;

    public override void effect() {
        target.currentHp -= burnDamage;
    }

    protected override void ResetEffect() {}
}
