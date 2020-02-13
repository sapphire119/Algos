namespace RedBlackTree.Tests.CorrectnessTests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class DeleteCases
    {
        [Test]
        public void Delete_root()
        {
            RedBlackTree<int> rbt = new RedBlackTree<int>();
            rbt.Insert(10);

            Assert.Catch<InvalidOperationException>(() => rbt.Delete(10));
        }

        [Test]
        public void Delete_null()
        {
            RedBlackTree<int> rbt = new RedBlackTree<int>();

            Assert.Catch<InvalidOperationException>(() => rbt.Delete(10));
        }

        [Test]
        public void Delete_10()
        {
            //Assemble
            RedBlackTree<int> rbt = new RedBlackTree<int>();
            rbt.Insert(20);
            rbt.Insert(10);
            rbt.Insert(30);
            rbt.Insert(5);
            rbt.Delete(5);

            //Act
            rbt.Delete(10);
            
            // Assert
            List<int> nodes = new List<int>();
            rbt.EachInOrder(nodes.Add);
            int[] expectedNodes = new int[] { 20, 30 };

            CollectionAssert.AreEqual(expectedNodes, nodes);
        }
        
        [Test]
        public void Delete_6()
        {
            //Assemble
            RedBlackTree<int> rbt = new RedBlackTree<int>();
            rbt.Insert(13);
            rbt.Insert(8);
            rbt.Insert(17);
            rbt.Insert(1);
            rbt.Insert(11);
            rbt.Insert(15);
            rbt.Insert(25);
            rbt.Insert(6);
            rbt.Insert(22);
            rbt.Insert(27);

            //Act
            rbt.Delete(6);
            
            // Assert
            List<int> nodes = new List<int>();
            rbt.EachInOrder(nodes.Add);
            int[] expectedNodes = new int[] { 1, 8, 11, 13, 15, 17, 22, 25, 27 };

            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void Delete_1()
        {
            RedBlackTree<int> rbt = new RedBlackTree<int>();
            rbt.Insert(13);
            rbt.Insert(8);
            rbt.Insert(17);
            rbt.Insert(1);
            rbt.Insert(11);
            rbt.Insert(15);
            rbt.Insert(25);
            rbt.Insert(6);
            rbt.Insert(22);
            rbt.Insert(27);

            rbt.Delete(1);

            List<int> nodes = new List<int>();
            rbt.EachInOrder(nodes.Add);
            ;
            // Assert
            int[] expectedNodes = new int[] { 6, 8, 11, 13, 15, 17, 22, 25, 27 };

            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void Delete_17()
        {
            RedBlackTree<int> rbt = new RedBlackTree<int>();
            rbt.Insert(13);
            rbt.Insert(8);
            rbt.Insert(17);
            rbt.Insert(1);
            rbt.Insert(11);
            rbt.Insert(15);
            rbt.Insert(25);
            rbt.Insert(6);
            rbt.Insert(22);
            rbt.Insert(27);

            rbt.Delete(17);

            List<int> nodes = new List<int>();
            rbt.EachInOrder(nodes.Add);
            ;
            // Assert
            int[] expectedNodes = new int[] { 1, 6, 8, 11, 13, 15, 22, 25, 27 };

            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void Delete_25()
        {
            RedBlackTree<int> rbt = new RedBlackTree<int>();
            rbt.Insert(13);
            rbt.Insert(8);
            rbt.Insert(17);
            rbt.Insert(1);
            rbt.Insert(11);
            rbt.Insert(15);
            rbt.Insert(25);
            rbt.Insert(6);
            rbt.Insert(22);
            rbt.Insert(27);

            rbt.Delete(25);

            List<int> nodes = new List<int>();
            rbt.EachInOrder(nodes.Add);
            ;
            // Assert
            int[] expectedNodes = new int[] { 1, 6, 8, 11, 13, 15, 17, 22, 27 };

            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void Delete_18()
        {
            RedBlackTree<int> rbt = new RedBlackTree<int>();
            rbt.Insert(7);
            rbt.Insert(3);
            rbt.Insert(18);
            rbt.Insert(10);
            rbt.Insert(22);
            rbt.Insert(8);
            rbt.Insert(11);
            rbt.Insert(26);

            rbt.Delete(18);

            List<int> nodes = new List<int>();
            rbt.EachInOrder(nodes.Add);
            ;
            // Assert
            int[] expectedNodes = new int[] { 3, 7, 8, 10, 11, 22, 26 };

            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void Delete_2()
        {
            RedBlackTree<int> rbt = new RedBlackTree<int>();
            rbt.Insert(5);
            rbt.Insert(2);
            rbt.Insert(8);
            rbt.Insert(1);
            rbt.Insert(4);
            rbt.Insert(7);
            rbt.Insert(9);
            rbt.Insert(3);

            rbt.Delete(3);
            rbt.Delete(2);

            List<int> nodes = new List<int>();
            rbt.EachInOrder(nodes.Add);
            ;
            // Assert
            int[] expectedNodes = new int[] { 1, 4, 5, 7, 8, 9 };

            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void Delete_13()
        {
            RedBlackTree<int> rbt = new RedBlackTree<int>();
            rbt.Insert(13);
            rbt.Insert(8);
            rbt.Insert(17);
            rbt.Insert(1);
            rbt.Insert(11);
            rbt.Insert(15);
            rbt.Insert(25);
            rbt.Insert(6);
            rbt.Insert(22);
            rbt.Insert(27);

            rbt.Delete(13);

            List<int> nodes = new List<int>();
            rbt.EachInOrder(nodes.Add);
            ;
            // Assert
            int[] expectedNodes = new int[] { 1, 6, 8, 11, 15, 17, 22, 25, 27 };

            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void Delete_8()
        {
            RedBlackTree<int> rbt = new RedBlackTree<int>();
            rbt.Insert(13);
            rbt.Insert(8);
            rbt.Insert(17);
            rbt.Insert(1);
            rbt.Insert(11);
            rbt.Insert(15);
            rbt.Insert(25);
            rbt.Insert(6);
            rbt.Insert(22);
            rbt.Insert(27);

            rbt.Delete(8);

            List<int> nodes = new List<int>();
            rbt.EachInOrder(nodes.Add);
            ;
            // Assert
            int[] expectedNodes = new int[] { 1, 6, 11, 13, 15, 17, 22, 25, 27 };

            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void Delete_3()
        {
            RedBlackTree<int> rbt = new RedBlackTree<int>();
            rbt.Insert(7);
            rbt.Insert(3);
            rbt.Insert(18);
            rbt.Insert(10);
            rbt.Insert(22);
            rbt.Insert(8);
            rbt.Insert(11);
            rbt.Insert(26);

            rbt.Delete(3);

            List<int> nodes = new List<int>();
            rbt.EachInOrder(nodes.Add);
            ;
            // Assert
            int[] expectedNodes = new int[] { 7, 8, 10, 11, 18, 22, 26 };

            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void Delete_11()
        {
            RedBlackTree<int> rbt = new RedBlackTree<int>();
            rbt.Insert(13);
            rbt.Insert(8);
            rbt.Insert(17);
            rbt.Insert(1);
            rbt.Insert(11);
            rbt.Insert(15);
            rbt.Insert(25);
            rbt.Insert(6);
            rbt.Insert(22);
            rbt.Insert(27);

            rbt.Delete(11);

            List<int> nodes = new List<int>();
            rbt.EachInOrder(nodes.Add);
            ;
            // Assert
            int[] expectedNodes = new int[] { 1, 6, 8, 13, 15, 17, 22, 25, 27 };

            CollectionAssert.AreEqual(expectedNodes, nodes);
        }
    }
}
