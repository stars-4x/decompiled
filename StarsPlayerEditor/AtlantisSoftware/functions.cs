namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.CompilerServices;

    [StandardModule]
    internal sealed class functions
    {
        public static object DecodeText(object input, object start, object length)
        {
            object obj2;
            object obj6;
            object obj9;
            string str = "ABCDEFGHIJKLMNOP";
            string str2 = "QRSTUVWXYZ012345";
            string str3 = "6789bcdfgjkmpquv";
            string str4 = @"wxyz+- ,!.?:;\'*%$";
            string expression = "";
            object left = "";
            if (ObjectFlowControl.ForLoopControl.ForLoopInitObj(obj2, start, Operators.SubtractObject(Operators.AddObject(start, length), 1), 1, ref obj6, ref obj2))
            {
                do
                {
                    expression = expression + Strings.Right("0" + Conversion.Hex(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(input, new object[] { RuntimeHelpers.GetObjectValue(obj2) }, null))), 2);
                }
                while (ObjectFlowControl.ForLoopControl.ForNextCheckObj(obj2, obj6, ref obj2));
            }
            if (ObjectFlowControl.ForLoopControl.ForLoopInitObj(obj2, 1, Strings.Len(expression), 1, ref obj9, ref obj2))
            {
                do
                {
                    switch (Strings.UCase(Strings.Mid(expression, Conversions.ToInteger(obj2), 1)))
                    {
                        case "0":
                            left = Operators.ConcatenateObject(left, " ");
                            break;

                        case "1":
                            left = Operators.ConcatenateObject(left, "a");
                            break;

                        case "2":
                            left = Operators.ConcatenateObject(left, "e");
                            break;

                        case "3":
                            left = Operators.ConcatenateObject(left, "h");
                            break;

                        case "4":
                            left = Operators.ConcatenateObject(left, "i");
                            break;

                        case "5":
                            left = Operators.ConcatenateObject(left, "l");
                            break;

                        case "6":
                            left = Operators.ConcatenateObject(left, "n");
                            break;

                        case "7":
                            left = Operators.ConcatenateObject(left, "o");
                            break;

                        case "8":
                            left = Operators.ConcatenateObject(left, "r");
                            break;

                        case "9":
                            left = Operators.ConcatenateObject(left, "s");
                            break;

                        case "A":
                            left = Operators.ConcatenateObject(left, "t");
                            break;

                        case "B":
                            obj2 = Operators.AddObject(obj2, 1);
                            left = Operators.ConcatenateObject(left, Strings.Mid(str, (int) Math.Round((double) (Conversion.Val("&h" + Strings.Mid(expression, Conversions.ToInteger(obj2), 1)) + 1.0)), 1));
                            break;

                        case "C":
                            obj2 = Operators.AddObject(obj2, 1);
                            left = Operators.ConcatenateObject(left, Strings.Mid(str2, (int) Math.Round((double) (Conversion.Val("&h" + Strings.Mid(expression, Conversions.ToInteger(obj2), 1)) + 1.0)), 1));
                            break;

                        case "D":
                            obj2 = Operators.AddObject(obj2, 1);
                            left = Operators.ConcatenateObject(left, Strings.Mid(str3, (int) Math.Round((double) (Conversion.Val("&h" + Strings.Mid(expression, Conversions.ToInteger(obj2), 1)) + 1.0)), 1));
                            break;

                        case "E":
                            obj2 = Operators.AddObject(obj2, 1);
                            left = Operators.ConcatenateObject(left, Strings.Mid(str4, (int) Math.Round((double) (Conversion.Val("&h" + Strings.Mid(expression, Conversions.ToInteger(obj2), 1)) + 1.0)), 1));
                            break;

                        case "F":
                            if (Operators.ConditionalCompareObjectLessEqual(Operators.AddObject(obj2, 2), Strings.Len(expression), false))
                            {
                                left = Operators.ConcatenateObject(left, Strings.Chr((int) Math.Round(Conversion.Val(" &h" + Strings.Mid(expression, Conversions.ToInteger(Operators.AddObject(obj2, 2)), 1) + Strings.Mid(expression, Conversions.ToInteger(Operators.AddObject(obj2, 1)), 1)))));
                            }
                            obj2 = Operators.AddObject(obj2, 2);
                            break;
                    }
                }
                while (ObjectFlowControl.ForLoopControl.ForNextCheckObj(obj2, obj9, ref obj2));
            }
            return left;
        }

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

