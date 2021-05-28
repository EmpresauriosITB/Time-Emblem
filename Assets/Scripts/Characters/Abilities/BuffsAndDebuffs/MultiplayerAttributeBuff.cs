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
                target.character.currentPhysicalPower = ModifyStat(target.character.currentPhysicalPower, isBuff);
                break;
            case StatToModify.pd:
                target.character.currentPhysicalDefense = ModifyStat(target.character.currentPhysicalDefense, isBuff);
                break;
            case StatToModify.mp:
                target.character.currentMentalPower = ModifyStat(target.character.currentMentalPower, isBuff);
                break;
            case StatToModify.md:
                target.character.currentMentalDefense = ModifyStat(target.character.currentMentalDefense, isBuff);
                break;
            case StatToModify.gs:
                target.character.currentGridSpeed = ModifyStat(target.character.currentGridSpeed, isBuff);
                break;
            case StatToModify.vel:
                target.character.currentVelocity = ModifyStat(target.character.currentVelocity, isBuff);
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
