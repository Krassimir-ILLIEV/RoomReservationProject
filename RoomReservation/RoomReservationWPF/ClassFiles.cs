using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Threading.Tasks;
using RoomReservation.Models;
using System.Runtime.Serialization;

namespace RoomReservationWPF
{
    [Serializable]
    public class TestClass : ISerializable
    {
        private string field1;
        public TestClass()
        {
            field1 = "defoult";
        }
        public TestClass(string field1)
        {
            this.field1 = field1;
        }
        public TestClass(SerializationInfo info, StreamingContext context)
        {
            this.field1 = (string)info.GetValue("field1", typeof(string));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("field1", this.field1, typeof(string));
        }
        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializableObject"></param>
        /// <param name="fileName"></param>
        public static void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { return; }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }
        }


        /// <summary>
        /// Deserializes an xml file into an object list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static T DeSerializeObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            T objectOut = default(T);

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }

            return objectOut;
        }
        public static void TestXMLSerialization()
        {
            TestClass t1 = new TestClass("t1");
            TestClass t2 = new TestClass("t2");
            TestClass[] tt = { t1, t2 };
            SerializeObject<TestClass>(t1, "../../Test.ser");
            TestClass t3 = DeSerializeObject<TestClass>("../../Test.ser");
            WriteToBinaryFile<TestClass[]>(tt, "../../Test.bin");
            TestClass[] tts = ReadFromBinaryFile<TestClass[]>("../../Test.bin");

            // Room room1=new 

        }
        /// <summary>
        /// Writes the given object instance to a binary file.
        /// <para>Object type (and all child types) must be decorated with the [Serializable] attribute.</para>
        /// <para>To prevent a variable from being serialized, decorate it with the [NonSerialized] attribute; cannot be applied to properties.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the XML file.</typeparam>
        /// <param name="filePath">The file path to write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the XML file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public static void WriteToBinaryFile<T>(T objectToWrite, string filePath, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                IFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                try
                {
                    binaryFormatter.Serialize(stream, objectToWrite);
                }
                catch (Exception ex)
                {
                    //Log exception here
                }
            }
        }

        /// <summary>
        /// Reads an object instance from a binary file.
        /// </summary>
        /// <typeparam name="T">The type of object to read from the XML.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the binary file.</returns>
        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                IFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                try
                {
                    return (T)binaryFormatter.Deserialize(stream);
                }
                catch (Exception ex)
                {
                    //Log exception here
                }
                return default(T);
            }
        }

    }
    public class ClassFiles
    {
        public static void ReadTableFromSCV_(string Name)
        {
            //string appPath = Application.
            var lines = File.ReadAllLines(@"C:\Users\DerKaiser\Desktop\project GUi\RoomReservation\RoomReservationWPF\bin\Debug\IntData.csv").Select(a => a.Split(';'));
            var csv = from line in lines
                      select (from piece in line
                              select piece);
            string s = "";
            foreach (var data in csv)
            {
                s += data + ";";
            }
        }
        public static void ReadTableFromSCV(string FileName)
        {
            FileName = @"C:\Users\DerKaiser\Desktop\project GUi\RoomReservation\RoomReservationWPF\bin\Debug\IntData.csv";
            var csvlines = File.ReadAllLines(FileName).Select(a => a.Split(';'));
            /*
            var query = from csvline in csvlines
                        let data = csvline.Split(',')
                        select new
                        {
                            ID = data[0],
                            FirstNumber = data[1],
                            SecondNumber = data[2],
                            ThirdNumber = data[3]
                        };
             * 
            var stuff = from l in File.ReadAllLines(FileName)
                        let x = l.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Skip(1)
                                 .Select(s => int.Parse(s))
                        select new
                        {
                            Sum = x.Sum(),
                            Average = x.Average()
                        };
             * */
            var csv = from l in File.ReadAllLines(FileName)
                      let x = l.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                      /* select new 
                      {
                          FullName = x[0],
                          EMail = x[1],
                          Age = int.Parse(x[2])
                      };*/
                      select new Models.Manager(x[0], x[1], new Models.Location(), int.Parse(x[2]));

            string s = "";
            foreach (Models.Manager mgr in csv)
            {
                s += mgr.Name + ";";
            }

            /*
            string s = "";
            foreach (var data in csv)
            {
                s += data.FullName + ";";
                Models.Manager mng = new Models.Manager(data.FullName, data.EMail, new Models.Location(), data.Age);
            }
             */
        }
        public static void ReadRoomsFromSCV(string FileName)
        {
            // FileName = @"C:\Users\DerKaiser\Desktop\project GUi\RoomReservation\RoomReservationWPF\RoomData.csv";
            var csvlines = File.ReadAllLines(FileName);
            IEnumerable<Room> csv = from line in File.ReadAllLines(FileName).Skip(1) //without first line
                                    select new Room(line);
        }
    }
}
