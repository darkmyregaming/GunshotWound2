﻿using GunshotWound2.Components.HitComponents.WeaponHitComponents;

namespace GunshotWound2.Systems.DamageSystems
{
    public class HighCaliberDamageSystem : BaseGunDamageSystem<HighCaliberHitComponent>
    {
        public override void Initialize()
        {
            WeaponClass = "HighCaliber";

            GrazeWoundWeight = 1;
            FleshWoundWeight = 1;
            PenetratingWoundWeight = 3;
            PerforatingWoundWeight = 2;
            AvulsiveWoundWeight = 4;
            
            DamageMultiplier = 1.3f;
            BleeedingMultiplier = 1.5f;
            PainMultiplier = 2f;

            HelmetSafeChance = 0.05f;
            ArmorDamage = 15;
            CanPenetrateArmor = true;
            CritChance = 0.9f;
            
            LoadMultsFromConfig();
            FillWithDefaultGunActions();
        }
    }
}