﻿using System.Security;
using System.Security.Permissions;
using BepInEx;
using BepInEx.Configuration;
using RiskOfOptions.Options;
using RiskOfOptions.Resources;

#pragma warning disable CS0618 // Type or member is obsolete
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
#pragma warning restore CS0618 // Type or member is obsolete
[module: UnverifiableCode]

namespace RiskOfOptions;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public sealed class RiskOfOptionsPlugin : BaseUnityPlugin
{
    internal static ConfigEntry<bool>? seenNoMods;
    internal static ConfigEntry<bool>? seenMods;

    public static ConfigEntry<DecimalSeparator>? decimalSeparator;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Code Quality", "IDE0051:Remove unused private members", Justification = "Awake is automatically called by Unity")]
    private void Awake()
    {
        seenNoMods = Config.Bind("One Time Stuff", "Has seen the no mods prompt", false);
        seenMods = Config.Bind("One Time Stuff", "Has seen the mods prompt", false);
        
        decimalSeparator = Config.Bind("Display", "DecimalSeparator", DecimalSeparator.Period, "Changes how numbers are displayed across RoO.\nPeriod: 1,000.00\nComma: 1.000,00");

        ModSettingsManager.Init();
        
        ModSettingsManager.SetModIcon(Prefabs.animatedIcon);
        ModSettingsManager.AddOption(new ChoiceOption(decimalSeparator));
    }
}