using System.Linq;
using UnityEngine;

namespace Infrastructure.NoxKeys
{
	public partial class SmartKeys
	{
		public partial class Functor
		{
			/// <summary>
			/// A SmartKeys.Functor.Verifier defines the function to be used to verify if a set of KeyCode
			/// should trigger the functor
			/// </summary>
			public abstract class Verifier
			{
				/// <summary>
				/// The Functor to be used by the verifier. A
				/// </summary>
				protected readonly Functor Functor;

				protected Verifier(Functor functor)
				{
					Functor = functor;
				}

				public abstract bool Key(KeyCode first, params KeyCode[] others);
			}

			/// <inheritdoc />
			///  <summary>
			///   Behaves as Modifer.Key(KeyCode) for the first n-1 keys and Functor.func(KeyCode) for the last:
			///  GetUp.AllVerifier.Verifiy(CTRL,ALT,SHIFT,K) properly triggers when K is released and the other keys
			///  are held or released in this frame.
			///  GetUp.AllVerifier.Verifiy(K) ist just testing GetUp.Key(K) and triggers when K is released. 
			///  </summary>
			public class AllVerifier : Verifier
			{
				public AllVerifier(Functor functor) : base(functor) {}

				public override bool Key(KeyCode first, params KeyCode[] other)
				{
					if (!other.Any())
						return Functor.func(first);

					var aggregate = Modifier.Key(first);
					for (var i = 0; i < other.Length - 1; i++)
						aggregate &= Modifier.Key(other[i]);
					aggregate &= Functor.func(other[other.Length - 1]);
					return aggregate;
				}
			}

			/// <inheritdoc />
			/// <summary>
			/// AnyVerifier.Verify simply returns true if any passed KeyCode passes Functor.func(KeyCode).
			/// </summary>
			public class AnyVerifier : Verifier
			{
				public AnyVerifier(Functor functor) : base(functor) {}

				public override bool Key(KeyCode first, params KeyCode[] other) =>
					other.Aggregate(Functor.func(first), (working, next) => working || Functor.func(next));
			}
		}
	}
}