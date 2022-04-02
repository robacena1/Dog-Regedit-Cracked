using System;
using System.Net;
using System.Threading;

namespace Auth.GG_Winform_Example
{
	// Token: 0x02000017 RID: 23
	internal class InfoManager
	{
		// Token: 0x060000AD RID: 173 RVA: 0x00002304 File Offset: 0x00000504
		public InfoManager()
		{
			this.lastGateway = this.GetGatewayMAC();
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00005168 File Offset: 0x00003368
		public void StartListener()
		{
			object[] array = new object[]
			{
				this
			};
			object obj = <Module>.Execute(67704, array);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000051A8 File Offset: 0x000033A8
		private void OnCallBack()
		{
			object[] array = new object[]
			{
				this
			};
			object obj = <Module>.Execute(67776, array);
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000051E8 File Offset: 0x000033E8
		public static IPAddress GetDefaultGateway()
		{
			object[] array = new object[0];
			return (IPAddress)<Module>.Execute(68038, array);
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00005218 File Offset: 0x00003418
		private string GetArpTable()
		{
			object[] array = new object[]
			{
				this
			};
			return (string)<Module>.Execute(68353, array);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00005258 File Offset: 0x00003458
		private string GetGatewayMAC()
		{
			object[] array = new object[]
			{
				this
			};
			return (string)<Module>.Execute(68746, array);
		}

		// Token: 0x04000088 RID: 136
		private Timer timer;

		// Token: 0x04000089 RID: 137
		private string lastGateway;
	}
}
