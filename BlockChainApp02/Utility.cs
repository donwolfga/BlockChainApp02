using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace BlockChainApp02
{
    class Utility
    {
		static public string ByteArrayToString(Byte[] arrInput)
		{
			int i;
			string soutput = "";

			for (i = 0; i < arrInput.Length - 1; i++)
			{
				soutput += arrInput[i];
			}

			return soutput;
		}


		public static void ReadBlockchainFromXMLFile(string filePathAndName, Block[] BC)
		{
			XmlReader reader = XmlReader.Create(filePathAndName);

			int i = 0; //initialize the BlockArray index to 0

			while (reader.Read())
			{
				if (reader.NodeType == XmlNodeType.Element && reader.Name == "Block")
				{
					//We're in a block, so read all the attributes:
					BC[i].Index = Convert.ToInt32(reader.GetAttribute("Index"));
					BC[i].HashPreviousBlock = reader.GetAttribute("HashPreviousBlock");
					BC[i].Timestamp = Convert.ToDateTime(reader.GetAttribute("Timestamp"));
					BC[i].Data = reader.GetAttribute("Data");
					BC[i].HashThisBlock = reader.GetAttribute("HashThisBlock");
					i += 1;
				}
			}

			reader.Close();
		}

		public static void WriteBlockchainToXMLFile(string filePathAndName, Block[] BC)
		{
			if (File.Exists(filePathAndName))
			{
				//File is already there, so delete it before create a new one
				File.Delete(filePathAndName);

				//Create the file with the latest
				FileStream writer = new FileStream(filePathAndName, FileMode.CreateNew);

				using (XmlWriter xmlWriter = XmlWriter.Create(writer))
				{
					xmlWriter.WriteStartElement("Blockchain");

					for (int i = 0; i < BC.Length; i++)
					{
						xmlWriter.WriteStartElement("Block");
						xmlWriter.WriteAttributeString("HashThisBlock", BC[i].HashThisBlock);
						xmlWriter.WriteAttributeString("Data", BC[i].Data);
						xmlWriter.WriteAttributeString("Timestamp", BC[i].Timestamp.ToString());
						xmlWriter.WriteAttributeString("HashPreviousBlock", BC[i].HashPreviousBlock);
						xmlWriter.WriteAttributeString("Index", BC[i].Index.ToString());
						xmlWriter.WriteEndElement();
					}

					xmlWriter.WriteEndElement();
					xmlWriter.WriteEndDocument();

					writer.Flush();
				}
			}
			else
			{
				//File doesn't exist on hard-drive, so create from scratch
				FileStream writer = new FileStream(filePathAndName, FileMode.CreateNew);

				using (XmlWriter xmlWriter = XmlWriter.Create(writer))
				{
					xmlWriter.WriteStartElement("Blockchain");

					for (int i = 0; i < BC.Length; i++)
					{
						xmlWriter.WriteStartElement("Block");
						xmlWriter.WriteAttributeString("HashThisBlock", BC[i].HashThisBlock);
						xmlWriter.WriteAttributeString("Data", BC[i].Data);
						xmlWriter.WriteAttributeString("Timestamp", BC[i].Timestamp.ToString());
						xmlWriter.WriteAttributeString("HashPreviousBlock", BC[i].HashPreviousBlock);
						xmlWriter.WriteAttributeString("Index", BC[i].Index.ToString());
						xmlWriter.WriteEndElement();
					}

					xmlWriter.WriteEndElement();
					xmlWriter.WriteEndDocument();

					writer.Flush();

				}
			}
		}

	}
}
