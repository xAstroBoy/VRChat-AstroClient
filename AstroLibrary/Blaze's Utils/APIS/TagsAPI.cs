namespace Blaze.API
{
	using System.Linq;
	using TMPro;
	using UnityEngine;
	using VRC;

	public class BlazeTag
    {
        protected GameObject Tag;
        protected TextMeshProUGUI Text;

        public BlazeTag(Player player, string TagText, Color TagColor, bool top = true)
        {
            Initialize(player, TagText, TagColor, top);
        }

        private void Initialize(Player player, string TagText, Color TagColor, bool top)
        {
            int Count;
			if (top)
			{
				if (BlazesAPIs.PlayersTopTagsCount.ContainsKey(player))
				{
					BlazesAPIs.PlayersTopTagsCount.TryGetValue(player, out int kekidfk);
					Count = kekidfk;
				}
				else
				{
					Count = 0;
				}
			}
			else
			{
				if (BlazesAPIs.PlayersBottomTagsCount.ContainsKey(player))
				{
					BlazesAPIs.PlayersBottomTagsCount.TryGetValue(player, out int kekidfk);
					Count = kekidfk;
				}
				else
				{
					Count = 0;
				}
			}
            if (player.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/").FindChild($"{BlazesAPIs.Identifier}-Tag-{Count}") != null) return; // Prevent duplicates spawning on a player
            var baseTag = player.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Quick Stats").gameObject;
            Tag = UnityEngine.Object.Instantiate(baseTag, player.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/"));
            Tag.name = $"{BlazesAPIs.Identifier}-Tag-{Count}";
            DeleteChildren(); // Deletes any and all children objects that aren't the tag text (also sets Text while it does this)
            Text.text = TagText;
            Tag.GetComponent<ImageThreeSlice>().color = TagColor;
            SetLocation(Count);
            baseTag.transform.localPosition = new Vector3(0f, (Count + 2) * 30, 0f);
            Tag.SetActive(true);
            //if (BlazesAPIs.GlowingTags) Tag.AddComponent<>
            if (BlazesAPIs.PlayersTopTagsCount.ContainsKey(player))
            {
                BlazesAPIs.PlayersTopTagsCount[player] = Count;
            }
            else
            {
                BlazesAPIs.PlayersTopTagsCount.Add(player, 1);
            }
        }

        private void SetLocation(int count)
        {
            /*if (BlazesAPIs.AddTagGap)
                Tag.transform.localPosition = new Vector3(0f, (30 * (count + 2)), 0f);
            else*/
                Tag.transform.localPosition = new Vector3(0f, (30 * (count + 1)), 0f);
        }

        private void DeleteChildren()
        {
            for (int i = Tag.transform.childCount; i > 0; i--)
            {
                Transform child = Tag.transform.GetChild(i - 1);
                if (child.name == "Trust Text")
                {
                    Text = child.GetComponent<TextMeshProUGUI>();
                }
                else
                {
                    UnityEngine.Object.Destroy(child.gameObject);
                }
            }
        }
    }
    
    public class TagsUtils
    {
        public static void ClearPlayersTags(VRC.Player instance)
        {
            try
            {
                for (int i = instance.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/").childCount; i > 0; i--)
                {
                    Transform child = instance.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/").GetChild(i - 1);
                    if (child.name.StartsWith($"{BlazesAPIs.Identifier}-Tag-"))
                    {
                        UnityEngine.Object.Destroy(child.gameObject);
                    }
                }
                BlazesAPIs.PlayersTopTagsCount.Remove(instance);
            }
            catch {}
        }

        public static void ClearAllTags()
        {
            try
            {
                var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Name");
                foreach (var o in objects)
                {
                    if (o.name.StartsWith($"{BlazesAPIs.Identifier}-Tag-"))
                    {
                        UnityEngine.Object.Destroy(o);
                    }
                }
                BlazesAPIs.PlayersTopTagsCount.Clear();
            }
            catch {}
        }
    }
}
