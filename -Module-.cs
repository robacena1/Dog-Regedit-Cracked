using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using Costura;

// Token: 0x02000001 RID: 1
internal class <Module>
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002048 File Offset: 0x00000248
	static <Module>()
	{
		AssemblyLoader.Attach();
	}

	// Token: 0x060000C6 RID: 198 RVA: 0x000023B0 File Offset: 0x000005B0
	private static void Initialize(string A_0)
	{
		<Module>.c8395498-5eb2-4b89-acea-2f1624ec3dae = new object();
		<Module>.8ae25f4f-cba5-4497-a238-bd404999adef = new Dictionary<int, DynamicMethod>();
		<Module>.35519e2b-b1ec-4679-8512-f8d5624366cc = new Dictionary<short, OpCode>();
		Stream manifestResourceStream = Assembly.GetCallingAssembly().GetManifestResourceStream(A_0);
		byte[] buffer;
		using (new StreamReader(manifestResourceStream))
		{
			byte[] array = new byte[manifestResourceStream.Length];
			manifestResourceStream.Read(array, 0, array.Length);
			buffer = array;
		}
		<Module>.57f54a02-0fba-45d2-828f-d46ce7549330 = new BinaryReader(new MemoryStream(buffer));
		foreach (FieldInfo fieldInfo in typeof(OpCodes).GetFields())
		{
			if (fieldInfo.FieldType == typeof(OpCode))
			{
				OpCode value = (OpCode)fieldInfo.GetValue(null);
				<Module>.35519e2b-b1ec-4679-8512-f8d5624366cc.Add(value.Value, value);
			}
		}
	}

	// Token: 0x060000C7 RID: 199 RVA: 0x000024FC File Offset: 0x000006FC
	public static object Execute(int A_0, object[] A_1)
	{
		if (<Module>.57f54a02-0fba-45d2-828f-d46ce7549330 == null)
		{
			<Module>.Initialize("VMD");
		}
		DynamicMethod dynamicMethod;
		if (<Module>.8ae25f4f-cba5-4497-a238-bd404999adef.TryGetValue(A_0, out dynamicMethod))
		{
			return dynamicMethod.Invoke(null, A_1);
		}
		<Module>.57f54a02-0fba-45d2-828f-d46ce7549330.BaseStream.Position = (long)A_0;
		List<<Module>.0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c> list = new List<<Module>.0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c>();
		MethodBase method = new StackTrace().GetFrame(1).GetMethod();
		ParameterInfo[] parameters = method.GetParameters();
		List<LocalBuilder> list2 = new List<LocalBuilder>();
		MethodBody methodBody = method.GetMethodBody();
		Type[] array = new Type[parameters.Length];
		int num = 0;
		if (!method.IsStatic)
		{
			array = new Type[parameters.Length + 1];
			array[0] = method.DeclaringType;
			num = 1;
		}
		for (int i = 0; i < parameters.Length; i++)
		{
			ParameterInfo parameterInfo = parameters[i];
			array[num + i] = parameterInfo.ParameterType;
		}
		DynamicMethod dynamicMethod2 = new DynamicMethod("", (method.MemberType == MemberTypes.Constructor) ? null : ((MethodInfo)method).ReturnParameter.ParameterType, array, method.Module, true);
		ILGenerator ilgenerator = dynamicMethod2.GetILGenerator();
		foreach (LocalVariableInfo localVariableInfo in methodBody.LocalVariables)
		{
			list2.Add(ilgenerator.DeclareLocal(localVariableInfo.LocalType, localVariableInfo.IsPinned));
		}
		int num2 = <Module>.57f54a02-0fba-45d2-828f-d46ce7549330.ReadInt32();
		<Module>.processExceptionHandler(<Module>.57f54a02-0fba-45d2-828f-d46ce7549330, num2, method, list);
		List<<Module>.f5784501-223f-4f55-be43-74dc36d3bbb4> list3 = <Module>.fixAndSortExceptionHandlers(list);
		int num3 = <Module>.57f54a02-0fba-45d2-828f-d46ce7549330.ReadInt32();
		Dictionary<int, Label> dictionary = new Dictionary<int, Label>();
		for (int j = 0; j < num3; j++)
		{
			Label value = ilgenerator.DefineLabel();
			dictionary.Add(j, value);
		}
		for (int k = 0; k < num3; k++)
		{
			<Module>.checkAndSetExceptionHandler(list3, k, ilgenerator);
			short key = <Module>.57f54a02-0fba-45d2-828f-d46ce7549330.ReadInt16();
			int num4 = (int)<Module>.57f54a02-0fba-45d2-828f-d46ce7549330.ReadByte();
			OpCode opCode = <Module>.35519e2b-b1ec-4679-8512-f8d5624366cc[key];
			ilgenerator.MarkLabel(dictionary[k]);
			<Module>.EmitInstruction(num4, opCode, ilgenerator, <Module>.57f54a02-0fba-45d2-828f-d46ce7549330, dictionary, list2);
		}
		object obj = <Module>.c8395498-5eb2-4b89-acea-2f1624ec3dae;
		lock (obj)
		{
			if (!<Module>.8ae25f4f-cba5-4497-a238-bd404999adef.ContainsKey(A_0))
			{
				<Module>.8ae25f4f-cba5-4497-a238-bd404999adef.Add(A_0, dynamicMethod2);
			}
		}
		return dynamicMethod2.Invoke(null, A_1);
	}

	// Token: 0x060000C8 RID: 200 RVA: 0x000028B4 File Offset: 0x00000AB4
	private static void EmitInstruction(int A_0, OpCode A_1, ILGenerator A_2, BinaryReader A_3, Dictionary<int, Label> A_4, List<LocalBuilder> A_5)
	{
		switch (A_0)
		{
		case 0:
			<Module>.InlineNoneEmitter(A_2, A_1, A_3);
			return;
		case 1:
			<Module>.InlineMethodEmitter(A_2, A_1, A_3);
			return;
		case 2:
			<Module>.InlineStringEmitter(A_2, A_1, A_3);
			return;
		case 3:
			<Module>.InlineIEmitter(A_2, A_1, A_3);
			return;
		case 4:
		case 12:
			<Module>.InlineVarEmitter(A_2, A_1, A_3, A_5);
			return;
		case 5:
			<Module>.InlineFieldEmitter(A_2, A_1, A_3);
			return;
		case 6:
			<Module>.InlineTypeEmitter(A_2, A_1, A_3);
			return;
		case 7:
			<Module>.ShortInlineBrTargetEmitter(A_2, A_1, A_3, A_4);
			return;
		case 8:
			<Module>.ShortInlineIEmitter(A_2, A_1, A_3);
			return;
		case 9:
			<Module>.InlineSwitchEmitter(A_2, A_1, A_3, A_4);
			return;
		case 10:
			<Module>.InlineBrTargetEmitter(A_2, A_1, A_3, A_4);
			return;
		case 11:
			<Module>.InlineTokEmitter(A_2, A_1, A_3);
			return;
		case 13:
			<Module>.ShortInlineREmitter(A_2, A_1, A_3);
			return;
		case 14:
			<Module>.InlineREmitter(A_2, A_1, A_3);
			return;
		case 15:
			<Module>.InlineI8Emitter(A_2, A_1, A_3);
			return;
		default:
			return;
		}
	}

	// Token: 0x060000C9 RID: 201 RVA: 0x00002A28 File Offset: 0x00000C28
	public static void checkAndSetExceptionHandler(List<<Module>.f5784501-223f-4f55-be43-74dc36d3bbb4> A_0, int A_1, ILGenerator A_2)
	{
		foreach (<Module>.f5784501-223f-4f55-be43-74dc36d3bbb4 f5784501-223f-4f55-be43-74dc36d3bbb in A_0)
		{
			if (f5784501-223f-4f55-be43-74dc36d3bbb.a930669b-9c74-4b36-8d70-f223452acb05 == 1)
			{
				if (f5784501-223f-4f55-be43-74dc36d3bbb.c81015bf-2659-4116-b272-bd0a043271d8 == A_1)
				{
					A_2.BeginExceptionBlock();
				}
				if (f5784501-223f-4f55-be43-74dc36d3bbb.9df043d3-1b49-46d7-9f65-ec437cf7fd09 == A_1)
				{
					A_2.EndExceptionBlock();
				}
				if (f5784501-223f-4f55-be43-74dc36d3bbb.4924b863-bc91-4424-9e11-f9c08c6284c7.Contains(A_1))
				{
					int index = f5784501-223f-4f55-be43-74dc36d3bbb.4924b863-bc91-4424-9e11-f9c08c6284c7.IndexOf(A_1);
					A_2.BeginCatchBlock(f5784501-223f-4f55-be43-74dc36d3bbb.a45a9298-d76a-4b67-9145-d05b14fb2b40[index]);
				}
			}
			else if (f5784501-223f-4f55-be43-74dc36d3bbb.a930669b-9c74-4b36-8d70-f223452acb05 == 5)
			{
				if (f5784501-223f-4f55-be43-74dc36d3bbb.c81015bf-2659-4116-b272-bd0a043271d8 == A_1)
				{
					A_2.BeginExceptionBlock();
				}
				else if (f5784501-223f-4f55-be43-74dc36d3bbb.9df043d3-1b49-46d7-9f65-ec437cf7fd09 == A_1)
				{
					A_2.EndExceptionBlock();
				}
				else if (f5784501-223f-4f55-be43-74dc36d3bbb.8e549339-c69d-4fb3-940d-034fc086f9a8 == A_1)
				{
					A_2.BeginFinallyBlock();
				}
			}
		}
	}

	// Token: 0x060000CA RID: 202 RVA: 0x0000204F File Offset: 0x0000024F
	private static void InlineNoneEmitter(ILGenerator A_0, OpCode A_1, BinaryReader A_2)
	{
		A_0.Emit(A_1);
	}

	// Token: 0x060000CB RID: 203 RVA: 0x00002B9C File Offset: 0x00000D9C
	private static void InlineMethodEmitter(ILGenerator A_0, OpCode A_1, BinaryReader A_2)
	{
		int metadataToken = A_2.ReadInt32();
		MethodBase methodBase = typeof(<Module>).Module.ResolveMethod(metadataToken);
		if (methodBase is MethodInfo)
		{
			A_0.Emit(A_1, (MethodInfo)methodBase);
			return;
		}
		if (methodBase is ConstructorInfo)
		{
			A_0.Emit(A_1, (ConstructorInfo)methodBase);
			return;
		}
		throw new Exception("Check resolvedMethodBase Type");
	}

	// Token: 0x060000CC RID: 204 RVA: 0x00002C28 File Offset: 0x00000E28
	private static void InlineVarEmitter(ILGenerator A_0, OpCode A_1, BinaryReader A_2, List<LocalBuilder> A_3)
	{
		int num = A_2.ReadInt32();
		if (A_2.ReadByte() == 0)
		{
			LocalBuilder local = A_3[num];
			A_0.Emit(A_1, local);
			return;
		}
		A_0.Emit(A_1, num);
	}

	// Token: 0x060000CD RID: 205 RVA: 0x00002C84 File Offset: 0x00000E84
	private static void InlineStringEmitter(ILGenerator A_0, OpCode A_1, BinaryReader A_2)
	{
		string str = A_2.ReadString();
		A_0.Emit(A_1, str);
	}

	// Token: 0x060000CE RID: 206 RVA: 0x00002CB0 File Offset: 0x00000EB0
	private static void InlineIEmitter(ILGenerator A_0, OpCode A_1, BinaryReader A_2)
	{
		int arg = A_2.ReadInt32();
		A_0.Emit(A_1, arg);
	}

	// Token: 0x060000CF RID: 207 RVA: 0x00002CDC File Offset: 0x00000EDC
	private static void InlineFieldEmitter(ILGenerator A_0, OpCode A_1, BinaryReader A_2)
	{
		int metadataToken = A_2.ReadInt32();
		FieldInfo field = typeof(<Module>).Module.ResolveField(metadataToken);
		A_0.Emit(A_1, field);
	}

	// Token: 0x060000D0 RID: 208 RVA: 0x00002D24 File Offset: 0x00000F24
	private static void InlineTypeEmitter(ILGenerator A_0, OpCode A_1, BinaryReader A_2)
	{
		int metadataToken = A_2.ReadInt32();
		Type cls = typeof(<Module>).Module.ResolveType(metadataToken);
		A_0.Emit(A_1, cls);
	}

	// Token: 0x060000D1 RID: 209 RVA: 0x00002D6C File Offset: 0x00000F6C
	private static void ShortInlineBrTargetEmitter(ILGenerator A_0, OpCode A_1, BinaryReader A_2, Dictionary<int, Label> A_3)
	{
		int key = A_2.ReadInt32();
		Label label = A_3[key];
		A_0.Emit(A_1, label);
	}

	// Token: 0x060000D2 RID: 210 RVA: 0x00002DA8 File Offset: 0x00000FA8
	private static void ShortInlineIEmitter(ILGenerator A_0, OpCode A_1, BinaryReader A_2)
	{
		byte arg = A_2.ReadByte();
		A_0.Emit(A_1, arg);
	}

	// Token: 0x060000D3 RID: 211 RVA: 0x00002DD4 File Offset: 0x00000FD4
	private static void ShortInlineREmitter(ILGenerator A_0, OpCode A_1, BinaryReader A_2)
	{
		float arg = BitConverter.ToSingle(A_2.ReadBytes(4), 0);
		A_0.Emit(A_1, arg);
	}

	// Token: 0x060000D4 RID: 212 RVA: 0x00002E10 File Offset: 0x00001010
	private static void InlineREmitter(ILGenerator A_0, OpCode A_1, BinaryReader A_2)
	{
		double arg = A_2.ReadDouble();
		A_0.Emit(A_1, arg);
	}

	// Token: 0x060000D5 RID: 213 RVA: 0x00002E3C File Offset: 0x0000103C
	private static void InlineI8Emitter(ILGenerator A_0, OpCode A_1, BinaryReader A_2)
	{
		long arg = A_2.ReadInt64();
		A_0.Emit(A_1, arg);
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x00002E68 File Offset: 0x00001068
	private static void InlineSwitchEmitter(ILGenerator A_0, OpCode A_1, BinaryReader A_2, Dictionary<int, Label> A_3)
	{
		int num = A_2.ReadInt32();
		Label[] array = new Label[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = A_3[A_2.ReadInt32()];
		}
		A_0.Emit(A_1, array);
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x00002D6C File Offset: 0x00000F6C
	private static void InlineBrTargetEmitter(ILGenerator A_0, OpCode A_1, BinaryReader A_2, Dictionary<int, Label> A_3)
	{
		int key = A_2.ReadInt32();
		Label label = A_3[key];
		A_0.Emit(A_1, label);
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x00002EE8 File Offset: 0x000010E8
	private static void InlineTokEmitter(ILGenerator A_0, OpCode A_1, BinaryReader A_2)
	{
		int metadataToken = A_2.ReadInt32();
		byte b = A_2.ReadByte();
		if (b == 0)
		{
			FieldInfo field = typeof(<Module>).Module.ResolveField(metadataToken);
			A_0.Emit(A_1, field);
			return;
		}
		if (b == 1)
		{
			Type cls = typeof(<Module>).Module.ResolveType(metadataToken);
			A_0.Emit(A_1, cls);
			return;
		}
		if (b == 2)
		{
			MethodBase methodBase = typeof(<Module>).Module.ResolveMethod(metadataToken);
			if (methodBase is MethodInfo)
			{
				A_0.Emit(A_1, (MethodInfo)methodBase);
				return;
			}
			if (methodBase is ConstructorInfo)
			{
				A_0.Emit(A_1, (ConstructorInfo)methodBase);
			}
		}
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x00002FF8 File Offset: 0x000011F8
	public static void processExceptionHandler(BinaryReader A_0, int A_1, MethodBase A_2, List<<Module>.0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c> A_3)
	{
		for (int i = 0; i < A_1; i++)
		{
			<Module>.0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c 0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c = new <Module>.0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c();
			int num = A_0.ReadInt32();
			if (num == -1)
			{
				0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c.dc73b29f-9272-4642-aa18-e6ec62486369 = null;
			}
			else
			{
				Type dc73b29f-9272-4642-aa18-e6ec = A_2.Module.ResolveType(num);
				0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c.dc73b29f-9272-4642-aa18-e6ec62486369 = dc73b29f-9272-4642-aa18-e6ec;
			}
			int 481a0057-a300-41c0-b2c8-11b217d1fe = A_0.ReadInt32();
			0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c.481a0057-a300-41c0-b2c8-11b217d1fe96 = 481a0057-a300-41c0-b2c8-11b217d1fe;
			int c5ccbd0f-001c-4a37-9931-ed16b8e = A_0.ReadInt32();
			0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c.c5ccbd0f-001c-4a37-9931-ed16b8e95763 = c5ccbd0f-001c-4a37-9931-ed16b8e;
			int 4ca3743b-c089-4ccf-a885-07a4cc11f90a = A_0.ReadInt32();
			0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c.4ca3743b-c089-4ccf-a885-07a4cc11f90a = 4ca3743b-c089-4ccf-a885-07a4cc11f90a;
			switch (A_0.ReadByte())
			{
			case 1:
				0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c.7a75e442-157a-4824-a80e-84a48b887bd9 = 1;
				break;
			case 2:
				0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c.7a75e442-157a-4824-a80e-84a48b887bd9 = 2;
				break;
			case 3:
				0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c.7a75e442-157a-4824-a80e-84a48b887bd9 = 3;
				break;
			case 4:
				0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c.7a75e442-157a-4824-a80e-84a48b887bd9 = 4;
				break;
			case 5:
				0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c.7a75e442-157a-4824-a80e-84a48b887bd9 = 5;
				break;
			default:
				throw new Exception("Out of Range");
			}
			int 0595f303-79ac-4755-8b99-00acb915cc = A_0.ReadInt32();
			0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c.0595f303-79ac-4755-8b99-00acb915cc34 = 0595f303-79ac-4755-8b99-00acb915cc;
			int 940ab8d1-770a-43c8-b83e-def092515d = A_0.ReadInt32();
			0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c.940ab8d1-770a-43c8-b83e-def092515d82 = 940ab8d1-770a-43c8-b83e-def092515d;
			A_3.Add(0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c);
		}
	}

	// Token: 0x060000DA RID: 218 RVA: 0x000031B4 File Offset: 0x000013B4
	public static List<<Module>.f5784501-223f-4f55-be43-74dc36d3bbb4> fixAndSortExceptionHandlers(List<<Module>.0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c> A_0)
	{
		List<<Module>.0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c> list = new List<<Module>.0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c>();
		Dictionary<<Module>.0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c, int> dictionary = new Dictionary<<Module>.0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c, int>();
		foreach (<Module>.0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c 0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c in A_0)
		{
			if (0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c.7a75e442-157a-4824-a80e-84a48b887bd9 == 5)
			{
				dictionary.Add(0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c, 0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c.940ab8d1-770a-43c8-b83e-def092515d82);
			}
			else if (dictionary.ContainsValue(0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c.940ab8d1-770a-43c8-b83e-def092515d82))
			{
				if (0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c.dc73b29f-9272-4642-aa18-e6ec62486369 != null)
				{
					dictionary.Add(0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c, 0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c.940ab8d1-770a-43c8-b83e-def092515d82);
				}
				else
				{
					list.Add(0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c);
				}
			}
			else
			{
				dictionary.Add(0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c, 0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c.940ab8d1-770a-43c8-b83e-def092515d82);
			}
		}
		List<<Module>.f5784501-223f-4f55-be43-74dc36d3bbb4> list2 = new List<<Module>.f5784501-223f-4f55-be43-74dc36d3bbb4>();
		foreach (KeyValuePair<<Module>.0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c, int> keyValuePair in dictionary)
		{
			if (keyValuePair.Key.7a75e442-157a-4824-a80e-84a48b887bd9 == 5)
			{
				list2.Add(new <Module>.f5784501-223f-4f55-be43-74dc36d3bbb4
				{
					c81015bf-2659-4116-b272-bd0a043271d8 = keyValuePair.Key.940ab8d1-770a-43c8-b83e-def092515d82,
					8e549339-c69d-4fb3-940d-034fc086f9a8 = keyValuePair.Key.0595f303-79ac-4755-8b99-00acb915cc34,
					841778fa-f9d6-4714-adfe-4c6ebc0299b4 = keyValuePair.Key.481a0057-a300-41c0-b2c8-11b217d1fe96,
					9df043d3-1b49-46d7-9f65-ec437cf7fd09 = keyValuePair.Key.c5ccbd0f-001c-4a37-9931-ed16b8e95763,
					a930669b-9c74-4b36-8d70-f223452acb05 = keyValuePair.Key.7a75e442-157a-4824-a80e-84a48b887bd9,
					4924b863-bc91-4424-9e11-f9c08c6284c7 = 
					{
						keyValuePair.Key.4ca3743b-c089-4ccf-a885-07a4cc11f90a
					},
					a45a9298-d76a-4b67-9145-d05b14fb2b40 = 
					{
						keyValuePair.Key.dc73b29f-9272-4642-aa18-e6ec62486369
					}
				});
			}
			else
			{
				List<<Module>.0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c> list3 = <Module>.WhereAlternate(list, keyValuePair.Value);
				if (list3.Count == 0)
				{
					list2.Add(new <Module>.f5784501-223f-4f55-be43-74dc36d3bbb4
					{
						c81015bf-2659-4116-b272-bd0a043271d8 = keyValuePair.Key.940ab8d1-770a-43c8-b83e-def092515d82,
						8e549339-c69d-4fb3-940d-034fc086f9a8 = keyValuePair.Key.0595f303-79ac-4755-8b99-00acb915cc34,
						841778fa-f9d6-4714-adfe-4c6ebc0299b4 = keyValuePair.Key.481a0057-a300-41c0-b2c8-11b217d1fe96,
						9df043d3-1b49-46d7-9f65-ec437cf7fd09 = keyValuePair.Key.c5ccbd0f-001c-4a37-9931-ed16b8e95763,
						a930669b-9c74-4b36-8d70-f223452acb05 = keyValuePair.Key.7a75e442-157a-4824-a80e-84a48b887bd9,
						4924b863-bc91-4424-9e11-f9c08c6284c7 = 
						{
							keyValuePair.Key.4ca3743b-c089-4ccf-a885-07a4cc11f90a
						},
						a45a9298-d76a-4b67-9145-d05b14fb2b40 = 
						{
							keyValuePair.Key.dc73b29f-9272-4642-aa18-e6ec62486369
						}
					});
				}
				else
				{
					<Module>.f5784501-223f-4f55-be43-74dc36d3bbb4 f5784501-223f-4f55-be43-74dc36d3bbb = new <Module>.f5784501-223f-4f55-be43-74dc36d3bbb4();
					f5784501-223f-4f55-be43-74dc36d3bbb.c81015bf-2659-4116-b272-bd0a043271d8 = keyValuePair.Key.940ab8d1-770a-43c8-b83e-def092515d82;
					f5784501-223f-4f55-be43-74dc36d3bbb.8e549339-c69d-4fb3-940d-034fc086f9a8 = keyValuePair.Key.0595f303-79ac-4755-8b99-00acb915cc34;
					f5784501-223f-4f55-be43-74dc36d3bbb.841778fa-f9d6-4714-adfe-4c6ebc0299b4 = keyValuePair.Key.481a0057-a300-41c0-b2c8-11b217d1fe96;
					f5784501-223f-4f55-be43-74dc36d3bbb.9df043d3-1b49-46d7-9f65-ec437cf7fd09 = list3[list3.Count - 1].c5ccbd0f-001c-4a37-9931-ed16b8e95763;
					f5784501-223f-4f55-be43-74dc36d3bbb.a930669b-9c74-4b36-8d70-f223452acb05 = keyValuePair.Key.7a75e442-157a-4824-a80e-84a48b887bd9;
					f5784501-223f-4f55-be43-74dc36d3bbb.4924b863-bc91-4424-9e11-f9c08c6284c7.Add(keyValuePair.Key.4ca3743b-c089-4ccf-a885-07a4cc11f90a);
					f5784501-223f-4f55-be43-74dc36d3bbb.a45a9298-d76a-4b67-9145-d05b14fb2b40.Add(keyValuePair.Key.dc73b29f-9272-4642-aa18-e6ec62486369);
					foreach (<Module>.0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c 0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c2 in list3)
					{
						f5784501-223f-4f55-be43-74dc36d3bbb.4924b863-bc91-4424-9e11-f9c08c6284c7.Add(0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c2.4ca3743b-c089-4ccf-a885-07a4cc11f90a);
						f5784501-223f-4f55-be43-74dc36d3bbb.a45a9298-d76a-4b67-9145-d05b14fb2b40.Add(0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c2.dc73b29f-9272-4642-aa18-e6ec62486369);
					}
					list2.Add(f5784501-223f-4f55-be43-74dc36d3bbb);
				}
			}
		}
		return list2;
	}

	// Token: 0x060000DB RID: 219 RVA: 0x00003654 File Offset: 0x00001854
	private static List<<Module>.0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c> WhereAlternate(List<<Module>.0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c> A_0, int A_1)
	{
		List<<Module>.0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c> list = new List<<Module>.0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c>();
		foreach (<Module>.0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c 0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c in A_0)
		{
			if (0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c.940ab8d1-770a-43c8-b83e-def092515d82 == A_1 && 0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c.7a75e442-157a-4824-a80e-84a48b887bd9 != 5)
			{
				list.Add(0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c);
			}
		}
		return list;
	}

	// Token: 0x04000097 RID: 151
	public static object c8395498-5eb2-4b89-acea-2f1624ec3dae;

	// Token: 0x04000098 RID: 152
	private static BinaryReader 57f54a02-0fba-45d2-828f-d46ce7549330;

	// Token: 0x04000099 RID: 153
	private static Dictionary<int, DynamicMethod> 8ae25f4f-cba5-4497-a238-bd404999adef;

	// Token: 0x0400009A RID: 154
	private static Dictionary<short, OpCode> 35519e2b-b1ec-4679-8512-f8d5624366cc;

	// Token: 0x0200001B RID: 27
	public class 0c96ad2a-6ea6-44dc-b9f2-277d140bfd2c
	{
		// Token: 0x0400009B RID: 155
		public Type dc73b29f-9272-4642-aa18-e6ec62486369;

		// Token: 0x0400009C RID: 156
		public int 481a0057-a300-41c0-b2c8-11b217d1fe96;

		// Token: 0x0400009D RID: 157
		public int c5ccbd0f-001c-4a37-9931-ed16b8e95763;

		// Token: 0x0400009E RID: 158
		public int 4ca3743b-c089-4ccf-a885-07a4cc11f90a;

		// Token: 0x0400009F RID: 159
		public int 7a75e442-157a-4824-a80e-84a48b887bd9;

		// Token: 0x040000A0 RID: 160
		public int 0595f303-79ac-4755-8b99-00acb915cc34;

		// Token: 0x040000A1 RID: 161
		public int 940ab8d1-770a-43c8-b83e-def092515d82;
	}

	// Token: 0x0200001C RID: 28
	public class f5784501-223f-4f55-be43-74dc36d3bbb4
	{
		// Token: 0x040000A2 RID: 162
		public List<Type> a45a9298-d76a-4b67-9145-d05b14fb2b40 = new List<Type>();

		// Token: 0x040000A3 RID: 163
		public int 841778fa-f9d6-4714-adfe-4c6ebc0299b4;

		// Token: 0x040000A4 RID: 164
		public int 9df043d3-1b49-46d7-9f65-ec437cf7fd09;

		// Token: 0x040000A5 RID: 165
		public List<int> 4924b863-bc91-4424-9e11-f9c08c6284c7 = new List<int>();

		// Token: 0x040000A6 RID: 166
		public int a930669b-9c74-4b36-8d70-f223452acb05;

		// Token: 0x040000A7 RID: 167
		public int 8e549339-c69d-4fb3-940d-034fc086f9a8;

		// Token: 0x040000A8 RID: 168
		public int c81015bf-2659-4116-b272-bd0a043271d8;
	}
}
