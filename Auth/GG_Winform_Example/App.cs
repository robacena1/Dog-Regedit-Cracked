using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Auth.GG_Winform_Example
{
	// Token: 0x0200000B RID: 11
	internal class App
	{
		// Token: 0x06000050 RID: 80 RVA: 0x00004A48 File Offset: 0x00002C48
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static string GrabVariable(string name)
		{
			object[] array = new object[]
			{
				name
			};
			return (string)<Module>.Execute(50366, array);
		}

		// Token: 0x0400005B RID: 91
		public static string Error = null;

		// Token: 0x0400005C RID: 92
		public static Dictionary<string, string> Variables = new Dictionary<string, string>();
	}
}
