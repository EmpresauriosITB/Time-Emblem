using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MultiplayerAttributeBuff")]
public class MultiplayerAttributeBuff : BuffAndDebuff {
    public bool isPositive;
    public bool isMultiplayerEffect;
    public enum StatToModify {pp, pd, mp, md, gs, vel}
    public StatToModify statToModify;
    public int multiplayer;
    private bool alreadyEffected = false;

    public override void effect() {
        if (!alreadyEffected) {
            CheckStatToModify(isPositive);
            alreadyEffected = true;
        }
    }

    protected override void ResetEffect() {
        CheckStatToModify(!isPositive);
    }

    private void CheckStatToModify(bool isBuff) {
        switch (statToModify) {
            case StatToModify.pp:
                target.currentPhysicalPower = ModifyStat(target.currentPhysicalPower, isBuff);
                break;
            case StatToModify.pd:
                target.currentPhysicalDefense = ModifyStat(target.currentPhysicalDefense, isBuff);
                break;
            case StatToModify.mp:
                target.currentMentalPower = ModifyStat(target.currentMentalPower, isBuff);
                break;
            case StatToModify.md:
                target.currentMentalDefense = ModifyStat(target.currentMentalDefense, isBuff);
                break;
            case StatToModify.gs:
                target.currentGridSpeed = ModifyStat(target.currentGridSpeed, isBuff);
                break;
            case StatToModify.vel:
                target.currentVelocity = ModifyStat(target.currentVelocity, isBuff);
                break;
        }
    }

    private int ModifyStat(int stat, bool isBuff) {
        if (isMultiplayerEffect) {
            if (isBuff) { return stat * multiplayer; }
            else { return stat / multiplayer; }
        } else {
            if (isBuff) { return stat + multiplayer; }
            else {
                if ((stat - multiplayer) == 0) { return 1; }
                else { return stat - multiplayer; }
            }
        }
    }

    
}
