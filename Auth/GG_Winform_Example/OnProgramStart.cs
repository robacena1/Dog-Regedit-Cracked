using System;

namespace Auth.GG_Winform_Example
{
	// Token: 0x02000010 RID: 16
	internal class OnProgramStart
	{
		// Token: 0x0600008C RID: 140 RVA: 0x00004AF8 File Offset: 0x00002CF8
		public static void Initialize(string name, string aid, string secret, string version)
		{
			object[] array = new object[]
			{
				name,
				aid,
				secret,
				version
			};
			object obj = <Module>.Execute(50805, array);
		}

		// Token: 0x0400007E RID: 126
		public static string AID;

		// Token: 0x0400007F RID: 127
		public static string Secret;

		// Token: 0x04000080 RID: 128
		public static string Version;

		// Token: 0x04000081 RID: 129
		public static string Name;

		// Token: 0x04000082 RID: 130
		public static string Salt;
	}
}
