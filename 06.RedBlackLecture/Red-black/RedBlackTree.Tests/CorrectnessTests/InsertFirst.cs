﻿using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
class InsertFirst
{
    [Test]
    public void Insert_SingleElement_ShouldIncreaseCount()
    {
        RedBlackTree<int> rbt = new RedBlackTree<int>();
        rbt.Insert(5);

        Assert.AreEqual(1, rbt.Count());
    }
}
