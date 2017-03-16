using System;
using System.Collections.Generic;
using System.Text;

namespace IntechCode.Tests.Animals
{
    abstract class Animal
    {
        public String Name { get; set; }

        public abstract string Shout();

    }
}
