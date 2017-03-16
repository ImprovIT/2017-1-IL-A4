using FluentAssertions;
using IntechCode.IntechCollection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntechCode.Tests.Animals
{
    [NUnit.Framework.TestFixture]
    public class AnimalTests
    {
        [NUnit.Framework.Test]
        [Fact]
        public void The_array_is_not_a_safe_beast()
        {
            //Arrange
            Animal[] animals = new Animal[5];
            //Act
            animals[0] = new Dog();
            animals[1] = new Cat();

            object[] a0 = animals;

            Action bug = () => a0[2] = "Hello";
            //Assert
            bug.ShouldThrow<ArrayTypeMismatchException>();
        }

        public void co_and_contre_variance()
        {
            IMyEnumerator<Dog> eDog =  null;
            IMyEnumerator<Animal> eAnimal = null;
            DumpAnimals(eAnimal);
            DumpAnimals(eDog);
        }

        static void DumpAnimals(IMyEnumerator<Animal> animals)
        {

        }

        static void DumpDogs(IMyEnumerator<Dog> dogs)
        {

        }
    }
}
