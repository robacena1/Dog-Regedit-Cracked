using System;

namespace Auth.GG_Winform_Example
{
	// Token: 0x0200000C RID: 12
	internal class Constants
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00002103 File Offset: 0x00000303
		// (set) Token: 0x06000054 RID: 84 RVA: 0x0000210A File Offset: 0x0000030A
		public static string Token { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00002112 File Offset: 0x00000312
		// (set) Token: 0x06000056 RID: 86 RVA: 0x00002119 File Offset: 0x00000319
		public static string Date { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00002121 File Offset: 0x00000321
		// (set) Token: 0x06000058 RID: 88 RVA: 0x00002128 File Offset: 0x00000328
		public static string APIENCRYPTKEY { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00002130 File Offset: 0x00000330
		// (set) Token: 0x0600005A RID: 90 RVA: 0x00002137 File Offset: 0x00000337
		public static string APIENCRYPTSALT { get; set; }

		// Token: 0x0600005B RID: 91 RVA: 0x00004A88 File Offset: 0x00002C88
		public static string RandomString(int length)
		{
			object[] array = new object[]
			{
				length
			};
			return (string)<Module>.Execute(50609, array);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00004AC8 File Offset: 0x00002CC8
		public static string HWID()
		{
			object[] array = new object[0];
			return (string)<Module>.Execute(50773, array);
		}

		// Token: 0x04000061 RID: 97
		public static bool Breached = false;

		// Token: 0x04000062 RID: 98
		public static bool Started = false;

		// Token: 0x04000063 RID: 99
		public static string IV = null;

		// Token: 0x04000064 RID: 100
		public static string Key = null;

		// Token: 0x04000065 RID: 101
		public static string ApiUrl = "https://api.auth.gg/csharp/";

		// Token: 0x04000066 RID: 102
		public static bool Initialized = false;

		// Token: 0x04000067 RID: 103
		public static Random random = new Random();
	}
}
