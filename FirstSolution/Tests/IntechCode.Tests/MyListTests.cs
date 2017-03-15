
﻿using IntechCode.IntechCollection;
﻿using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntechCode.Tests
{
    [NUnit.Framework.TestFixture]
    public class MyListTests
    {
        [NUnit.Framework.Test]
        [Fact]
        public void MyListIsInitialEmpty()
        {
            //Arrange
            var myList = new MyList<int>();
            //Act

            //Assert
            Assert.Equal(myList.Count, 0);
        }

        [NUnit.Framework.Test]
        [Fact]
        public void AddItemToMyListShouldReturnFive()
        {
            //Arrange
            var myList = new MyList<int>();
            //Act
            myList.Add(5);
            //Assert
            Assert.Equal(myList[0], 5);
        }

        [NUnit.Framework.Test]
        [Fact]
        public void RemoveFirstItemToMyListShouldReturnZero()
        {
            var myList = new MyList<int>();
            myList.Add(5);
            Assert.Equal(myList[0], 5);
            myList.RemoveAt(0);
            Assert.Equal(myList.Count, 0);
        }


        [NUnit.Framework.Test]
        [Fact]
        public void InsertItemToMyListShouldReturnFive()
        {
            var myList = new MyList<int>();
            myList.Insert(0, 5);
            Assert.Equal(myList[0], 5);
        }

        public void RetrieveIndexOfItemToMyListShouldReturnZero()
        {
            var myList = new MyList<int>();
            myList.Insert(0, 5);
            Assert.Equal(myList[0], 5);
            int index = myList.IndexOf(5);
            Assert.Equal(index, 0);
        }
        public void RetrieveIndexOfNoExistItemToMyListShouldReturnMinusOne()
        {
            var myList = new MyList<int>();
            int index = myList.IndexOf(5);
            Assert.Equal(index, -1);
        }
        public void MyList_supports_foreach()
        {
            var l = new MyList<int>();
            l.Add(3712);
            int nbTurn = 0;
            foreach( var item in l )
            {
                ++nbTurn;
                item.Should().Be(3712);
            }
            nbTurn.Should().Be(1);
        }
    }
}
