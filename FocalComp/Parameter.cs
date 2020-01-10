using System;
using System.Collections.Generic;
using System.Text;

namespace FocalCompiler
{
    public class Parameter
    {
        Dictionary<String, short> StackParamter;
        Dictionary<String, short> ShortLabelParamter;

        /////////////////////////////////////////////////////////////

        public Parameter ()
        {
            StackParamter = new Dictionary<string, short> ();

            StackParamter.Add ("T", 112);
            StackParamter.Add ("Z", 113);
            StackParamter.Add ("Y", 114);
            StackParamter.Add ("X", 115);
            StackParamter.Add ("L", 116);
            StackParamter.Add ("M", 117);
            StackParamter.Add ("N", 118);
            StackParamter.Add ("O", 119);
            StackParamter.Add ("P", 120);
            StackParamter.Add ("Q", 121);
            StackParamter.Add ("R", 122);
            StackParamter.Add ("A", 123);
            StackParamter.Add ("B", 124);
            StackParamter.Add ("C", 125);
            StackParamter.Add ("D", 126);
            StackParamter.Add ("E", 127);

            ShortLabelParamter = new Dictionary<string, short> ();

            ShortLabelParamter.Add ("A", 102);
            ShortLabelParamter.Add ("B", 103);
            ShortLabelParamter.Add ("C", 104);
            ShortLabelParamter.Add ("D", 105);
            ShortLabelParamter.Add ("E", 106);
            ShortLabelParamter.Add ("F", 107);
            ShortLabelParamter.Add ("G", 108);
            ShortLabelParamter.Add ("H", 109);
            ShortLabelParamter.Add ("I", 110);
            ShortLabelParamter.Add ("J", 111);
            ShortLabelParamter.Add ("a", 123);
            ShortLabelParamter.Add ("b", 124);
            ShortLabelParamter.Add ("c", 125);
            ShortLabelParamter.Add ("d", 126);
            ShortLabelParamter.Add ("e", 127);
        }

        /////////////////////////////////////////////////////////////

        public bool GetStackParamter (String Parameter, out short Value)
        {
            Value = 0;

            if (StackParamter.TryGetValue (Parameter.ToUpper(), out Value))
                return true;

            return false;
        }

        /////////////////////////////////////////////////////////////

        public bool GetShortLabelParamter (String Parameter, out short Value)
        {
            Value = 0;

            if (ShortLabelParamter.TryGetValue (Parameter, out Value))
                return true;

            return false;
        }
    }
}
