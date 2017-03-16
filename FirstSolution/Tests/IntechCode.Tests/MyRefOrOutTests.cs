using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace IntechCode.Tests
{
    public class MyRefOrOutTests
    {
        [Fact]
        public void typeref_demo()
        {
            int i = 0;
            //Il faut mettre le ref sinon ça ne fonctionne pas
            IchangeMyParam(ref i);
            i.Should().Be(950);
            //Il faut mettre le out
            IInitializeMyParam(out i);
            int j;
            IInitializeMyParam(out j);
        }

        static void IchangeMyParam(ref int param)=> param += 950;

        static void IInitializeMyParam(out int param) => param = 123;

    }
}
