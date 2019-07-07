namespace Infrastructure.NoxKeys
{
	public static partial class SmartKeys
	{
		public static readonly Functor Get = new GetFunctor();
		public static readonly Functor GetDown = new GetKeyDownFunc();
		public static readonly Functor GetUp = new GetKeyUpFunc();
	}
}