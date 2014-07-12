namespace AtlantisSoftware
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    [StandardModule]
    internal sealed class functions
    {
        public static object CalculateHabValue2(Planet Planet, Race Race)
        {
            int num4 = 0;
            int num = 0;
            int num5 = 0;
            int num3 = 0;
            if (Race.CentreGravity == 0xff)
            {
                num = 0x2710;
            }
            else if (Planet.Gravity > Race.CentreGravity)
            {
                if (Planet.Gravity > Race.HighGravity)
                {
                    num = Race.HighGravity - Planet.Gravity;
                    if (num < -15)
                    {
                        num4 = -15;
                    }
                    else
                    {
                        num4 += num;
                    }
                }
                else
                {
                    num = (int) Math.Round((double) (100.0 - Conversion.Int((double) ((((double) (Planet.Gravity - Race.CentreGravity)) / ((double) (Race.HighGravity - Race.CentreGravity))) * 100.0))));
                }
            }
            else if (Planet.Gravity < Race.LowGravity)
            {
                num = Race.LowGravity - Planet.Gravity;
                if (num < -15)
                {
                    num4 = -15;
                }
                else
                {
                    num4 += num;
                }
            }
            else
            {
                num = (int) Math.Round((double) (100.0 - Conversion.Int((double) ((((double) (Race.CentreGravity - Planet.Gravity)) / ((double) (Race.CentreGravity - Race.LowGravity))) * 100.0))));
            }
            if (Race.CentreTemperature == 0xff)
            {
                num5 = 0x2710;
            }
            else if (Planet.Gravity > Race.CentreTemperature)
            {
                if (Planet.Temperature > Race.HighTemperature)
                {
                    num5 = Race.HighTemperature - Planet.Temperature;
                    if (num5 < -15)
                    {
                        num4 = -15;
                    }
                    else
                    {
                        num4 += num5;
                    }
                }
                else
                {
                    num5 = (int) Math.Round((double) (100.0 - Conversion.Int((double) ((((double) (Planet.Temperature - Race.CentreTemperature)) / ((double) (Race.HighTemperature - Race.CentreTemperature))) * 100.0))));
                }
            }
            else if (Planet.Temperature < Race.LowTemperature)
            {
                num5 = Race.LowTemperature - Planet.Temperature;
                if (num5 < -15)
                {
                    num4 = -15;
                }
                else
                {
                    num4 += num5;
                }
            }
            else
            {
                num5 = (int) Math.Round((double) (100.0 - Conversion.Int((double) ((((double) (Race.CentreTemperature - Planet.Temperature)) / ((double) (Race.CentreTemperature - Race.LowTemperature))) * 100.0))));
            }
            if (Race.CentreRadiation == 0xff)
            {
                num3 = 0x2710;
            }
            else if (Planet.Radiation > Race.CentreRadiation)
            {
                if (Planet.Radiation > Race.HighRadiation)
                {
                    num3 = Race.HighRadiation - Planet.Radiation;
                    if (num3 < -15)
                    {
                        num4 = -15;
                    }
                    else
                    {
                        num4 += num3;
                    }
                }
                else
                {
                    num3 = (int) Math.Round((double) (100.0 - Conversion.Int((double) ((((double) (Planet.Radiation - Race.CentreRadiation)) / ((double) (Race.HighRadiation - Race.CentreRadiation))) * 100.0))));
                }
            }
            else if (Planet.Radiation < Race.LowRadiation)
            {
                num3 = Race.LowRadiation - Planet.Radiation;
                if (num3 < -15)
                {
                    num4 = -15;
                }
                else
                {
                    num4 += num3;
                }
            }
            else
            {
                num3 = (int) Math.Round((double) (100.0 - Conversion.Int((double) ((((double) (Race.CentreRadiation - Planet.Radiation)) / ((double) (Race.CentreRadiation - Race.LowRadiation))) * 100.0))));
            }
            if (num4 < 0)
            {
                return num4;
            }
            return Conversion.Int((double) (Math.Sqrt(((double) (((num * num) + (num5 * num5)) + (num3 * num3))) / 3.0) + 0.9));
        }

        public static object DecodeText(object input, object start, object length)
        {
            object obj2;
            object obj6;
            object obj9;
            string str = "ABCDEFGHIJKLMNOP";
            string str2 = "QRSTUVWXYZ012345";
            string str3 = "6789bcdfgjkmpquv";
            string str4 = "wxyz+-,!.?:;'*%$";
            string expression = "";
            object left = "";
            if (ObjectFlowControl.ForLoopControl.ForLoopInitObj(obj2, start, Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(start, length), 1), 1, ref obj6, ref obj2))
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
                            left = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(left, " ");
                            break;

                        case "1":
                            left = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(left, "a");
                            break;

                        case "2":
                            left = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(left, "e");
                            break;

                        case "3":
                            left = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(left, "h");
                            break;

                        case "4":
                            left = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(left, "i");
                            break;

                        case "5":
                            left = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(left, "l");
                            break;

                        case "6":
                            left = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(left, "n");
                            break;

                        case "7":
                            left = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(left, "o");
                            break;

                        case "8":
                            left = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(left, "r");
                            break;

                        case "9":
                            left = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(left, "s");
                            break;

                        case "A":
                            left = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(left, "t");
                            break;

                        case "B":
                            obj2 = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(obj2, 1);
                            left = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(left, Strings.Mid(str, (int) Math.Round((double) (Conversion.Val("&h" + Strings.Mid(expression, Conversions.ToInteger(obj2), 1)) + 1.0)), 1));
                            break;

                        case "C":
                            obj2 = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(obj2, 1);
                            left = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(left, Strings.Mid(str2, (int) Math.Round((double) (Conversion.Val("&h" + Strings.Mid(expression, Conversions.ToInteger(obj2), 1)) + 1.0)), 1));
                            break;

                        case "D":
                            obj2 = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(obj2, 1);
                            left = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(left, Strings.Mid(str3, (int) Math.Round((double) (Conversion.Val("&h" + Strings.Mid(expression, Conversions.ToInteger(obj2), 1)) + 1.0)), 1));
                            break;

                        case "E":
                            obj2 = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(obj2, 1);
                            left = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(left, Strings.Mid(str4, (int) Math.Round((double) (Conversion.Val("&h" + Strings.Mid(expression, Conversions.ToInteger(obj2), 1)) + 1.0)), 1));
                            break;

                        case "F":
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectLessEqual(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(obj2, 2), Strings.Len(expression), false))
                            {
                                left = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(left, Strings.Chr((int) Math.Round(Conversion.Val(" &h" + Strings.Mid(expression, Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(obj2, 2)), 1) + Strings.Mid(expression, Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(obj2, 1)), 1)))));
                            }
                            obj2 = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(obj2, 2);
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

        public static byte[] EncodeText(string Text)
        {
            byte[] buffer2 = new byte[0x401];
            string expression = "";
            string str2 = " aehilnorst";
            string str3 = "ABCDEFGHIJKLMNOP";
            string str4 = "QRSTUVWXYZ012345";
            string str5 = "6789bcdfgjkmpquv";
            string str6 = "wxyz+-,!.?:;'*%$";
            int num4 = Strings.Len(Text);
            for (int i = 1; i <= num4; i++)
            {
                int num2 = Strings.InStr(str2, Strings.Mid(Text, i, 1), CompareMethod.Binary);
                if (num2 >= 1)
                {
                    expression = expression + Conversion.Hex((int) (num2 - 1));
                }
                else
                {
                    num2 = Strings.InStr(str3, Strings.Mid(Text, i, 1), CompareMethod.Binary);
                    if (num2 >= 1)
                    {
                        expression = expression + "B" + Conversion.Hex((int) (num2 - 1));
                    }
                    else
                    {
                        num2 = Strings.InStr(str4, Strings.Mid(Text, i, 1), CompareMethod.Binary);
                        if (num2 >= 1)
                        {
                            expression = expression + "C" + Conversion.Hex((int) (num2 - 1));
                        }
                        else
                        {
                            num2 = Strings.InStr(str5, Strings.Mid(Text, i, 1), CompareMethod.Binary);
                            if (num2 >= 1)
                            {
                                expression = expression + "D" + Conversion.Hex((int) (num2 - 1));
                            }
                            else
                            {
                                num2 = Strings.InStr(str6, Strings.Mid(Text, i, 1), CompareMethod.Binary);
                                if (num2 >= 1)
                                {
                                    expression = expression + "E" + Conversion.Hex((int) (num2 - 1));
                                }
                                else
                                {
                                    string str = Strings.Right("0" + Conversion.Hex(Strings.Asc(Strings.Mid(Text, i, 1))), 2);
                                    expression = expression + "F" + Strings.Mid(str, 2, 1) + Strings.Mid(str, 1, 1);
                                }
                            }
                        }
                    }
                }
            }
            if ((Strings.Len(expression) % 2) == 1)
            {
                expression = expression + "F";
            }
            double num5 = ((double) Strings.Len(expression)) / 2.0;
            for (double j = 1.0; j <= num5; j++)
            {
                buffer2[(int) Math.Round((double) (j - 1.0))] = (byte) Math.Round(Conversion.Val("&h" + Strings.Mid(expression, (int) Math.Round((double) (((j - 1.0) * 2.0) + 1.0)), 2)));
            }
            return (byte[]) Utils.CopyArray((Array) buffer2, new byte[((int) Math.Round((double) ((((double) Strings.Len(expression)) / 2.0) - 1.0))) + 1]);
        }

        internal static object GetBit(int Value, int Bit)
        {
            return (((long) Math.Round(Conversion.Int((double) (((double) Value) / Math.Pow(2.0, (double) Bit))))) & 1L);
        }

        internal static object GetBits(object Value, object FirstBit, object Count)
        {
            return Microsoft.VisualBasic.CompilerServices.Operators.AndObject(RuntimeHelpers.GetObjectValue(Conversion.Int(Microsoft.VisualBasic.CompilerServices.Operators.DivideObject(Value, Microsoft.VisualBasic.CompilerServices.Operators.ExponentObject(2, FirstBit)))), Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(Microsoft.VisualBasic.CompilerServices.Operators.ExponentObject(2, Count), 1));
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

        private static object ScratchPad()
        {
            object obj2;
            DataSet set = new DataSet();
            return obj2;
        }
    }
}

