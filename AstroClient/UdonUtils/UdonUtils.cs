/*
 * Copyright (c) 2021 HookedBehemoth
 *
 * This program is free software; you can redistribute it and/or modify it
 * under the terms and conditions of the GNU General Public License,
 * version 3, as published by the Free Software Foundation.
 *
 * This program is distributed in the hope it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 * FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for
 * more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System.Reflection;
using AstroClient.ClientActions;
using AstroClient.xAstroBoy.Patching;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;
using static UnhollowerRuntimeLib.ClassInjector;

namespace AstroClient.UdonUtils {
    internal class UdonUtils_Starter : AstroEvents {

        internal override void RegisterToEvents()
        {
            ClientEventActions.OnApplicationStart += OnApplicationStart;
            ClientEventActions.OnSceneWasUnloaded += OnSceneWasUnloaded;
        }

        internal override void ExecutePriorityPatches()
        {
            var prefix = new HarmonyLib.HarmonyMethod(typeof(FakeUdon.Injector).GetMethod("InitializeUdonContentInjected", BindingFlags.NonPublic | BindingFlags.Static));
            var postfix = new HarmonyLib.HarmonyMethod(typeof(UdonUtils_Starter).GetMethod(nameof(OnUdonBehaviourLoaded), BindingFlags.NonPublic | BindingFlags.Static));
            new AstroPatch(typeof(VRC.Udon.UdonBehaviour).GetMethod("InitializeUdonContent", BindingFlags.Public | BindingFlags.Instance), prefix, postfix);
        }



        internal static void OnApplicationStart() 
        {
            RegisterTypeInIl2CppWithInterfaces<FakeUdon.FakeUdonProgram>(true, typeof(IUdonProgram));
            RegisterTypeInIl2CppWithInterfaces<FakeUdon.FakeUdonVM>(true, typeof(IUdonVM));
            RegisterTypeInIl2CppWithInterfaces<FakeUdon.FakeUdonHeap>(true, typeof(IUdonHeap));

        }



        internal void OnSceneWasUnloaded(int buildIndex, string sceneName) {
            if (buildIndex == -1)
                FakeUdon.Injector.ClearBehaviours();
        }

        private static void OnUdonBehaviourLoaded(UdonBehaviour __instance)
            => ClientEventActions.Udon_OnBehaviourLoaded?.SafetyRaiseWithParams(__instance);
    }
}
