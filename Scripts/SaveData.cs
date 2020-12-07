using BreakInfinity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BreakInfinity.BigDouble;

[Serializable]
public class SaveData
{
    public bool isNewSave;
    public BigDouble wrath;
    #region Matter;
    public BigDouble[] matterUpgradeCost = new BigDouble[6];
    public BigDouble[] matterUpgradeProduction = new BigDouble[6];
    public double[] particleCosts = new double[9];
    public bool[] particleUnlocked = new bool[9];
    public BigDouble Matter;
    public BigDouble MatterPerSec;
    #endregion
    #region Antimatter
    public BigDouble antimatter;
    public BigDouble antimatterMulti;
    public BigDouble[] antiParticleCosts = new BigDouble[4];
    public bool[] antiParticleUnlocked = new bool[4];
    #endregion
    #region TGT
    public bool startedTGT;
    #endregion
    #region DGs
    public float[] dgCompletions = new float[5];
    public float[] dgMaxCompletions = new float[5];
    public bool[] isInDG = new bool[5];
    public BigDouble[] dgCompletionRequirment = new BigDouble[5];
    public bool mtAutoIsUnlocked;
    public bool particleAutoIsUnlocked;
    public bool tgtIsUnlocked;
    public int previousDG;
    #endregion

    public SaveData()
    {
        isNewSave = true;
        #region Matter
        matterUpgradeCost[0] = 10;
        matterUpgradeCost[1] = 100;
        matterUpgradeCost[2] = 1e4;
        matterUpgradeCost[3] = 1e6;
        matterUpgradeCost[4] = 1e8;
        matterUpgradeCost[5] = 1e10;
        matterUpgradeProduction[0] = 1;
        matterUpgradeProduction[1] = 10;
        matterUpgradeProduction[2] = 500;
        matterUpgradeProduction[3] = 5e3;
        matterUpgradeProduction[4] = 5.5e5;
        matterUpgradeProduction[5] = 1e8;
        particleCosts[0] = 100;
        particleCosts[1] = 101;
        particleCosts[2] = 1000;
        particleCosts[3] = 1e6;
        particleCosts[4] = 1e8;
        particleCosts[5] = 1e10;
        particleCosts[6] = 1e10;
        particleCosts[7] = 1e20;
        particleCosts[8] = 1e30;

        for (var i = 0; i < particleUnlocked.Length; i++)
        {
            particleUnlocked[i] = false;
        }

        Matter = 10;
        MatterPerSec = 0;
        #endregion
        #region Antimatter
        //All APs Cost Antimatter
        antiParticleCosts[0] = 1;
        antiParticleCosts[1] = 10;
        antiParticleCosts[2] = 500;
        antiParticleCosts[3] = 2000;
        for (var i = 0; i < antiParticleUnlocked.Length; i++)
        {
            antiParticleUnlocked[i] = false;
        }
        antimatter = 0;
        antimatterMulti = 1;
        #endregion
        #region TGT
        startedTGT = false;
        #endregion
        #region DGs
        for (var i = 0; i < dgCompletions.Length; i++)
        {
            dgCompletions[i] = 0;
        }
        dgMaxCompletions[0] = 1;
        dgMaxCompletions[1] = 1;
        dgMaxCompletions[2] = 20;
        dgMaxCompletions[3] = 5;
        dgMaxCompletions[4] = 1;
        dgCompletionRequirment[0] = 1e15;
        dgCompletionRequirment[1] = 1e10;
        dgCompletionRequirment[2] = 1e20;
        dgCompletionRequirment[3] = 1e10;
        dgCompletionRequirment[4] = 1e8;   
        for (var i = 0; i < isInDG.Length; i++)
        {
            isInDG[i] = false;
        }
        mtAutoIsUnlocked = false;
        particleAutoIsUnlocked = false;
        tgtIsUnlocked = false;
        previousDG = 6; //setting to six is the same as setting it to "no challenge"
        #endregion 
    }
}