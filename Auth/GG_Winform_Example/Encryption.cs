using System;

namespace Auth.GG_Winform_Example
{
	// Token: 0x02000016 RID: 22
	internal class Encryption
	{
		// Token: 0x060000A6 RID: 166 RVA: 0x00004FA8 File Offset: 0x000031A8
		public static string APIService(string value)
		{
			object[] array = new object[]
			{
				value
			};
			return (string)<Module>.Execute(65939, array);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00004FE8 File Offset: 0x000031E8
		public static string EncryptService(string value)
		{
			object[] array = new object[]
			{
				value
			};
			return (string)<Module>.Execute(66159, array);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00005028 File Offset: 0x00003228
		public static string DecryptService(string value)
		{
			object[] array = new object[]
			{
				value
			};
			return (string)<Module>.Execute(66460, array);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00005068 File Offset: 0x00003268
		public static string EncryptString(string plainText, byte[] key, byte[] iv)
		{
			object[] array = new object[]
			{
				plainText,
				key,
				iv
			};
			return (string)<Module>.Execute(66680, array);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000050C8 File Offset: 0x000032C8
		public static string DecryptString(string cipherText, byte[] key, byte[] iv)
		{
			object[] array = new object[]
			{
				cipherText,
				key,
				iv
			};
			return (string)<Module>.Execute(67044, array);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00005128 File Offset: 0x00003328
		public static string Decode(string text)
		{
			object[] array = new object[]
			{
				text
			};
			return (string)<Module>.Execute(67458, array);
		}
	}
}
