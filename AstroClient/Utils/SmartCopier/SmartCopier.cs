using UnityEngine;

namespace SmartCopier
{
	public static class SmartCopier
	{

		public static CopyContext _context;



			public static void Initialize(GameObject objectToCopyFrom)
			{
				_context = new CopyContext(objectToCopyFrom);
			}

			public static void PasteTo(this GameObject obj, CopyMode copyMode)
			{
				if (obj != null)
				{
					_context.PasteComponents(obj, copyMode);
				}
			}


		}
	}

