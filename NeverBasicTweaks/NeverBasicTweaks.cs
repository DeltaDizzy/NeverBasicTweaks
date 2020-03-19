using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NeverBasicTweaks
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class NeverBasicTweaks : MonoBehaviour
    {
        ConfigNode node;
        public bool advTweaks = true;
        public bool dblClickLook = true;

        void Start()
        {
            LoadSettings();
            Debug.Log("[NBT] Plugin Initialized");
            if (!GameSettings.ADVANCED_TWEAKABLES)
            {
                Debug.Log("[NBT] Advanced Tweakables Disabled, Enabling...");
                GameSettings.ADVANCED_TWEAKABLES = true;
            }
            if (!GameSettings.CAMERA_DOUBLECLICK_MOUSELOOK && !Environment.GetCommandLineArgs().Contains("-no-mouse-look"))
            {
                Debug.Log("[NBT] Double-Click Mouse Look Disabled, Enabling...");
                GameSettings.CAMERA_DOUBLECLICK_MOUSELOOK = true;
            }
            GameSettings.ApplySettings();
            GameSettings.SaveSettings();
            Debug.Log("[NBT] Advanced Tweakables Enabled, Have a Nice Day");
            Debug.Log("[NBT] Double-Click Mouse Look Enabled, Have a Nice Day");
        }

        void LoadSettings()
        {
            node = ConfigNode.Load(KSPUtil.ApplicationRootPath + "GameData/NeverBasicTweaks/settings.cfg");
            advTweaks = bool.Parse(node.GetValue("advTweaks"));
            dblClickLook = bool.Parse(node.GetValue("doubleClickLook"));
        }

        void SaveSettings()
        {
            node = new ConfigNode("NEVER_BASIC_TWEAKS");
            node.AddValue("advtweaks", advTweaks);
            node.AddValue("doubleClickLook", dblClickLook);
            node.Save(KSPUtil.ApplicationRootPath + "GameData/NeverBasicTweaks/settings.cfg");
        }
    }
}
