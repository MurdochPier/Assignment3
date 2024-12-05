using Assignment3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
public static class SerializationHelper
{
    /// <summary>
    /// Serializes (encodes) users
    /// </summary>
    /// <param name="users">Linked list of users</param>
    /// <param name="fileName">File path to save serialized data</param>
    public static void SerializeUsers(ILinkedListADT users, string fileName)
    {
        // Convert the linked list to a List<User>
        List<User> userList = new List<User>();
        for (int i = 0; i < users.Count(); i++)
        {
            userList.Add(users.GetValue(i));
        }

        // Serialize the List<User>
        DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));
        using (FileStream stream = File.Create(fileName))
        {
            serializer.WriteObject(stream, userList);
        }
    }

    /// <summary>
    /// Deserializes (decodes) users
    /// </summary>
    /// <param name="fileName">File path to load serialized data</param>
    /// <returns>Linked list of users</returns>
    public static ILinkedListADT DeserializeUsers(string fileName)
    {
        // Deserialize into a List<User>
        DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));
        List<User> userList;
        using (FileStream stream = File.OpenRead(fileName))
        {
            userList = (List<User>)serializer.ReadObject(stream);
        }

        // Convert List<User> back to ILinkedListADT (SLL)
        ILinkedListADT users = new SLL();
        foreach (User user in userList)
        {
            users.AddLast(user);
        }

        return users;
    }
}

