using System;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace laba_14
{
    public class Program
    {
        [Serializable]
        public abstract class TransportVehicle
        {
            public string Name { get; set; }
            public int Spead { get; set; }
            
        }
        [DataContract]
        [Serializable]
        public class Car : TransportVehicle
        {
           [DataMember]
            public int YearCreate { get; set; }
            public Car(string _name, int _spead, int _yearCreate)
            {
                Name = _name;
                Spead = _spead;
                YearCreate = _yearCreate;
            }
            public Car()
            {

            }
            public void InfoCar()
            {
                Console.WriteLine("Car");
                Console.WriteLine("Data for create - " + YearCreate + "\nName - " + Name +"\nSpead - "+ Spead);
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Car carVech = new Car("Reno", 100, 1999);
            Car carVech1 = new Car("Maz", 60, 2012);
            Car[] carsArray = new Car[] { carVech, carVech1 };

            Console.WriteLine("Объект создан");
            BinaryFormatter binaryformatter = new BinaryFormatter(); // создаем объект BinaryFormatter
            Console.WriteLine("Binary:");
            using (FileStream fs = new FileStream("car.dat", FileMode.OpenOrCreate)) // получаем поток, куда будем записывать сериализованный объект
            {
                binaryformatter.Serialize(fs, carVech);
                Console.WriteLine("Объект сериализован в Binary");
            }
            using (FileStream fs = new FileStream("car.dat", FileMode.OpenOrCreate)) // десериализация из файла car.dat
            {
                Car newCar = (Car)binaryformatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован из Binary!");
                Console.WriteLine("Информация о объекте:");
                newCar.InfoCar();
            }
            Console.ReadLine();
            //--------------------------------------------
            // создаем объект SoapFormatter
            SoapFormatter soapformatter = new SoapFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            Console.WriteLine("Soap:");
            using (FileStream fs = new FileStream("car.soap", FileMode.OpenOrCreate))
            {
                soapformatter.Serialize(fs, carsArray);
                Console.WriteLine("Объект сериализован в Soap");
            }

            // десериализация
            using (FileStream fs = new FileStream("car.soap", FileMode.OpenOrCreate))
            {
                Car[] soapCar = (Car[])soapformatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован из Soap!");
                Console.WriteLine("Информация о объекте:");
                foreach (Car p in soapCar)
                {
                    p.InfoCar();
                }
            }
            Console.ReadLine();
            //=============================================================================
            XmlSerializer xmlformatter = new XmlSerializer(typeof(Car));

            // получаем поток, куда будем записывать сериализованный объект
            Console.WriteLine("XML:");

            using (FileStream fs = new FileStream("car.xml", FileMode.OpenOrCreate))
            {
                xmlformatter.Serialize(fs, carVech1);

                Console.WriteLine("Объект сериализован в XML");
            }

            // десериализация
            using (FileStream fs = new FileStream("car.xml", FileMode.OpenOrCreate))
            {
                Car xmalCar = (Car)xmlformatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован из XML");
                Console.WriteLine("Информация о объекте:");
                xmalCar.InfoCar();
            }

            Console.ReadLine();

            //--------------------------------------------------------------------------------
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Car[]));
            Console.WriteLine("Json:");
            using (FileStream fs = new FileStream("car.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, carsArray);
            }

            using (FileStream fs = new FileStream("car.json", FileMode.OpenOrCreate))
            {
                Car[] jsonCar = (Car[])jsonFormatter.ReadObject(fs);

                foreach (Car p in jsonCar)
                {
                    p.InfoCar();
                }
            }
            Console.ReadLine();
            Console.Clear();

            //333333333333333333333333333333333333333333333333333333333333333333333

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("car.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childNodes = xRoot.SelectNodes("//Car/Name");//selectNodes  выборк по запросу коллекции узлов в виде объекта XmlNodeList\
                                                                     //выбор в документе всех узлов с именем "Name", которые находятся в элементах "Car"
            Console.WriteLine("First xml request:\n");
            foreach (XmlNode n in childNodes)
            {
                Console.WriteLine(n.InnerText);
            }
            XmlNodeList nodeList = xRoot.SelectNodes("*");
            Console.WriteLine("\n\nSecond xml request:\n");
            foreach (XmlNode xml in nodeList)
            {
                Console.WriteLine(xml.OuterXml);
            }
            Console.ReadLine();
            Console.ReadLine();
            Console.Clear();

            //4444444444444444444444444444444444444444444444444444444444444444444444444

            XDocument xdoc = new XDocument(new XElement("Cars",
                new XElement("car", new XAttribute("name", "Peugeot 3008"),
                new XElement("company", "Peugeot"), new XElement("price", "15000")),
                new XElement("car", new XAttribute("name", "Volkswagen Golf"),
                new XElement("company", "Volkswagen"), new XElement("price", "30000"))));
            xdoc.Save("Cars.xml");
            XDocument xmldoc = XDocument.Load("Cars.xml");
            Console.WriteLine("Первый Linq to Xml запрос:\n");
            foreach (XElement phoneElement in xmldoc.Element("Cars").Elements("car"))
            {
                XAttribute nameAttribute = phoneElement.Attribute("name");
                XElement companyElement = phoneElement.Element("company");
                XElement priceElement = phoneElement.Element("price");
                if (nameAttribute != null && companyElement != null && priceElement != null)
                {
                    Console.WriteLine("Car: {0}", nameAttribute.Value);
                    Console.WriteLine("Company: {0}", companyElement.Value);
                    Console.WriteLine("Price: {0}", priceElement.Value);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nВторой Linq to Xml запрос:\n");
            foreach (XElement phoneElement in xmldoc.Element("Cars").Elements("car"))
            {
                XAttribute nameAttribute = phoneElement.Attribute("name");
                XElement companyElement = phoneElement.Element("company");
                XElement priceElement = phoneElement.Element("price");
                if (nameAttribute != null && companyElement != null && priceElement.Value == "15000")
                {
                    Console.WriteLine("Car: {0}", nameAttribute.Value);
                    Console.WriteLine("Company: {0}", companyElement.Value);
                    Console.WriteLine("Price: {0}", priceElement.Value);
                }
                Console.WriteLine();

            }
        }
    }
}
