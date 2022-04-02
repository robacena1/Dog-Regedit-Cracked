using System;
using System.Windows.Forms;

namespace DOGREGEDIT22
{
	// Token: 0x02000008 RID: 8
	internal static class Program
	{
		// Token: 0x06000048 RID: 72 RVA: 0x000020A1 File Offset: 0x000002A1
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form3());
		}
	}
}
