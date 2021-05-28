using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ResetCooldownDebuff")]
public class ResetCooldownDebuff : BuffAndDebuff {

    public override void effect() {
        target.timeToNextActivePeriod = Time.time + target.character.currentVelocity;
    }

    protected override void ResetEffect() {}
}
