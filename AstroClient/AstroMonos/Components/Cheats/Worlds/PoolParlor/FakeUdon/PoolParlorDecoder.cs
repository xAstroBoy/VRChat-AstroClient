using AstroClient.AstroMonos.Components.Spoofer;
using AstroClient.UdonUtils.FakeUdon;
using AstroClient.UdonUtils.UdonSharp;
using System.Text;
using VRC.Udon;

namespace AstroClient.AstroMonos.FakeUdons
{
    namespace PoolParlorDecoder
    {
        internal class Register_PoolParlor : AstroEvents
        {
            // TODO : turn this into a attribute, to speed things up.
            internal override void ExecutePriorityPatches()
            {
                FakeUdonRegistry.RegisterType<AvatarImageReader.PoolParlor_RuntimeDecoder>(new PoolParlor_PatreonMatcher());
            }
        }
    }

    internal class PoolParlor_PatreonMatcher : UdonMatcher
    {
        public bool Match(UdonBehaviour behaviour)
        {
            if (behaviour.publicVariables.TryGetVariableValue("callbackEventName", out Il2CppSystem.Object value))
            {
                return ((string)new Il2CppSystem.String(value.Pointer)) == "_OnDataDecoded";
            }
            return false;
        }
    }

    namespace AvatarImageReader
    {
        internal class PoolParlor_RuntimeDecoder : UdonSharpBehaviour
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
                Log.Write("Pool Parlor Decoder Start");
                SendCustomEventDelayedFrames("Decode", 100);
            }

            public string outputString;
            public UdonBehaviour callbackBehaviour;
            public string callbackEventName;

            public void InvokeCallback()
            {
                callbackBehaviour.SendCustomEvent(callbackEventName);
            }

