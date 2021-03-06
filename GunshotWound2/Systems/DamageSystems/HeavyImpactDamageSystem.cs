﻿using System;
using GunshotWound2.Components.HitComponents.WeaponHitComponents;
using GunshotWound2.Components.WoundComponents;
using Leopotam.Ecs;
using Weighted_Randomizer;

namespace GunshotWound2.Systems.DamageSystems
{
    [EcsInject]
    public class HeavyImpactDamageSystem : BaseImpactDamageSystem<HeavyImpactHitComponent>
    {
        public override void Initialize()
        {
            WeaponClass = "HeavyImpact";

            HelmetSafeChance = 0.8f;
            ArmorDamage = 0;

            CritChance = 0.7f;
            
            DefaultAction = DefaultGrazeWound;
            
            HeadActions = new StaticWeightedRandomizer<Action<int>>
            {
                {HeadCase1, 2},
                {HeadCase2, 2},
                {HeadCase3, 1},
            };
            
            NeckActions = new StaticWeightedRandomizer<Action<int>>
            {
                {NeckCase1, 2},
                {NeckCase2, 2},
                {NeckCase3, 1},
            };
            
            UpperBodyActions = new StaticWeightedRandomizer<Action<int>>
            {
                {UpperCase1, 2},
                {UpperCase2, 2},
                {UpperCase3, 1},
            };
            
            LowerBodyActions = new StaticWeightedRandomizer<Action<int>>
            {
                {LowerCase1, 2},
                {LowerCase2, 2},
                {LowerCase3, 1},
            };
            
            ArmActions = new StaticWeightedRandomizer<Action<int>>
            {
                {ArmCase1, 2},
                {ArmCase2, 2},
                {ArmCase3, 1},
            };
            
            LegActions = new StaticWeightedRandomizer<Action<int>>
            {
                {LegCase1, 2},
                {LegCase2, 2},
                {LegCase3, 1},
            };
            
            LoadMultsFromConfig();
        }
        
        

        private void Blackout(int entity)
        {
            CreateWound("Blackout possible", entity, DamageMultiplier * 50f, 0f, PainMultiplier * 70f);
        }

        private void HeavyBrainDamage(int entity)
        {
            CreateWound("Bleeding in the head", entity, DamageMultiplier * 70f, 
                BleeedingMultiplier * 3f, PainMultiplier * 70f);
        }

        private void BrainInjury(int entity)
        {
            CreateWound("Traumatic brain injury", entity, DamageMultiplier * 80f,
                BleeedingMultiplier * 3f, PainMultiplier * 70f);
        }
        
        private void BrokenNeck(int entity)
        {
            CreateWound("Broken neck", entity, DamageMultiplier * 50f,
                0f, 0f, 50f, DamageTypes.NERVES_DAMAGED);
        }
        
        

        private void HeadCase1(int entity)
        {
            HeavyBruiseWound("head", entity);
        }

        private void HeadCase2(int entity)
        {
            Blackout(entity);
        }

        private void HeadCase3(int entity)
        {
            BrainInjury(entity);
        }

        

        private void NeckCase1(int entity)
        {
            MediumBruiseWound("neck", entity);
        }

        private void NeckCase2(int entity)
        {
            HeavyBruiseWound("neck", entity);
        }

        private void NeckCase3(int entity)
        {
            BrokenNeck(entity);
        }



        private void UpperCase1(int entity)
        {
            AbrasionWoundOn("upper body", entity);
        }

        private void UpperCase2(int entity)
        {
            MediumBruiseWound("upper body", entity);
        }

        private void UpperCase3(int entity)
        {
            HeavyBruiseWound("upper body", entity, DamageTypes.LUNGS_DAMAGED, DamageTypes.HEART_DAMAGED);
        }

        

        private void LowerCase1(int entity)
        {
            AbrasionWoundOn("lower body", entity);
        }

        private void LowerCase2(int entity)
        {
            MediumBruiseWound("lower body", entity);
        }

        private void LowerCase3(int entity)
        {
            HeavyBruiseWound("lower body", entity, DamageTypes.STOMACH_DAMAGED, DamageTypes.GUTS_DAMAGED);
        }



        private void ArmCase1(int entity)
        {
            AbrasionWoundOn("arm", entity);
        }

        private void ArmCase2(int entity)
        {
            MediumBruiseWound("arm", entity);
        }

        private void ArmCase3(int entity)
        {
            HeavyBruiseWound("arm", entity, DamageTypes.ARMS_DAMAGED);
        }



        private void LegCase1(int entity)
        {
            AbrasionWoundOn("leg", entity);
        }

        private void LegCase2(int entity)
        {
            MediumBruiseWound("leg", entity);
        }

        private void LegCase3(int entity)
        {
            HeavyBruiseWound("leg", entity, DamageTypes.LEGS_DAMAGED);
        }
    }
}