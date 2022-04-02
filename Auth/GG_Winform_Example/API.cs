using System;

namespace Auth.GG_Winform_Example
{
	// Token: 0x02000011 RID: 17
	internal class API
	{
		// Token: 0x0600008E RID: 142 RVA: 0x00004B68 File Offset: 0x00002D68
		public static void Log(string username, string action)
		{
			object[] array = new object[]
			{
				username,
				action
			};
			object obj = <Module>.Execute(53435, array);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00004BB8 File Offset: 0x00002DB8
		public static bool AIO(string AIO)
		{
			object[] array = new object[]
			{
				AIO
			};
			return (bool)<Module>.Execute(54266, array);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00004BF8 File Offset: 0x00002DF8
		public static bool AIOLogin(string AIO)
		{
			object[] array = new object[]
			{
				AIO
			};
			return (bool)<Module>.Execute(54348, array);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00004C38 File Offset: 0x00002E38
		public static bool AIORegister(string AIO)
		{
			object[] array = new object[]
			{
				AIO
			};
			return (bool)<Module>.Execute(56516, array);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00004C78 File Offset: 0x00002E78
		public static bool Login(string username, string password)
		{
			object[] array = new object[]
			{
				username,
				password
			};
			return (bool)<Module>.Execute(57821, array);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00004CC8 File Offset: 0x00002EC8
		public static bool Register(string username, string password, string email, string license)
		{
			object[] array = new object[]
			{
				username,
				password,
				email,
				license
			};
			return (bool)<Module>.Execute(60041, array);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00004D38 File Offset: 0x00002F38
		public static bool ExtendSubscription(string username, string password, string license)
		{
			object[] array = new object[]
			{
				username,
				password,
				license
			};
			return (bool)<Module>.Execute(61672, array);
		}
	}
}
