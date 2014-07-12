namespace StarsSupremacyHostDLL
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.CompilerServices;

    [StandardModule]
    internal sealed class Functions
    {
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
    }
}

