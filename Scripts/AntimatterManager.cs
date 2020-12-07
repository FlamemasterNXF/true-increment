using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static BreakInfinity.BigDouble;
public class AntimatterManager : MonoBehaviour
{
    public PersistentMain game;
    public UpgradeManager UM;
    public Text antimatterText;
    public Text antimatterMultiText;
    public Text[] antiParticleTexts = new Text[4];
    public Text antimatterGainText;
    public GameObject apocalypseButton;
    void Start()
    {
        var data = game.data;
        for (var i = 0; i < antiParticleTexts.Length; i++)
        {
            antiParticleTexts[i].text = $"Requires {Methods.NotationMethodBD(data.antiParticleCosts[i], y: "F2")} AnTiMaTtEr";
        }
        apocalypseButton.SetActive(false);
    }

    void Update()
    {
        var data = game.data;
        var sqr = Sqrt(data.Matter / 1e8);
        var notation = Methods.NotationMethodBD(sqr, y: "F2");
        antimatterGainText.text = $"GAIN +{notation} GAMEING ANTIMATTER";
        //antimatterGainText.text = $"GAIN +{Methods.NotationMethodBD((Sqrt(data.Matter / 1e8)), y: "F2")} GAMEING ANTIMATTER";
        antimatterText.text = $"{Methods.NotationMethodBD(data.antimatter, y: "F2")} GAMEING ANTIMATTER";
        antimatterMultiText.text = $"Your AnTiMaTtEr is multipling your Matter by {Methods.NotationMethodBD(data.antimatterMulti, y: "F2")}x! Swag!";
        if (game.data.Matter >= 1e8)
        {
            apocalypseButton.SetActive(true);
        }
        else
            apocalypseButton.SetActive(false);
    }

    public void AntimatterReset()
    {
        var data = game.data;

        data.antimatter += Sqrt(data.Matter / 1e8);
        if (game.data.antiParticleUnlocked[2])
        {
            data.antimatterMulti = data.antimatter * 1.005;
        }
        else
            data.antimatterMulti = data.antimatter * 1.001;
        data.matterUpgradeCost[0] = 10;
        data.matterUpgradeCost[1] = 100;
        data.matterUpgradeCost[2] = 1e4;
        data.matterUpgradeCost[3] = 1e6;
        data.matterUpgradeCost[4] = 1e8;
        data.matterUpgradeCost[5] = 1e10;
        data.matterUpgradeProduction[0] = 1;
        data.matterUpgradeProduction[1] = 10;
        data.matterUpgradeProduction[2] = 500;
        data.matterUpgradeProduction[3] = 5e3;
        data.matterUpgradeProduction[4] = 5.5e5;
        data.matterUpgradeProduction[5] = 1e8;

        if (!game.data.antiParticleUnlocked[3])
        {
            data.particleCosts[0] = 100;
            data.particleCosts[1] = 101;
            data.particleCosts[2] = 1000;
            data.particleCosts[3] = 1e6;
            data.particleCosts[4] = 1e8;
            data.particleCosts[5] = 1e10;
            data.particleCosts[6] = 1e10;
            data.particleCosts[7] = 1e20;
            data.particleCosts[8] = 1e30;

            for (var i = 0; i < data.particleUnlocked.Length; i++)
            {
                data.particleUnlocked[i] = false;
            }
        }

        data.Matter = 10;
        data.MatterPerSec = 0;

        for (var i = 0; i < UM.matterCostTexts.Length; i++)
        {
            UM.matterCostTexts[i].text = $"Costs: {Methods.NotationMethodBD(game.data.matterUpgradeCost[i], y: "F2")}";
        }

        for (var i = 0; i < UM.matterProductionTexts.Length && i < game.data.matterUpgradeProduction.Length; i++)
        {
            UM.matterProductionTexts[i].text = $"Gain +{Methods.NotationMethodBD(game.data.matterUpgradeProduction[i], y: "F2")} Matter/s";
        }

        for (var i = 0; i < UM.particleTexts.Length; i++)
        {
            UM.particleTexts[i].text = $"Cost {Methods.NotationMethodBD(game.data.particleCosts[i], y: "F2")} Matter";
        }
    }

    public void BuyAntiParticle(int PID)
    {
        //DG Control
        var data = game.data;
        if (data.isInDG[0] || data.isInDG[1]) return;
        //end
        if (game.data.antimatter < game.data.antiParticleCosts[PID - 1]) return;
        game.data.Matter -= game.data.antiParticleCosts[PID - 1];
        game.data.antiParticleUnlocked[PID - 1] = true;
        antiParticleTexts[PID - 1].text = "UNLOCKED!";
    }
}
