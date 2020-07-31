using System.Collections.Generic;
using UnityEngine;

namespace Madhur.SO.Sets
{
	public abstract class RuntimeSet<T> : ScriptableObject
	{

		public List<T> Items = new List<T>();

		public void Add ( T thing )
		{

			if ( !Items.Contains ( thing ) )

				Items.Add ( thing );

		}

		public int GetCount()
		{
			return Items.Count;
		}

		public void Remove ( T thing )
		{

			if ( Items.Contains ( thing ) )

				Items.Remove ( thing );

		}

		public void RemoveAt( int index )
		{
			Items.RemoveAt ( index );
		}

		public void Clear ()
		{
			Items.Clear ( );
		}
	}
}