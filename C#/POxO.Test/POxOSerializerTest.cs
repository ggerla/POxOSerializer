﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;

namespace POxO.Test
{
    
    
    /// <summary>
    ///This is a test class for POxOSerializerTest and is intended
    ///to contain all POxOSerializerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class POxOSerializerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //

        private static PrimitiveClassesContainer classToTest;

        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            classToTest = new PrimitiveClassesContainer();

            classToTest.BNotNull = (sbyte)0x7F;
            classToTest.CNotNull = 'c';
            classToTest.SNotNull = (short)32000;
            classToTest.INotNull = 1000000000;
            classToTest.LNotNull = 4000000000L;
            classToTest.St = "test ascii string";
            classToTest.StUTF8 = "SãoVicente";
            classToTest.BoNotNull = true;
            classToTest.Timestamp = DateTime.Now;
            classToTest.FNotNull = 125.758F;
            classToTest.DNotNull = 6546874.16513154644;
            classToTest.EnumValue = TestEnum.NOTWORK;

            List<Int32> ints = new List<Int32>();
            ints.Add(123);
            ints.Add(456);
            ints.Add(789);

            List<String> strings = new List<String>();
            strings.Add("pippo");
            strings.Add("pluto");
            strings.Add("paperino");

            List<SByte> bytes = new List<SByte>();
            bytes.Add(1);
            bytes.Add(106);
            bytes.Add(97);
            bytes.Add(118);
            bytes.Add(97);
            bytes.Add(46);
            bytes.Add(117);
            bytes.Add(116);
            bytes.Add(105);
            bytes.Add(108);
            bytes.Add(46);
            bytes.Add(65);
            bytes.Add(114);
            bytes.Add(114);
            bytes.Add(97);
            bytes.Add(121);
            bytes.Add(76);
            bytes.Add(105);
            bytes.Add(115);
            bytes.Add(-12);
            bytes.Add(1);
            bytes.Add(91);
            bytes.Add(76);
            bytes.Add(106);
            bytes.Add(97);
            bytes.Add(118);
            bytes.Add(97);
            bytes.Add(46);
            bytes.Add(108);
            bytes.Add(97);
            bytes.Add(110);
            bytes.Add(103);
            bytes.Add(46);
            bytes.Add(79);
            bytes.Add(98);
            bytes.Add(106);
            bytes.Add(101);
            bytes.Add(99);
            bytes.Add(116);
            bytes.Add(-69);
            bytes.Add(22);
            bytes.Add(22);

            Dictionary<String, Double> map = new Dictionary<String, Double>();
            map.Add("A", 123.4560);
            map.Add("B", 456.7890);
            map.Add("C", 789.1230);
            map.Add("D", 147.2580);

            classToTest.Ints = ints;
            classToTest.Strings = strings;
            classToTest.Map = map;
            classToTest.Bytes = bytes;

            IList<IDictionary<String, IList<Int32>>> nestedCollections = new List<IDictionary<String, IList<Int32>>>();
            IDictionary<String, IList<Int32>> map2 = new Dictionary<String, IList<Int32>>();
            map2.Add("test", ints);
            nestedCollections.Add(map2);
            classToTest.NestedCollections = nestedCollections;

            NestedObjectClass nestedClass = new NestedObjectClass();
            nestedClass.Index = 50;
            List<NestedObjectClass> listNestedClass = new List<NestedObjectClass>();
            listNestedClass.Add(nestedClass);
            classToTest.NestedClass = listNestedClass;

