using System;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Auth.GG_Winform_Example
{
	// Token: 0x02000012 RID: 18
	internal class Security
	{
		// Token: 0x06000096 RID: 150 RVA: 0x00004D98 File Offset: 0x00002F98
		public static string Signature(string value)
		{
			object[] array = new object[]
			{
				value
			};
			return (string)<Module>.Execute(63131, array);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00004DD8 File Offset: 0x00002FD8
		private static string Session(int length)
		{
			object[] array = new object[]
			{
				length
			};
			return (string)<Module>.Execute(63330, array);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00004E18 File Offset: 0x00003018
		public static string Obfuscate(int length)
		{
			object[] array = new object[]
			{
				length
			};
			return (string)<Module>.Execute(63502, array);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00004E58 File Offset: 0x00003058
		public static void Start()
		{
			object[] array = new object[0];
			object obj = <Module>.Execute(63849, array);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00004E88 File Offset: 0x00003088
		public static void End()
		{
			object[] array = new object[0];
			object obj = <Module>.Execute(64575, array);
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00004EB8 File Offset: 0x000030B8
		private static bool PinPublicKey(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			object[] array = new object[]
			{
				sender,
				certificate,
				chain,
				sslPolicyErrors
			};
			return (bool)<Module>.Execute(64818, array);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00004F28 File Offset: 0x00003128
		public static string Integrity(string filename)
		{
			object[] array = new object[]
			{
				filename
			};
			return (string)<Module>.Execute(65421, array);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00004F68 File Offset: 0x00003168
		public static bool MaliciousCheck(string date)
		{
			object[] array = new object[]
			{
				date
			};
			return (bool)<Module>.Execute(65678, array);
		}

		// Token: 0x04000083 RID: 131
		private const string _key = "3082010A0282010100CEB689728FB489BA9512B64F5A6AC786FCCEB9518720A4AD3AA9538A45984B500A8EFFD8A878684D857E5876C8D94CF30414E44D7445025D5A388D1FD5EF91352E3FEB7EC7C0D53FE86D3C49DC17426F217B7B2C1E029B9D60580CF041B3C8632A8D62F5998AF93C0C7E357C266256ACB15969523CCE326B49A1E3371571C0DCFCF41D36F4C66555D674884F4B41673E105E1C1A44266D0225F2A0B1D39D2D99860432DE4972E8CDF4F3BBC92C091791811E513291415949E169747EB7E85D229DFD6FDC6EDC6CE35D62A2CBDBB473B0E112A110479ADCC4EFAF33DEEB6A58BC0E14E74BBDF8C83EEC426C387160A673A2318722096B050F1293933443420D630203010001";
	}
}
