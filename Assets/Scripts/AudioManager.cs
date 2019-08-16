using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static FMOD.Studio.EventInstance ReEnergiseScore;
    public static FMOD.Studio.EventInstance AtmosSpace;
    public static FMOD.Studio.EventInstance BossDefeated_01;
    public static FMOD.Studio.EventInstance BossEnergyChargeUp_01, BossEnergyChargeUp_02, BossEnergyChargeUp_03;
    public static FMOD.Studio.EventInstance BossFiringEnergy_01;
    public static FMOD.Studio.EventInstance BossHit_01, BossHit_02;
    public static FMOD.Studio.EventInstance BossHum_01, BossHum_02, BossHum_03, BossHum_04;
    public static FMOD.Studio.EventInstance ChargeUp_01, ChargeUp_02;
    public static FMOD.Studio.EventInstance EnergyBalls_Idle_01;
    public static FMOD.Studio.EventInstance FiringBlast_01;
    public static FMOD.Studio.EventInstance GeneratingShield_01, GeneratingShield_02;
    public static FMOD.Studio.EventInstance Ping_01, Ping_02, Ping_03;
    public static FMOD.Studio.EventInstance PingOnly_01, PingOnly_02, PingOnly_03;
    public static FMOD.Studio.EventInstance PlayerCollision_01;
    public static FMOD.Studio.EventInstance ShieldHum;
    public static FMOD.Studio.EventInstance ShieldBlock_09;

    public static float gameProgression = 0f;

    public static FMOD.Studio.ParameterInstance gamePhase;

    static AudioManager instance = null;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        BossDefeated_01 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/BossDefeated_01");
        BossEnergyChargeUp_01 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/BossEnergyChargeUp_01");
        BossEnergyChargeUp_02 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/BossEnergyChargeUp_02");
        BossEnergyChargeUp_03 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/BossEnergyChargeUp_03");
        BossFiringEnergy_01 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/BossFiringEnergy_01");
        BossHit_01 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/BossHit_01");
        BossHit_02 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/BossHit_02");
        BossHum_01 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/BossHum_01");
        BossHum_02 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/BossHum_02");
        BossHum_03 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/BossHum_03");
        BossHum_04 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/BossHum_04");
        ChargeUp_01 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/ChargeUp_01");
        ChargeUp_02 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/ChargeUp_02");
        EnergyBalls_Idle_01 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/EnergyBalls_Idle_01");
        FiringBlast_01 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/FiringBlast_01");
        GeneratingShield_01 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/GeneratingShield_01");
        GeneratingShield_02 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/GeneratingShield_02");
        Ping_01 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Ping_01");
        Ping_02 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Ping_02");
        Ping_03 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Ping_03");
        PingOnly_01 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/PingOnly_01");
        PingOnly_02 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/PingOnly_02");
        PingOnly_03 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/PingOnly_03");
        PlayerCollision_01 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/PlayerCollision_01");
        ShieldHum = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/ShieldHum");
        ShieldBlock_09 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/ShieldBlock_09");

        ReEnergiseScore = FMODUnity.RuntimeManager.CreateInstance("event:/Score/ReEnergiseScore");

        AtmosSpace = FMODUnity.RuntimeManager.CreateInstance("event:/Atmos/AtmosSpace");

        ReEnergiseScore.getParameter("gamePhase", out gamePhase);

        ReEnergiseScore.start();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gamePhase.setValue(gameProgression);
    }

    public static void Playsound(string clip)
    {
        switch (clip) { case ("BossDefeated_01"): BossDefeated_01.start(); break; }
        switch (clip) { case ("BossEnergyChargeUp_01"): BossEnergyChargeUp_01.start(); break; }
        switch (clip) { case ("BossEnergyChargeUp_02"): BossEnergyChargeUp_02.start(); break; }
        switch (clip) { case ("BossEnergyChargeUp_03"): BossEnergyChargeUp_03.start(); break; }
        switch (clip) { case ("BossFiringEnergy_01"): BossFiringEnergy_01.start(); break; }
        switch (clip) { case ("BossHit_01"): BossHit_01.start(); break; }
        switch (clip) { case ("BossHit_02"): BossHit_02.start(); break; }
        switch (clip) { case ("BossHum_01"): BossHum_01.start(); break; }
        switch (clip) { case ("BossHum_02"): BossHum_02.start(); break; }
        switch (clip) { case ("BossHum_03"): BossHum_03.start(); break; }
        switch (clip) { case ("BossHum_04"): BossHum_04.start(); break; }
        switch (clip) { case ("ChargeUp_01"): ChargeUp_01.start(); break; }
        switch (clip) { case ("ChargeUp_02"): ChargeUp_02.start(); break; }
        switch (clip) { case ("EnergyBalls_Idle_01"): EnergyBalls_Idle_01.start(); break; }
        switch (clip) { case ("FiringBlast_01"): FiringBlast_01.start(); break; }
        switch (clip) { case ("GeneratingShield_01"): GeneratingShield_01.start(); break; }
        switch (clip) { case ("GeneratingShield_02"): GeneratingShield_02.start(); break; }
        switch (clip) { case ("Ping_01"): Ping_01.start(); break; }
        switch (clip) { case ("Ping_02"): Ping_02.start(); break; }
        switch (clip) { case ("Ping_03"): Ping_03.start(); break; }
        switch (clip) { case ("PingOnly_01"): PingOnly_01.start(); break; }
        switch (clip) { case ("PingOnly_02"): PingOnly_02.start(); break; }
        switch (clip) { case ("PingOnly_03"): PingOnly_03.start(); break; }
        switch (clip) { case ("PlayerCollision_01"): PlayerCollision_01.start(); break; }
        switch (clip) { case ("ShieldHum"): ShieldHum.start(); break; }
        switch (clip) { case ("ShieldBlock_09"): ShieldBlock_09.start(); break; }

        switch (clip) { case ("ReEnergiseScore"): ReEnergiseScore.start(); break; }
        switch (clip) { case ("ReEnergiseScoreStop"): ReEnergiseScore.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT); break; }

        switch (clip) { case ("AtmosSpace"): AtmosSpace.start(); break; }
        switch (clip) { case ("AtmosSpaceStop"): AtmosSpace.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT); break; }
    }

}
