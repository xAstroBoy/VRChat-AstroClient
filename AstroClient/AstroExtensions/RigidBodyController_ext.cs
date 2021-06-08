namespace AstroClient.Extensions
{
	using AstroClient.Components;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using UnityEngine;

	public static class RigidBodyController_ext
	{
		public static void RestoreOriginalBody(this RigidBodyController control)
		{
			if (control != null)
			{
				control.RestoreOriginalBody();
			}
		}


		public static void Set_Gravity(this RigidBodyController control, bool useGravity)
		{
			if (control != null)
			{
				if (!control.EditMode)
				{
					control.EditMode = true;
				}
				control.useGravity = useGravity;
			}
		}

		public static void Set_DetectCollisions(this RigidBodyController control, bool DetectCollisions)
		{
			if (control != null)
			{
				if (!control.EditMode)
				{
					control.EditMode = true;
				}
				control.DetectCollisions = DetectCollisions;
			}
		}


		public static void Set_isKinematic(this RigidBodyController control, bool isKinematic)
		{
			if (control != null)
			{
				if (!control.EditMode)
				{
					control.EditMode = true;
				}
				control.isKinematic = isKinematic;
			}
		}

		public static void RemoveConstraint(this RigidBodyController control, RigidbodyConstraints constraint)
		{
			if (control != null)
			{
				if (!control.EditMode)
				{
					control.EditMode = true;
				}
				if (control.Constraints.HasFlag(constraint))
				{
					control.Constraints &= ~constraint;
				}
			}
		}


		public static void Remove_All_Constraints(this RigidBodyController control)
		{
			if (control != null)
			{
				if (!control.EditMode)
				{
					control.EditMode = true;
				}
				control.Constraints = RigidbodyConstraints.None;
			}
		}

		public static void AddConstraint(this RigidBodyController control, RigidbodyConstraints constraint)
		{
			if (control != null)
			{
				if (!control.EditMode)
				{
					control.EditMode = true;
				}
				control.Constraints |= constraint;
			}
		}


		public static void RestoreOriginalBody(this GameObject obj)
		{
			obj.GetOrAddComponent<RigidBodyController>().RestoreOriginalBody();
		}


		public static void Set_Gravity(this GameObject obj, bool useGravity)
		{
			obj.GetOrAddComponent<RigidBodyController>().Set_Gravity(useGravity);

		}

		public static void Set_DetectCollisions(this GameObject obj, bool DetectCollisions)
		{
			obj.GetOrAddComponent<RigidBodyController>().Set_DetectCollisions(DetectCollisions);

		}


		public static void Set_isKinematic(this GameObject obj, bool isKinematic)
		{
			obj.GetOrAddComponent<RigidBodyController>().Set_isKinematic(isKinematic);

		}

		public static void RemoveConstraint(this GameObject obj, RigidbodyConstraints constraint)
		{
			obj.GetOrAddComponent<RigidBodyController>().RemoveConstraint(constraint);
		}


		public static void Remove_All_Constraints(this GameObject obj)
		{
			obj.GetOrAddComponent<RigidBodyController>().Remove_All_Constraints();

		}

		public static void AddConstraint(this GameObject obj, RigidbodyConstraints constraint)
		{
			obj.GetOrAddComponent<RigidBodyController>().AddConstraint(constraint);
		}


		public static void RestoreOriginalBody(this List<GameObject> items)
		{
			foreach (var obj in items)
			{
				if (obj != null)
				{
					obj.RestoreOriginalBody();
				}
			}
		}


		public static void Set_Gravity(this List<GameObject> items, bool useGravity)
		{
			foreach (var obj in items)
			{
				if (obj != null)
				{
					obj.Set_Gravity(useGravity);
				}
			}
		}

		public static void Set_DetectCollisions(this List<GameObject> items, bool DetectCollisions)
		{
			foreach (var obj in items)
			{
				if (obj != null)
				{
					obj.Set_DetectCollisions(DetectCollisions);
				}
			}
		}


		public static void Set_isKinematic(this List<GameObject> items, bool isKinematic)
		{
			foreach (var obj in items)
			{
				if (obj != null)
				{
					obj.Set_isKinematic(isKinematic);
				}
			}
		}

		public static void RemoveConstraint(this List<GameObject> items, RigidbodyConstraints constraint)
		{
			foreach (var obj in items)
			{
				if (obj != null)
				{
					obj.RemoveConstraint(constraint);
				}
			}
		}


		public static void Remove_All_Constraints(this List<GameObject> items)
		{
			foreach (var obj in items)
			{
				if (obj != null)
				{
					obj.Remove_All_Constraints();
				}
			}
		}

		public static void AddConstraint(this List<GameObject> items, RigidbodyConstraints constraint)
		{
			foreach (var obj in items)
			{
				if (obj != null)
				{
					obj.AddConstraint(constraint);
				}
			}
		}





	}
}
