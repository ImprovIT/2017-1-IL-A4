using System;
using System.Collections.Generic;
using System.Text;

namespace IntechCode.Tests.Animals
{
    class Cat: Animal
    {
        public override sealed string Shout() => "Miaou"; //sealed permet de verouiller
    }
}
