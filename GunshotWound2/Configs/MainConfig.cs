﻿using System.Windows.Forms;

namespace GunshotWound2.Configs
{
    public class MainConfig
    {
        public int TicksToRefresh;

        public WoundConfig WoundConfig;
        public NpcConfig NpcConfig;
        public PlayerConfig PlayerConfig;
        
        public Keys? HelmetKey;
        public Keys? CheckKey;
        public Keys? HealKey;

        public bool CommonMessages = true;
        public bool WarningMessages = true;
        public bool AlertMessages = true;
        public bool EmergencyMessages = true;

        public override string ToString()
        {
            return $"{WoundConfig}\n" +
                   $"{NpcConfig}\n" +
                   $"{PlayerConfig}";
        }
    }
}