            public void Decode()
            {
                Log.Write("Hijacking Pool Parlor Decoder...");
                var name = CurrentDisplayName;
                var builder = new StringBuilder();
                builder.AppendLine($"version 1");
                builder.AppendLine($"tournament	1662081433165	TheLoneCone	Tumeski	Saryn	metaphira");
                builder.AppendLine($"announcement	Pwned By AstroClient. Join the Discord at https://discord.gg/poolparlor or the VRC Group at https://vrc.group/POOL.1053");
                builder.AppendLine($"moderators	metaphira	{name}	Yuutashoe｜兎	ToastersPlease");
                builder.AppendLine($"color	Holy Star	883DBE");
                builder.AppendLine($"color	BenChillin	2c0da6");
                builder.AppendLine($"color	Chintzykid	rainbow");
                builder.AppendLine($"color	-Define-	33ffff");
                builder.AppendLine($"color	Yuutashoe｜兎	yuuta");
                builder.AppendLine($"color	HeadŁess	3ee63e");
                builder.AppendLine($"color	s＄Fred＄s	ff2800");
                builder.AppendLine($"color	Nahsarra	ffd700");
                builder.AppendLine($"color	metaphira	ff69b4");
                builder.AppendLine($"color	ShiftySnowWolf	9e02d3");
                builder.AppendLine($"color	Sezuha	ff007d");
                builder.AppendLine($"color	ToastersPlease	toaster");
                builder.AppendLine($"color	-L̷U̶X̷-	EA68F9");
                builder.AppendLine($"color	YoyoAder	d95d67");
                builder.AppendLine($"color	Asweda	b393f3");
                builder.AppendLine($"color	Saryn	cc4806");
                builder.AppendLine($"color	Fre'	A6F6C5");
                builder.AppendLine($"color	Tumeski	E0E0E0");
                builder.AppendLine($"color	しがみん⁄Shigamin	AE52C8");
                builder.AppendLine($"color	TheLoneCone	FC0349");
                builder.AppendLine($"color	Totally Not Tim	14FAFF");
                builder.AppendLine($"color	Modernbobcat	19ceeb");
                builder.AppendLine($"color	Yukonyx	E0B0FF");
                builder.AppendLine($"color	BeautyInBlack	3D2278");
                builder.AppendLine($"color	{name}	rainbow");
                builder.AppendLine($"table	0	~");
                builder.AppendLine($"table	1	~");
                builder.AppendLine($"table	2	~");
                builder.AppendLine($"table	3	~");
                builder.AppendLine($"table	4	~");
                builder.AppendLine($"table	5	~");
                builder.AppendLine($"table	6	~");
                builder.AppendLine($"table	7	~");
                builder.AppendLine($"table	8	~");
                builder.AppendLine($"table	9	~");
                builder.AppendLine($"table	10	~");
                builder.AppendLine($"table	11	~");
                builder.AppendLine($"table	12	~");
                builder.AppendLine($"table	13	~");
                builder.AppendLine($"table	14	~");
                builder.AppendLine($"table	15	~");
                builder.AppendLine($"table	16	~");
                builder.AppendLine($"table	17	~");
                builder.AppendLine($"table	18	~");
                builder.AppendLine($"table	19	~");
                builder.AppendLine($"table	20	~");
                builder.AppendLine($"table	21	~");
                builder.AppendLine($"table	22	~");
                builder.AppendLine($"table	23	~");
                builder.AppendLine($"table	24	~");
                builder.AppendLine($"table	25	~");
                builder.AppendLine($"contributor-table	ToastersPlease	6");
                builder.AppendLine($"contributor-table	Chintzykid	7");
                builder.AppendLine($"contributor-table	Yuutashoe｜兎	8");
                builder.AppendLine($"contributor-table	metaphira	13");
                builder.AppendLine($"contributor-table	Holy Star	9");
                builder.AppendLine($"contributor-table	Fre'	10");
                builder.AppendLine($"contributor-table	Sezuha	11");
                builder.AppendLine($"contributor-table	しがみん⁄Shigamin	12");
                builder.AppendLine($"contributor-table	TheLoneCone	14");
                builder.AppendLine($"cue	0	~");
                builder.AppendLine($"cue	1	~");
                builder.AppendLine($"cue	2	~");
                builder.AppendLine($"cue	3	~");
                builder.AppendLine($"cue	4	~");
                builder.AppendLine($"cue	5	~");
                builder.AppendLine($"cue	6	~");
                builder.AppendLine($"cue	7	~");
                builder.AppendLine($"cue	8	~");
                builder.AppendLine($"cue	9	~");
                builder.AppendLine($"cue	10	~");
                builder.AppendLine($"cue	11	~");
                builder.AppendLine($"cue	12	~");
                builder.AppendLine($"cue	13	~");
                builder.AppendLine($"cue	14	~");
                builder.AppendLine($"cue	15	~");
                builder.AppendLine($"cue	16	~");
                builder.AppendLine($"cue	17	~");
                builder.AppendLine($"cue	18	~");
                builder.AppendLine($"cue	19	~");
                builder.AppendLine($"cue	20	~");
                builder.AppendLine($"cue	21	~");
                builder.AppendLine($"cue	22	~");
                builder.AppendLine($"cue	23	~");
                builder.AppendLine($"cue	24	~");
                builder.AppendLine($"cue	25	~");
                builder.AppendLine($"cue	26	~");
                builder.AppendLine($"cue	27	~");
                builder.AppendLine($"contributor-cue	ToastersPlease	3");
                builder.AppendLine($"contributor-cue	Yuutashoe｜兎	4");
                builder.AppendLine($"contributor-cue	Chintzykid	5");
                builder.AppendLine($"contributor-cue	metaphira	6");
                builder.AppendLine($"contributor-cue	Holy Star	7");
                builder.AppendLine($"contributor-cue	Tumeski	10");
                builder.AppendLine($"contributor-cue	Sezuha	11");
                builder.AppendLine($"contributor-cue	しがみん⁄Shigamin	12");
                builder.AppendLine($"contributor-cue	Totally Not Tim	24");
                builder.AppendLine($"contributor-cue	TheLoneCone	25");
                builder.AppendLine($"placeholder");
                builder.AppendLine($"placeholder");
                builder.AppendLine($"placeholde");
                outputString = builder.ToString();
                callbackBehaviour.SendCustomEvent(callbackEventName);
            }
        }
    }
}