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


		public static void RemoveAllObjConstraints(this RigidBodyController control)
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

	}
}
