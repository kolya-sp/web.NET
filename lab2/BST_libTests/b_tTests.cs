using Microsoft.VisualStudio.TestTools.UnitTesting;
using BST_lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace BST_lib.Tests
{
    [TestClass()]
    public class b_tTests
    {
        [TestMethod()]
        public void b_t_TestConstructor_NullTopReturned()
        {
            //arrage
            object expected = null;
            //act
            b_t<int, string> tree = new b_t<int, string>();
            object actual = tree.top;
            //assert
            Assert.AreEqual(expected,actual,"після запуску порожнього конструктора дерева його вершина не стала нал");
        }

        [TestMethod()]
        public void findTest_5value5insert_topReturned5value5()
        {
            //arrage
            int key = 5;
            string value = "value5";
            node<int, string> expected = new node<int, string>(key,value);
            //act
            b_t<int, string> tree = new b_t<int, string>();
            tree.top = expected;
            node<int, string> actual = tree.find(key);
            //assert
            Assert.AreEqual(expected.key, actual.key, "ключ 5 не знайдено");
            Assert.AreEqual(expected.key, actual.key, "значення і ключ не знайдено (5,value5) ");
        }

        [TestMethod()]
        public void existTest_5value5insert_5value5Returned()
        {
            //arrage
            int key = 5;
            string value = "value5";
            node<int, string> expected = new node<int, string>(key, value);
            //act
            b_t<int, string> tree = new b_t<int, string>();
            tree.top = expected;
            bool actual = tree.exist(key,value);
            //assert
            Assert.IsTrue(actual, "додане значення в дереві не знайдено");
        }

        [TestMethod()]
        public void findTest1_1value1insert_1value1Returned()
        {
            //arrage
            int key = 5;
            string value = "value5";
            node<int, string> expected = new node<int, string>(key, value);
            node<int, string> expected2 = new node<int, string>(1, "value1");
            //act
            b_t<int, string> tree = new b_t<int, string>();
            tree.top = expected;
            tree.top.left = expected2;
            node<int, string> actual = tree.find(1);
            //assert
            Assert.AreEqual(expected2.key, actual.key, "ключ 1 не знайдено");
            Assert.AreEqual(expected2.key, actual.key, "значення і ключ не знайдено (1,value1) ");
        }

        [TestMethod()]
        public void insertTest_5value5insert_5value5Returned()
        {
            //arrage
            int key = 5;
            string value = "value5";
            node<int, string> expected = new node<int, string>(key, value);
            //act
            b_t<int, string> tree = new b_t<int, string>();
            tree.insert(key, value);
            node<int, string> actual = tree.top;
            //assert
            Assert.AreEqual(expected.key, actual.key, "в вершину не додано ключ 5");
            Assert.AreEqual(expected.key, actual.key, "в вершину не додано значення value5");
        }
        // [ExpectedException(typeof(Exception), "виключення не відбулось")] можна було ловити цим, без перевірки тексту виключення
        [TestMethod()]
        public void insertTest_StringStringInsertInTreeIntString_ExeptionReturned()
        {
            //arrage
            string key = "1";
            string value = "value1";
            //act
            b_t<int, string> tree = new b_t<int, string>();
            var ExpectedException = typeof(Exception);
            try
            {
                tree.insert(key, value);
                Assert.Fail();
            }
            catch (Exception actEx)
            {
                //assert
                Assert.AreEqual(ExpectedException, actEx.GetType(), message: "виключення не відбулось");
                Assert.AreEqual(actEx.Message, "в дерево добавляють тип даних, який не вiдповiдає оголошеному при iнiцiалiзацiї дерева", message: "повідомлення в виключенні не співпало з очикуваним");
            }
        }

        [TestMethod()]
        public void LCRTest_5value5and1value1end7value7Insert_1value1and5value5and7value7Returned()
        {
            //arrage
            string expected = "(1,value1), (5,value5), (7,value7), ";
            //act
            b_t<int, string> tree = new b_t<int, string>();
            tree.insert(5, "value5");
            tree.insert(1, "value1");
            tree.insert(7, "value7");
            string actual = tree.LCR();
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LCRTest1_value5and2value2end7value7Insert_not1value1and5value5and7value7Returned()
        {
            //arrage
            string expected = "(1,value1), (5,value5), (7,value7), ";
            //act
            b_t<int, string> tree = new b_t<int, string>();
            tree.insert(5, "value5");
            tree.insert(2, "value2");
            tree.insert(7, "value7");
            string actual = tree.LCR();
            //assert
            Assert.IsTrue(expected.CompareTo(actual)!=0);
        }

        [TestMethod()]
        public void CLRTest_5value5and1value1end7value7Insert_5value5and1value1and7value7Returned()
        {
            //arrage
            string expected = "(5,value5), (1,value1), (7,value7), ";
            //act
            b_t<int, string> tree = new b_t<int, string>();
            tree.insert(5, "value5");
            tree.insert(1, "value1");
            tree.insert(7, "value7");
            string actual = tree.CLR();
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CLRTest1_nodesInsert_nodsReturned()
        {
            //arrage
            string expected = "(5,value5), (1,value1), (7,value7), ";
            //act
            b_t<int, string> tree = new b_t<int, string>();
            tree.insert(5, "value5");
            tree.insert(2, "value2");
            tree.insert(7, "value7");
            string actual = tree.LCR();
            //assert
            Assert.IsTrue(expected.CompareTo(actual) != 0);
        }

        [TestMethod()]
        public void LRCTest_nodesInsert_nodsReturned()
        {
            //arrage
            string expected = "(1,value1), (7,value7), (5,value5), ";
            //act
            b_t<int, string> tree = new b_t<int, string>();
            tree.insert(5, "value5");
            tree.insert(7, "value7");
            tree.insert(1, "value1");
            string actual = tree.LRC();
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LRCTest1_nodesInsert_nodsReturned()
        {
            //arrage
            string expected = "(1,value1), (7,value7), (5,value5), ";
            //act
            b_t<int, string> tree = new b_t<int, string>();
            tree.insert(5, "value5");
            tree.insert(2, "value2");
            tree.insert(7, "value7");
            string actual = tree.LRC();
            //assert
            Assert.IsTrue(expected.CompareTo(actual) != 0);
        }

        [TestMethod()]
        public void GetEnumeratorTest_3nodesInsert_3nodsReturned()
        {
            //arrage
            node<int, string> node1 = new node<int, string>(1, "value1");
            node<int, string> node2 = new node<int, string>(2, "value2");
            node<int, string> node3 = new node<int, string>(3, "value3");
            //act
            b_t<int, string> tree = new b_t<int, string>();
            tree.insert(node2.key, node2.value);
            tree.insert(node1.key, node1.value);
            tree.insert(node3.key, node3.value);
            IEnumerator<node<int, string>> TreeInumerator=tree.GetEnumerator();
            TreeInumerator.MoveNext();
            node<int, string> actual1 = TreeInumerator.Current;
            TreeInumerator.MoveNext();
            node<int, string> actual2 = TreeInumerator.Current; 
            TreeInumerator.MoveNext();
            node<int, string> actual3 = TreeInumerator.Current; ;
            //assert
            Assert.AreEqual(node1.key, actual1.key, $"{node1.key}!={actual1.key}");
            Assert.AreEqual(node1.value, actual1.value, $"{node1.value}!={actual1.value}");
            Assert.AreEqual(node2.key, actual2.key, $"{node2.key}!={actual2.key}");
            Assert.AreEqual(node2.value, actual2.value, $"{node2.value}!={actual2.value}");
            Assert.AreEqual(node3.key, actual3.key, $"{node3.key}!={actual3.key}");
            Assert.AreEqual(node3.value, actual3.value, $"{node3.value}!={actual3.value}");
        }

        [TestMethod()]
        public void GetEnumeratorTest_4nodesInsert_4nodsReturned()
        {
            //arrage
            node<int, string> node1 = new node<int, string>(1, "value1");
            node<int, string> node2 = new node<int, string>(2, "value2");
            node<int, string> node3 = new node<int, string>(3, "value3");
            node<int, string> node4 = new node<int, string>(5, "value5");
            //act
            b_t<int, string> tree = new b_t<int, string>();
            tree.insert(node2.key, node2.value);
            tree.insert(node1.key, node1.value);
            tree.insert(node4.key, node4.value);
            tree.insert(node3.key, node3.value);
            IEnumerator<node<int, string>> TreeInumerator = tree.GetEnumerator();
            TreeInumerator.MoveNext();
            node<int, string> actual1 = TreeInumerator.Current;
            TreeInumerator.MoveNext();
            node<int, string> actual2 = TreeInumerator.Current;
            TreeInumerator.MoveNext();
            node<int, string> actual3 = TreeInumerator.Current; ;
            TreeInumerator.MoveNext();
            node<int, string> actual4 = TreeInumerator.Current; ;
            //assert
            Assert.AreEqual(node1.key, actual1.key, $"{node1.key}!={actual1.key}");
            Assert.AreEqual(node1.value, actual1.value, $"{node1.value}!={actual1.value}");
            Assert.AreEqual(node2.key, actual2.key, $"{node2.key}!={actual2.key}");
            Assert.AreEqual(node2.value, actual2.value, $"{node2.value}!={actual2.value}");
            Assert.AreEqual(node3.key, actual3.key, $"{node3.key}!={actual3.key}");
            Assert.AreEqual(node3.value, actual3.value, $"{node3.value}!={actual3.value}");
            Assert.AreEqual(node4.key, actual4.key, $"{node4.key}!={actual4.key}");
            Assert.AreEqual(node4.value, actual4.value, $"{node3.value}!={actual4.value}");
        }
    }
}