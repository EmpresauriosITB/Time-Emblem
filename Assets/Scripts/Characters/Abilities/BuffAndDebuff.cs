using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BuffAndDebuff : ScriptableObject {
    public bool lastsInTime;
    public int activeSeconds;
    public int actionPeriod;

    private int actionPeriodCount;
    private int activeSecondsCount;
    protected CharacterUnitController target;

    public int activationPorcentage;

    public abstract void effect();

    public bool checkEffectTime() {
        if (lastsInTime && activeSeconds > Time.time) {
            if (actionPeriodCount > Time.time) {
                effect();
                actionPeriodCount = (int) (Time.time + actionPeriod);
            }
            return true;
        }
        ResetEffect();
        return false;
    }

    public void Init(CharacterUnitController controller) {
        target = controller;
        activeSecondsCount = (int)Time.time + activeSeconds;
        actionPeriodCount = (int)(Time.time + actionPeriod);

        effect();
    }

    protected abstract void ResetEffect();
}
