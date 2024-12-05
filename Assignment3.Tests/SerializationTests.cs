using Assignment3;

namespace Assignment3.Tests
{
    public class SerializationTests
    {
        private ILinkedListADT users;
        private readonly string testFileName = "test_users.bin";

        [SetUp]
        public void Setup()
        {
            // Uncomment the following line
            this.users = new SLL();

            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        [TearDown]
        public void TearDown()
        {
            this.users.Clear();
        }

        /// <summary>
        /// Tests the object was serialized.
        /// </summary>
        [Test]
        public void TestSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            Assert.IsTrue(File.Exists(testFileName));
        }

        /// <summary>
        /// Tests the object was deserialized.
        /// </summary>
        [Test]
        public void TestDeSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            ILinkedListADT deserializedUsers = SerializationHelper.DeserializeUsers(testFileName);
            
            Assert.IsTrue(users.Count() == deserializedUsers.Count());
            
            for (int i = 0; i < users.Count(); i++)
            {
                User expected = users.GetValue(i);
                User actual = deserializedUsers.GetValue(i);

                Assert.AreEqual(expected.Id, actual.Id);
                Assert.AreEqual(expected.Name, actual.Name);
                Assert.AreEqual(expected.Email, actual.Email);
                Assert.AreEqual(expected.Password, actual.Password);
            }
        }
        public class LinkedListTest
        {
            private ILinkedListADT list;

            [SetUp]
            public void Setup()
            {
                this.list = new SLL();
            }

            [TearDown]
            public void TearDown()
            {
                this.list.Clear();
            }

            /// <summary>
            /// Tests that the linked list is initially empty.
            /// </summary>
            [Test]
            public void TestIsEmpty()
            {
                Assert.IsTrue(list.IsEmpty());
            }

            /// <summary>
            /// Tests that an item can be prepended to the list.
            /// </summary>
            [Test]
            public void TestPrepend()
            {
                var user = new User(1, "John Doe", "john@example.com", "password");
                list.AddFirst(user);
                Assert.AreEqual(user, list.GetValue(0));
            }

            /// <summary>
            /// Tests that an item can be appended to the list.
            /// </summary>
            [Test]
            public void TestAppend()
            {
                var user = new User(2, "Jane Doe", "jane@example.com", "12345");
                list.AddLast(user);
                Assert.AreEqual(user, list.GetValue(list.Count() - 1));
            }

            /// <summary>
            /// Tests that an item can be inserted at a specific index.
            /// </summary>
            [Test]
            public void TestInsertAtIndex()
            {
                list.AddLast(new User(1, "A", "a@example.com", "a"));
                list.AddLast(new User(2, "C", "c@example.com", "c"));
                var user = new User(3, "B", "b@example.com", "b");

                list.Add(user, 1); // Insert at index 1
                Assert.AreEqual(user, list.GetValue(1));
            }

            /// <summary>
            /// Tests that an item can be replaced at a specific index.
            /// </summary>
            [Test]
            public void TestReplace()
            {
                list.AddLast(new User(1, "A", "a@example.com", "a"));
                var newUser = new User(2, "B", "b@example.com", "b");

                list.Replace(newUser, 0); // Replace at index 0
                Assert.AreEqual(newUser, list.GetValue(0));
            }

            /// <summary>
            /// Tests that an item can be removed from the beginning of the list.
            /// </summary>
            [Test]
            public void TestRemoveFirst()
            {
                list.AddLast(new User(1, "A", "a@example.com", "a"));
                list.AddLast(new User(2, "B", "b@example.com", "b"));

                list.RemoveFirst();
                Assert.AreEqual("B", list.GetValue(0).Name);
            }

            /// <summary>
            /// Tests that an item can be removed from the end of the list.
            /// </summary>
            [Test]
            public void TestRemoveLast()
            {
                list.AddLast(new User(1, "A", "a@example.com", "a"));
                list.AddLast(new User(2, "B", "b@example.com", "b"));

                list.RemoveLast();
                Assert.AreEqual(1, list.Count());
                Assert.AreEqual("A", list.GetValue(0).Name);
            }

            /// <summary>
            /// Tests that an item can be removed from the middle of the list.
            /// </summary>
            [Test]
            public void TestRemoveMiddle()
            {
                list.AddLast(new User(1, "A", "a@example.com", "a"));
                list.AddLast(new User(2, "B", "b@example.com", "b"));
                list.AddLast(new User(3, "C", "c@example.com", "c"));

                list.Remove(1); // Remove item at index 1
                Assert.AreEqual(2, list.Count());
                Assert.AreEqual("C", list.GetValue(1).Name);
            }

            /// <summary>
            /// Tests that an existing item can be found and retrieved.
            /// </summary>
            [Test]
            public void TestFindAndRetrieve()
            {
                var user = new User(1, "A", "a@example.com", "a");
                list.AddLast(user);

                int index = list.IndexOf(user);
                Assert.AreEqual(0, index);
                Assert.AreEqual(user, list.GetValue(index));
            }

            /// <summary>
            /// Tests additional functionality such as reversing the list.
            /// </summary>
            [Test]
            public void TestReverse()
            {
                list.AddLast(new User(1, "A", "a@example.com", "a"));
                list.AddLast(new User(2, "B", "b@example.com", "b"));
                list.AddLast(new User(3, "C", "c@example.com", "c"));

                list.Reverse();
                Assert.AreEqual("C", list.GetValue(0).Name);
                Assert.AreEqual("B", list.GetValue(1).Name);
                Assert.AreEqual("A", list.GetValue(2).Name);
            }
        }
    }

}