            Dictionary<String, Object> genericValueMap = new Dictionary<String, Object>();
            genericValueMap.Add("bool", true);
            genericValueMap.Add("int", 74);
            genericValueMap.Add("string", "pippo");
            genericValueMap.Add("object", nestedClass);
            genericValueMap.Add("enum", TestEnum.WORK);
            classToTest.GenericValueMap = genericValueMap;
        }
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for serialize
        ///</summary>
        [TestMethod()]
        public void serializerTest()
        {
            POxOSerializer serializer = new POxOSerializer();
            PrimitiveClassesContainer retB = null;
            retB = (PrimitiveClassesContainer)serializer.deserialize(serializer.serialize(classToTest));

            Assert.AreEqual(retB.BNotNull, classToTest.BNotNull);
            Assert.AreEqual(retB.CNotNull, classToTest.CNotNull);
            Assert.AreEqual(retB.SNotNull, classToTest.SNotNull);
            Assert.AreEqual(retB.INotNull, classToTest.INotNull);
            Assert.AreEqual(retB.LNotNull, classToTest.LNotNull);
            Assert.AreEqual(retB.St, classToTest.St);
            Assert.AreEqual(retB.StUTF8, classToTest.StUTF8);
            Assert.AreEqual(retB.BoNotNull, classToTest.BoNotNull);
            Assert.AreEqual(retB.Timestamp, classToTest.Timestamp);
            Assert.AreEqual(retB.FNotNull, classToTest.FNotNull);
            Assert.AreEqual(retB.DNotNull, classToTest.DNotNull);
            Assert.AreEqual(retB.EnumValue, classToTest.EnumValue);
            
            Assert.AreEqual(retB.BCanNull, classToTest.BCanNull);
            Assert.AreEqual(retB.CCanNull, classToTest.CCanNull);
            Assert.AreEqual(retB.SCanNull, classToTest.SCanNull);
            Assert.AreEqual(retB.ICanNull, classToTest.ICanNull);
            Assert.AreEqual(retB.LCanNull, classToTest.LCanNull);
            
            Assert.AreEqual(retB.Ints.Count, classToTest.Ints.Count);
            Assert.AreEqual(retB.Bytes.Count, classToTest.Bytes.Count);
            Assert.AreEqual(retB.Map.Count, classToTest.Map.Count);
            Assert.AreEqual(retB.NestedCollections.Count, classToTest.NestedCollections.Count);
            Assert.AreEqual(retB.NestedCollections[0].Count, classToTest.NestedCollections[0].Count);
            Assert.AreEqual((retB.NestedCollections[0])["test"][2], (classToTest.NestedCollections[0])["test"][2]);
            Assert.AreEqual(retB.NestedClass[0].Index, classToTest.NestedClass[0].Index);

            Assert.AreEqual(retB.GenericValueMap["bool"], classToTest
                .GenericValueMap["bool"]);
            Assert.AreEqual(retB.GenericValueMap["int"], classToTest
                    .GenericValueMap["int"]);
            Assert.AreEqual(retB.GenericValueMap["string"], classToTest
                    .GenericValueMap["string"]);
            Assert.AreEqual(true, retB.GenericValueMap["object"] is NestedObjectClass);
            Assert.AreEqual(((NestedObjectClass)retB.GenericValueMap["object"]).Index,
                    ((NestedObjectClass)classToTest.GenericValueMap["object"]).Index);
        }

        /// <summary>
        ///A test for list serialize
        ///</summary>
        [TestMethod()]
        public void listSerializerTest()
        {
            List<Object> list = new List<Object>();
            list.Add(classToTest);
            POxOSerializer serializer = new POxOSerializer();
            List<Object> listB = null;
            listB = (List<Object>)serializer.deserialize(serializer.serialize(list));

            Assert.AreEqual(listB.Count, list.Count);

            PrimitiveClassesContainer retB = listB[0] as PrimitiveClassesContainer;
            Assert.AreEqual(retB.BNotNull, classToTest.BNotNull);
            Assert.AreEqual(retB.CNotNull, classToTest.CNotNull);
            Assert.AreEqual(retB.SNotNull, classToTest.SNotNull);
            Assert.AreEqual(retB.INotNull, classToTest.INotNull);
            Assert.AreEqual(retB.LNotNull, classToTest.LNotNull);
            Assert.AreEqual(retB.St, classToTest.St);
            Assert.AreEqual(retB.StUTF8, classToTest.StUTF8);
            Assert.AreEqual(retB.BoNotNull, classToTest.BoNotNull);
            Assert.AreEqual(retB.Timestamp, classToTest.Timestamp);
            Assert.AreEqual(retB.FNotNull, classToTest.FNotNull);
            Assert.AreEqual(retB.DNotNull, classToTest.DNotNull);
            Assert.AreEqual(retB.EnumValue, classToTest.EnumValue);

            Assert.AreEqual(retB.BCanNull, classToTest.BCanNull);
            Assert.AreEqual(retB.CCanNull, classToTest.CCanNull);
            Assert.AreEqual(retB.SCanNull, classToTest.SCanNull);
            Assert.AreEqual(retB.ICanNull, classToTest.ICanNull);
            Assert.AreEqual(retB.LCanNull, classToTest.LCanNull);

            Assert.AreEqual(retB.Ints.Count, classToTest.Ints.Count);
            Assert.AreEqual(retB.Bytes.Count, classToTest.Bytes.Count);
            Assert.AreEqual(retB.Map.Count, classToTest.Map.Count);
            Assert.AreEqual(retB.NestedCollections.Count, classToTest.NestedCollections.Count);
            Assert.AreEqual(retB.NestedCollections[0].Count, classToTest.NestedCollections[0].Count);
            Assert.AreEqual((retB.NestedCollections[0])["test"][2], (classToTest.NestedCollections[0])["test"][2]);
            Assert.AreEqual(retB.NestedClass[0].Index, classToTest.NestedClass[0].Index);

            Assert.AreEqual(retB.GenericValueMap["bool"], classToTest
                .GenericValueMap["bool"]);
            Assert.AreEqual(retB.GenericValueMap["int"], classToTest
                    .GenericValueMap["int"]);
            Assert.AreEqual(retB.GenericValueMap["string"], classToTest
                    .GenericValueMap["string"]);
            Assert.AreEqual(true, retB.GenericValueMap["object"] is NestedObjectClass);
            Assert.AreEqual(((NestedObjectClass)retB.GenericValueMap["object"]).Index,
                    ((NestedObjectClass)classToTest.GenericValueMap["object"]).Index);
        }

        /// <summary>
        ///A test for list serialize
        ///</summary>
        [TestMethod()]
        public void dictionarySerializerTest()
        {
            IDictionary<Object, Object> dictionary = new Dictionary<Object, Object>();
            dictionary.Add("key", classToTest);
            POxOSerializer serializer = new POxOSerializer();
            IDictionary<Object, Object> dictiornaryB = null;
            dictiornaryB = (IDictionary<Object, Object>)serializer.deserialize(serializer.serialize(dictionary));

            Assert.AreEqual(dictiornaryB.Count, dictionary.Count);

            IEnumerator en = dictiornaryB.Keys.GetEnumerator();
            en.MoveNext();
            Object key = en.Current;
            Assert.AreEqual(key, "key");
            PrimitiveClassesContainer retB = dictiornaryB[key] as PrimitiveClassesContainer;
            Assert.AreEqual(retB.BNotNull, classToTest.BNotNull);
            Assert.AreEqual(retB.CNotNull, classToTest.CNotNull);
            Assert.AreEqual(retB.SNotNull, classToTest.SNotNull);
            Assert.AreEqual(retB.INotNull, classToTest.INotNull);
            Assert.AreEqual(retB.LNotNull, classToTest.LNotNull);
            Assert.AreEqual(retB.St, classToTest.St);
            Assert.AreEqual(retB.StUTF8, classToTest.StUTF8);
            Assert.AreEqual(retB.BoNotNull, classToTest.BoNotNull);
            Assert.AreEqual(retB.Timestamp, classToTest.Timestamp);
            Assert.AreEqual(retB.FNotNull, classToTest.FNotNull);
            Assert.AreEqual(retB.DNotNull, classToTest.DNotNull);
            Assert.AreEqual(retB.EnumValue, classToTest.EnumValue);

            Assert.AreEqual(retB.BCanNull, classToTest.BCanNull);
            Assert.AreEqual(retB.CCanNull, classToTest.CCanNull);
            Assert.AreEqual(retB.SCanNull, classToTest.SCanNull);
            Assert.AreEqual(retB.ICanNull, classToTest.ICanNull);
            Assert.AreEqual(retB.LCanNull, classToTest.LCanNull);

            Assert.AreEqual(retB.Ints.Count, classToTest.Ints.Count);
            Assert.AreEqual(retB.Bytes.Count, classToTest.Bytes.Count);
            Assert.AreEqual(retB.Map.Count, classToTest.Map.Count);
            Assert.AreEqual(retB.NestedCollections.Count, classToTest.NestedCollections.Count);
            Assert.AreEqual(retB.NestedCollections[0].Count, classToTest.NestedCollections[0].Count);
            Assert.AreEqual((retB.NestedCollections[0])["test"][2], (classToTest.NestedCollections[0])["test"][2]);
            Assert.AreEqual(retB.NestedClass[0].Index, classToTest.NestedClass[0].Index);

            Assert.AreEqual(retB.GenericValueMap["bool"], classToTest
                .GenericValueMap["bool"]);
            Assert.AreEqual(retB.GenericValueMap["int"], classToTest
                    .GenericValueMap["int"]);
            Assert.AreEqual(retB.GenericValueMap["string"], classToTest
                    .GenericValueMap["string"]);
            Assert.AreEqual(true, retB.GenericValueMap["object"] is NestedObjectClass);
            Assert.AreEqual(((NestedObjectClass)retB.GenericValueMap["object"]).Index,
                    ((NestedObjectClass)classToTest.GenericValueMap["object"]).Index);
        }
    }
}
