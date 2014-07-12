namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.CompilerServices;

    [StandardModule]
    internal sealed class functions
    {
        internal static object DeleteObject(ref byte[] Data, int Position)
        {
            int num = Data[Position + 0] + ((Data[Position + 1] & 3) * 0x100);
            double num2 = Conversion.Int((double) (((double) Data[Position + 1]) / 4.0));
            Array.Copy(Data, (Position + num) + 2, Data, Position, ((Data.Length - Position) - num) - 2);
            Data = (byte[]) Utils.CopyArray((Array) Data, new byte[(((Data.Length - 1) - num) - 2) + 1]);
            return 0;
        }

        internal static object GetBit(int Value, int Bit)
        {
            return (((long) Math.Round(Conversion.Int((double) (((double) Value) / Math.Pow(2.0, (double) Bit))))) & 1L);
        }

        internal static object GetBits(object Value, object FirstBit, object Count)
        {
            return Operators.AndObject(RuntimeHelpers.GetObjectValue(Conversion.Int(Operators.DivideObject(Value, Operators.ExponentObject(2, FirstBit)))), Operators.SubtractObject(Operators.ExponentObject(2, Count), 1));
        }

        internal static object GetBytes(byte[] Data, ref int Start, int Length)
        {
            int num = 0;
            int num3 = Start;
            for (int i = (Start + Length) - 1; i >= num3; i += -1)
            {
                num = (num * 0x100) + Data[i];
            }
            Start += Length;
            return num;
        }

        internal static object InsertObject(ref byte[] Data, int Type, byte[] NewObject, int Position)
        {
            int length = NewObject.Length;
            Data = (byte[]) Utils.CopyArray((Array) Data, new byte[(((Data.Length - 1) + length) + 2) + 1]);
            Array.Copy(Data, Position, Data, (Position + length) + 2, ((Data.Length - Position) - length) - 2);
            Data[Position] = (byte) (length & 0xff);
            Data[Position + 1] = (byte) ((((long) Math.Round(Conversion.Int((double) (((double) length) / 256.0)))) & 3L) + (Type * 4));
            Array.Copy(NewObject, 0, Data, Position + 2, length);
            return 0;
        }
    }
}

