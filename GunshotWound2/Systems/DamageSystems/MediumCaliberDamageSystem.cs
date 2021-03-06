﻿using GunshotWound2.Components.HitComponents.WeaponHitComponents;
using Leopotam.Ecs;

namespace GunshotWound2.Systems.DamageSystems
{
    [EcsInject]
    public class MediumCaliberDamageSystem : BaseGunDamageSystem<MediumCaliberHitComponent>
    {
        public override void Initialize()
        {
            WeaponClass = "MediumCaliber";

            GrazeWoundWeight = 1;
            FleshWoundWeight = 2;
            PenetratingWoundWeight = 4;
            PerforatingWoundWeight = 6;
            AvulsiveWoundWeight = 2;
            
            DamageMultiplier = 1.2f;
            BleeedingMultiplier = 1.3f;
            PainMultiplier = 1.5f;

            HelmetSafeChance = 0.3f;
            ArmorDamage = 10;
            CanPenetrateArmor = true;
            CritChance = 0.7f;
            
            LoadMultsFromConfig();
            FillWithDefaultGunActions();
        }
    }
}