using System;
using System.Collections.Generic;
using System.Text;

//これらを使うために以下の参照の追加が必要
//System.Runtime.Serialization,System.ServiceModel,System.ServiceModel.Web
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

using System.IO;        //MemoryStreamを使うため
using System.Drawing;   //Point構造体を使うため

namespace MyUtil
{
	public class Util
    {
		public static readonly byte TypePos = 0;
		public static readonly byte TypeChat = 1;

		public static string Serialize(object graph)
		{
			using (var stream = new MemoryStream())
			{
				var serializer = new DataContractJsonSerializer(graph.GetType());
				serializer.WriteObject(stream, graph);
				return Encoding.UTF8.GetString(stream.ToArray());
			}
		}

		public static T DeSerialize<T>(byte[] bytes)
		{
			using (var stream = new MemoryStream(bytes))
			{
				var serializer = new DataContractJsonSerializer(typeof(T));
				return (T)serializer.ReadObject(stream);
			}
		}

		//整数をビッグエンディアンのバイト配列に変換
		public static byte[] ToBigEndianArray(ulong value, int byteNum)
		{
			if (byteNum <= 0 || byteNum > 8)
			{
				return null;
			}

			var byteArray = new byte[byteNum];
			for (int i = byteNum; i > 0; --i)
			{
				byteArray[byteNum - i] = (byte)(((value & (ulong)((ulong)0xff << ((i - 1) * 8)))) >> ((i - 1) * 8));
			}

			return byteArray;
		}

		//ビッグエンディアンのバイト配列をint型に変換
		public static int ToIntFromBigEndianArray(byte[] byteArray)
		{
			if (byteArray == null || byteArray.Length == 0 || byteArray.Length > 4)
			{
				return 0;
			}

			int num = 0;
			for (int i = 0; i < byteArray.Length; ++i)
			{
				num += byteArray[byteArray.Length - 1 - i] << (i * 8);
			}
			return num;
		}

		//バイト配列の結合
		public static byte[] MergeByteArrays(IList<byte[]> arrays)
		{
			if (arrays == null || arrays.Count == 0)
			{
				return null;
			}

			//結合後のバイト数を求める
			int bytes = 0;
			foreach (var array in arrays)
			{
				bytes += array.Length;
			}

			//リストに格納されたバイト配列を、一つのバイト配列に結合
			var mergedArray = new byte[bytes];
			int basePos = 0;
			foreach (var array in arrays)
			{
				Array.Copy(array, 0, mergedArray, basePos, array.Length);
				basePos += array.Length;
			}

			return mergedArray;
		}
	}

	[DataContract]
	public class PaintInfo
	{
		[DataMember]
		public Point StartPos { get; set; }

		[DataMember]
		public Point EndPos { get; set; }

        [DataMember]
        public int Pen_color { get; set; }
    }

	[DataContract]
	public class ChatData
	{
		[DataMember]
		public String Name { get; set; }

		[DataMember]
		public String Text { get; set; }
	}
}
