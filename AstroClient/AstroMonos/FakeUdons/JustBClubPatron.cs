using AstroClient.AstroMonos.Components.Spoofer;
using AstroClient.UdonUtils.FakeUdon;
using AstroClient.UdonUtils.UdonSharp;
using VRC.Udon;

namespace AstroClient.AstroMonos.FakeUdons
{
    /*
     * Copyright (c) 2023 HookedBehemoth
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

    namespace JustBPatreon
    {
        internal class Register_JustBClub1_2_Patron : AstroEvents
        {
            // TODO : turn this into a attribute, to speed things up.
            internal override void ExecutePriorityPatches()
            {
                FakeUdonRegistry.RegisterType<AvatarImageReader.JustBClub_1_2_RuntimeDecoder>(new JustBClib_1_2_PatreonMatcher());
            }
        }
    }

    internal class JustBClib_1_2_PatreonMatcher : UdonMatcher
    {
        public bool Match(UdonBehaviour behaviour)
        {
            if (behaviour.publicVariables.TryGetVariableValue("callbackEventName", out Il2CppSystem.Object value))
            {
                return ((string)new Il2CppSystem.String(value.Pointer)) == "_ProcessPatrons";
            }

            //if (WorldUtils.WorldID == WorldIds.JustBClub || WorldUtils.WorldID == WorldIds.JustBClub2 || WorldUtils.WorldID == WorldIds.JustBClub2Lobby)
            //{
            //}
            return false;
        }
    }

    namespace AvatarImageReader
    {
        internal class JustBClub_1_2_RuntimeDecoder : UdonSharpBehaviour
        {
            public string CurrentDisplayName
            {
                get
                {
                    return PlayerSpooferUtils.Original_DisplayName;
                }
            }

            private void Start()
            {
                Log.Write("Decoder Start");
                SendCustomEventDelayedFrames("ReadPatreons", 300);
            }

            public string outputString;
            public UdonBehaviour callbackBehaviour;
            public string callbackEventName;

            public void ReadPatreons()
            {
                Log.Write("Hijacking B Club Decoder ReadPatreons...");
                var name = CurrentDisplayName;
                outputString = name + "@721001760931446784,\n\r";
                outputString += name + "@undefined,\n\r";
                outputString += name + ",\n\r";
                outputString += ",\n\r";
                outputString += name + ",\n\r";
                outputString += name + ",\n\r";
                outputString += name + "@218209759424151552,\n\r";
                outputString += ",\n\r";
                outputString += name + "\n\r";
                callbackBehaviour.SendCustomEvent(callbackEventName);
            }
        }
    }
}