﻿namespace AstroClient.Components
{
    using VRC.Udon.ProgramSources;

    internal class UdonPrograms
    {
        private static string InteractTriggerIdentifier = "VRC_AstroInteract";
        private static string PickupIdentifier = "VRC_AstroPickup";



        // Good For buttons and such.
        private static SerializedUdonProgramAsset _InteractProgram;
        internal static SerializedUdonProgramAsset InteractProgram
        {
            get
            {
                if (_InteractProgram != null)
                {
                    return _InteractProgram;
                }
                else
                {
                    var program = new SerializedUdonProgramAsset();
                    if (program != null)
                    {
                        program.serializedProgramBytesString = "Ai8AAAAAASwAAABWAFIAQwAuAFUAZABvAG4ALgBDAG8AbQBtAG8AbgAuAFUAZABvAG4AUAByAG8AZwByAGEAbQAsACAAVgBSAEMALgBVAGQAbwBuAC4AQwBvAG0AbQBvAG4AAAAAACcBGAAAAEkAbgBzAHQAcgB1AGMAdABpAG8AbgBTAGUAdABJAGQAZQBuAHQAaQBmAGkAZQByAAEEAAAAVQBEAE8ATgAXARUAAABJAG4AcwB0AHIAdQBjAHQAaQBvAG4AUwBlAHQAVgBlAHIAcwBpAG8AbgABAAAAAQEIAAAAQgB5AHQAZQBDAG8AZABlAC8BAAAAARcAAABTAHkAcwB0AGUAbQAuAEIAeQB0AGUAWwBdACwAIABtAHMAYwBvAHIAbABpAGIAAQAAAAhgAAAAAQAAAAAAAAEAAAAFAAAAAQAAAAQAAAABAAAAAgAAAAkAAAABAAAABgAAAAkAAAAIAAAABgAAAAEAAAAFAAAAAQAAAAMAAAABAAAAAgAAAAkAAAABAAAABgAAAAkAAAAIAAAABgUBAQQAAABIAGUAYQBwAC8CAAAAASkAAABWAFIAQwAuAFUAZABvAG4ALgBDAG8AbQBtAG8AbgAuAFUAZABvAG4ASABlAGEAcAAsACAAVgBSAEMALgBVAGQAbwBuAC4AQwBvAG0AbQBvAG4AAgAAAAYCAAAAAAAAACcBBAAAAHQAeQBwAGUAARcAAABTAHkAcwB0AGUAbQAuAFUASQBuAHQAMwAyACwAIABtAHMAYwBvAHIAbABpAGIAGQEMAAAASABlAGEAcABDAGEAcABhAGMAaQB0AHkABwAAACcBBAAAAHQAeQBwAGUAAbkAAABTAHkAcwB0AGUAbQAuAEMAbwBsAGwAZQBjAHQAaQBvAG4AcwAuAEcAZQBuAGUAcgBpAGMALgBMAGkAcwB0AGAAMQBbAFsAUwB5AHMAdABlAG0ALgBWAGEAbAB1AGUAVAB1AHAAbABlAGAAMwBbAFsAUwB5AHMAdABlAG0ALgBVAEkAbgB0ADMAMgAsACAAbQBzAGMAbwByAGwAaQBiAF0ALABbAFMAeQBzAHQAZQBtAC4AUgB1AG4AdABpAG0AZQAuAEMAbwBtAHAAaQBsAGUAcgBTAGUAcgB2AGkAYwBlAHMALgBJAFMAdAByAG8AbgBnAEIAbwB4ACwAIABTAHkAcwB0AGUAbQAuAEMAbwByAGUAXQAsAFsAUwB5AHMAdABlAG0ALgBUAHkAcABlACwAIABtAHMAYwBvAHIAbABpAGIAXQBdACwAIABtAHMAYwBvAHIAbABpAGIAXQBdACwAIABtAHMAYwBvAHIAbABpAGIAAQEIAAAASABlAGEAcABEAHUAbQBwAC8DAAAAAbkAAABTAHkAcwB0AGUAbQAuAEMAbwBsAGwAZQBjAHQAaQBvAG4AcwAuAEcAZQBuAGUAcgBpAGMALgBMAGkAcwB0AGAAMQBbAFsAUwB5AHMAdABlAG0ALgBWAGEAbAB1AGUAVAB1AHAAbABlAGAAMwBbAFsAUwB5AHMAdABlAG0ALgBVAEkAbgB0ADMAMgAsACAAbQBzAGMAbwByAGwAaQBiAF0ALABbAFMAeQBzAHQAZQBtAC4AUgB1AG4AdABpAG0AZQAuAEMAbwBtAHAAaQBsAGUAcgBTAGUAcgB2AGkAYwBlAHMALgBJAFMAdAByAG8AbgBnAEIAbwB4ACwAIABTAHkAcwB0AGUAbQAuAEMAbwByAGUAXQAsAFsAUwB5AHMAdABlAG0ALgBUAHkAcABlACwAIABtAHMAYwBvAHIAbABpAGIAXQBdACwAIABtAHMAYwBvAHIAbABpAGIAXQBdACwAIABtAHMAYwBvAHIAbABpAGIAAwAAAAYHAAAAAAAAAAQvBAAAAAGKAAAAUwB5AHMAdABlAG0ALgBWAGEAbAB1AGUAVAB1AHAAbABlAGAAMwBbAFsAUwB5AHMAdABlAG0ALgBVAEkAbgB0ADMAMgAsACAAbQBzAGMAbwByAGwAaQBiAF0ALABbAFMAeQBzAHQAZQBtAC4AUgB1AG4AdABpAG0AZQAuAEMAbwBtAHAAaQBsAGUAcgBTAGUAcgB2AGkAYwBlAHMALgBJAFMAdAByAG8AbgBnAEIAbwB4ACwAIABTAHkAcwB0AGUAbQAuAEMAbwByAGUAXQAsAFsAUwB5AHMAdABlAG0ALgBUAHkAcABlACwAIABtAHMAYwBvAHIAbABpAGIAXQBdACwAIABtAHMAYwBvAHIAbABpAGIAGQEFAAAASQB0AGUAbQAxAAAAAAABAQUAAABJAHQAZQBtADIALwUAAAABUgAAAFMAeQBzAHQAZQBtAC4AUgB1AG4AdABpAG0AZQAuAEMAbwBt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YQB0AGEAVABhAGIAbABlACwAIABWAFIAQwAuAFUAZABvAG4ALgBDAG8AbQBtAG8AbgAeAAAABgEAAAAAAAAAJwEEAAAAdAB5AHAAZQABbAAAAFMAeQBzAHQAZQBtAC4AQwBvAGwAbABlAGMAdABpAG8AbgBzAC4ARwBlAG4AZQByAGkAYwAuAEwAaQBzAHQAYAAxAFsAWwBWAFIAQwAuAFUAZABvAG4ALgBDAG8AbQBtAG8AbgAuAEkAbgB0AGUAcgBmAGEAYwBlAHMALgBJAFUAZABvAG4AUwB5AG4AYwBNAGUAdABhAGQAYQB0AGEALAAgAFYAUgBDAC4AVQBkAG8AbgAuAEMAbwBtAG0AbwBuAF0AXQAsACAAbQBzAGMAbwByAGwAaQBiAAEBDAAAAFMAeQBuAGMATQBlAHQAYQBkAGEAdABhAC8PAAAAAWwAAABTAHkAcwB0AGUAbQAuAEMAbwBsAGwAZQBjAHQAaQBvAG4AcwAuAEcAZQBuAGUAcgBpAGMALgBMAGkAcwB0AGAAMQBbAFsAVgBSAEMALgBVAGQAbwBuAC4AQwBvAG0AbQBvAG4ALgBJAG4AdABlAHIAZgBhAGMAZQBzAC4ASQBVAGQAbwBuAFMAeQBuAGMATQBlAHQAYQBkAGEAdABhACwAIABWAFIAQwAuAFUAZABvAG4ALgBDAG8AbQBtAG8AbgBdAF0ALAAgAG0AcwBjAG8AcgBsAGkAYgAfAAAABgAAAAAAAAAABwUHBRcBCwAAAFUAcABkAGEAdABlAE8AcgBkAGUAcgAAAAAABQ==";
                        program.name = InteractTriggerIdentifier; // use it as identifier.
                        program.serializationDataFormat = VRC.Udon.Serialization.OdinSerializer.DataFormat.Binary;
                        program.programUnityEngineObjects = new Il2CppSystem.Collections.Generic.List<UnityEngine.Object>();
                        return _InteractProgram = program;
                    }
                }
                return null;
            }
        }


        private static SerializedUdonProgramAsset _PickupProgram;
        internal static SerializedUdonProgramAsset PickupProgram
        {
            get
            {
                if (_PickupProgram != null)
                {
                    return _PickupProgram;
                }
                else
                {
                    var program = new SerializedUdonProgramAsset();
                    if (program != null)
                    {
                        program.serializedProgramBytesString = "Ai8AAAAAASwAAABWAFIAQwAuAFUAZABvAG4ALgBDAG8AbQBtAG8AbgAuAFUAZABvAG4AUAByAG8AZwByAGEAbQAsACAAVgBSAEMALgBVAGQAbwBuAC4AQwBvAG0AbQBvAG4AAAAAACcBGAAAAEkAbgBzAHQAcgB1AGMAdABpAG8AbgBTAGUAdABJAGQAZQBuAHQAaQBmAGkAZQByAAEEAAAAVQBEAE8ATgAXARUAAABJAG4AcwB0AHIAdQBjAHQAaQBvAG4AUwBlAHQAVgBlAHIAcwBpAG8AbgABAAAAAQEIAAAAQgB5AHQAZQBDAG8AZABlAC8BAAAAARcAAABTAHkAcwB0AGUAbQAuAEIAeQB0AGUAWwBdACwAIABtAHMAYwBvAHIAbABpAGIAAQAAAAhwAAAAAQAAAAAAAAEAAAAAAAAAAQAAAAYAAAAJAAAABf////wAAAABAAAAAQAAAAEAAAAFAAAACQAAAAX////8AAAAAQAAAAIAAAABAAAABwAAAAkAAAAF/////AAAAAEAAAADAAAAAQAAAAQAAAAJAAAABf////wFAQEEAAAASABlAGEAcAAvAgAAAAEpAAAAVgBSAEMALgBVAGQAbwBuAC4AQwBvAG0AbQBvAG4ALgBVAGQAbwBuAEgAZQBhAHAALAAgAFYAUgBDAC4AVQBkAG8AbgAuAEMAbwBtAG0AbwBuAAIAAAAGAgAAAAAAAAAnAQQAAAB0AHkAcABlAAEXAAAAUwB5AHMAdABlAG0ALgBVAEkAbgB0ADMAMgAsACAAbQBzAGMAbwByAGwAaQBiABkBDAAAAEgAZQBhAHAAQwBhAHAAYQBjAGkAdAB5AAACAAAnAQQAAAB0AHkAcABlAAG5AAAAUwB5AHMAdABlAG0ALgBDAG8AbABsAGUAYwB0AGkAbwBuAHMALgBHAGUAbgBlAHIAaQBjAC4ATABpAHMAdABgADEAWwBbAFMAeQBzAHQAZQBtAC4AVgBhAGwAdQBlAFQAdQBwAGwAZQBgADMAWwBbAFMAeQBzAHQAZQBtAC4AVQBJAG4AdAAzADIALAAgAG0AcwBjAG8AcgBsAGkAYgBdACwAWwBTAHkAcwB0AGUAbQAuAFIAdQBuAHQAaQBtAGUALgBDAG8AbQBwAGkAbABlAHIAUwBlAHIAdgBpAGMAZQBzAC4ASQBTAHQAcgBvAG4AZwBCAG8AeAAsACAAUwB5AHMAdABlAG0ALgBDAG8AcgBlAF0ALABbAFMAeQBzAHQAZQBtAC4AVAB5AHAAZQAsACAAbQBzAGMAbwByAGwAaQBiAF0AXQAsACAAbQBzAGMAbwByAGwAaQBiAF0AXQAsACAAbQBzAGMAbwByAGwAaQBiAAEBCAAAAEgAZQBhAHAARAB1AG0AcAAvAwAAAAG5AAAAUwB5AHMAdABlAG0ALgBDAG8AbABsAGUAYwB0AGkAbwBuAHMALgBHAGUAbgBlAHIAaQBjAC4ATABpAHMAdABgADEAWwBbAFMAeQBzAHQAZQBtAC4AVgBhAGwAdQBlAFQAdQBwAGwAZQBgADMAWwBbAFMAeQBzAHQAZQBtAC4AVQBJAG4AdAAzADIALAAgAG0AcwBjAG8AcgBsAGkAYgBdACwAWwBTAHkAcwB0AGUAbQAuAFIAdQBuAHQAaQBtAGUALgBDAG8AbQBwAGkAbABlAHIAUwBlAHIAdgBpAGMAZQBzAC4ASQBTAHQAcgBvAG4AZwBCAG8AeAAsACAAUwB5AHMAdABlAG0ALgBDAG8AcgBlAF0ALABbAFMAeQBzAHQAZQBtAC4AVAB5AHAAZQAsACAAbQBzAGMAbwByAGwAaQBiAF0AXQAsACAAbQBzAGMAbwByAGwAaQBiAF0AXQAsACAAbQBzAGMAbwByAGwAaQBiAAMAAAAGCQAAAAAAAAAELwQAAAABigAAAFMAeQBzAHQAZQBtAC4AVgBhAGwAdQBlAFQAdQBwAGwAZQBgADMAWwBbAFMAeQBzAHQAZQBtAC4AVQBJAG4AdAAzADIALAAgAG0AcwBjAG8AcgBsAGkAYgBdACwAWwBTAHkAcwB0AGUAbQAuAFIAdQBuAHQAaQBtAGUALgBDAG8AbQBwAGkAbABlAHIAUwBlAHIAdgBpAGMAZQBzAC4ASQBTAHQAcgBvAG4AZwBCAG8AeAAsACAAUwB5AHMAdABlAG0ALgBDAG8AcgBlAF0ALABbAFMAeQBzAHQAZQBtAC4AVAB5AHAAZQAsACAAbQBzAGMAbwByAGwAaQBiAF0AXQAsACAAbQBzAGMAbwByAGwAaQBiABkBBQAAAEkAdABlAG0AMQAAAAAAAQEFAAAASQB0AGUAbQAyAC8FAAAAAVQAAABTAHkAcwB0AGUAbQAuAFIAdQBu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YwAuAEwAaQBzAHQAYAAxAFsAWwBWAFIAQwAuAFUAZABvAG4ALgBDAG8AbQBtAG8AbgAuAEkAbgB0AGUAcgBmAGEAYwBlAHMALgBJAFUAZABvAG4AUwB5AG4AYwBNAGUAdABhAGQAYQB0AGEALAAgAFYAUgBDAC4AVQBkAG8AbgAuAEMAbwBtAG0AbwBuAF0AXQAsACAAbQBzAGMAbwByAGwAaQBiAAEBDAAAAFMAeQBuAGMATQBlAHQAYQBkAGEAdABhAC8MAAAAAWwAAABTAHkAcwB0AGUAbQAuAEMAbwBsAGwAZQBjAHQAaQBvAG4AcwAuAEcAZQBuAGUAcgBpAGMALgBMAGkAcwB0AGAAMQBbAFsAVgBSAEMALgBVAGQAbwBuAC4AQwBvAG0AbQBvAG4ALgBJAG4AdABlAHIAZgBhAGMAZQBzAC4ASQBVAGQAbwBuAFMAeQBuAGMATQBlAHQAYQBkAGEAdABhACwAIABWAFIAQwAuAFUAZABvAG4ALgBDAG8AbQBtAG8AbgBdAF0ALAAgAG0AcwBjAG8AcgBsAGkAYgAiAAAABgAAAAAAAAAABwUHBRcBCwAAAFUAcABkAGEAdABlAE8AcgBkAGUAcgAAAAAABQ==";
                        program.name = PickupIdentifier;
                        program.serializationDataFormat = VRC.Udon.Serialization.OdinSerializer.DataFormat.Binary;
                        program.programUnityEngineObjects = new Il2CppSystem.Collections.Generic.List<UnityEngine.Object>();
                        return _PickupProgram = program;
                    }
                }
                return null;
            }
        }


    }
}